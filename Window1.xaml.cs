using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Trivia_Master_Challenge_Test_Your_Knowledge_
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RDHALNI;Initial Catalog=TriviaDB;Integrated Security=True;TrustServerCertificate=True");

        private void Read(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from TriviaDB.dbo.Trivia_Table", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get input values from text boxes
                int questionID = int.Parse(newQuestionIDTextBox.Text);
                string question = newQuestionTextBox.Text;
                string answerOne = newAnswerOneTextBox.Text;
                string answerTwo = newAnswerTwoTextBox.Text;
                string answerThree = newAnswerThreeTextBox.Text;
                string answerFour = newAnswerFourTextBox.Text;
                string correctAnswer = newCorrectAnswerTextBox.Text;
                char deleteQuestion = '0';

                // SQL command to insert values into the database
                string command = $"INSERT INTO TriviaDB.dbo.Trivia_Table (QuestionID, Question, AnswerOne, AnswerTwo, AnswerThree, AnswerFour, CorrectAnswer, DeleteQuestion) " +
                                 $"VALUES ({questionID}, '{question}', '{answerOne}', '{answerTwo}', '{answerThree}', '{answerFour}', '{correctAnswer}', '{deleteQuestion}')";

                // Execute SQL command
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // Reset the text fields
                newQuestionIDTextBox.Text = "";
                newQuestionTextBox.Text = "";
                newAnswerOneTextBox.Text = "";
                newAnswerTwoTextBox.Text = "";
                newAnswerThreeTextBox.Text = "";
                newAnswerFourTextBox.Text = "";
                newCorrectAnswerTextBox.Text = "";

                // Refresh the data grid
                Read(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void SelectToUpdate(object sender, RoutedEventArgs e)
        {
            // Ensure that there is at least one selected question
            if (datagrid.SelectedItems.Count > 0)
            {
                // Get the selected question from the datagrid
                DataRowView selectedQuestion = (DataRowView)datagrid.SelectedItem;

                // Populate the text fields with the content of the selected question
                newQuestionIDTextBox.Text = selectedQuestion["QuestionID"].ToString();
                newQuestionTextBox.Text = selectedQuestion["Question"].ToString();
                newAnswerOneTextBox.Text = selectedQuestion["AnswerOne"].ToString();
                newAnswerTwoTextBox.Text = selectedQuestion["AnswerTwo"].ToString();
                newAnswerThreeTextBox.Text = selectedQuestion["AnswerThree"].ToString();
                newAnswerFourTextBox.Text = selectedQuestion["AnswerFour"].ToString();
                newCorrectAnswerTextBox.Text = selectedQuestion["CorrectAnswer"].ToString();

                newQuestionIDTextBox.IsEnabled = false;

                // Disable and hide the "Add New Question" button
                createButton.IsEnabled = false;
                createButton.Opacity = 0;
                createButtonContainer.SetValue(Panel.ZIndexProperty, 0);

                // Enable and show the "Update" button
                updateButton.IsEnabled = true;
                updateButton.Opacity = 100;
                updateButtonContainer.SetValue(Panel.ZIndexProperty, 1);

            }
            else
            {
                MessageBox.Show("Please select a question to update.");
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the updated values from the text fields
                int questionID = int.Parse(newQuestionIDTextBox.Text); // ID remains the same
                string question = newQuestionTextBox.Text;
                string answerOne = newAnswerOneTextBox.Text;
                string answerTwo = newAnswerTwoTextBox.Text;
                string answerThree = newAnswerThreeTextBox.Text;
                string answerFour = newAnswerFourTextBox.Text;
                string correctAnswer = newCorrectAnswerTextBox.Text;

                // Construct the SQL command to update the question in the database
                string command = $"UPDATE TriviaDB.dbo.Trivia_Table " +
                                 $"SET Question = '{question}', " +
                                 $"AnswerOne = '{answerOne}', " +
                                 $"AnswerTwo = '{answerTwo}', " +
                                 $"AnswerThree = '{answerThree}', " +
                                 $"AnswerFour = '{answerFour}', " +
                                 $"CorrectAnswer = '{correctAnswer}' " +
                                 $"WHERE QuestionID = {questionID}";

                // Execute the SQL command
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // Reset the text fields
                newQuestionIDTextBox.Text = "";
                newQuestionTextBox.Text = "";
                newAnswerOneTextBox.Text = "";
                newAnswerTwoTextBox.Text = "";
                newAnswerThreeTextBox.Text = "";
                newAnswerFourTextBox.Text = "";
                newCorrectAnswerTextBox.Text = "";

                newQuestionIDTextBox.IsEnabled = true;

                // Disable and hide the "Add New Question" button
                createButton.IsEnabled = true;
                createButton.Opacity = 100;
                createButtonContainer.SetValue(Panel.ZIndexProperty, 1);

                // Enable and show the "Update" button
                updateButton.IsEnabled = false;
                updateButton.Opacity = 0;
                updateButtonContainer.SetValue(Panel.ZIndexProperty, 0);

                // Refresh the datagrid to reflect the changes
                Read(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the selected questions from the datagrid
                var selectedQuestions = datagrid.SelectedItems.Cast<DataRowView>()
                                        .Select(rowView => (int)rowView["QuestionID"]).ToList();

                // Open the database connection
                con.Open();

                // Delete each selected question from the database
                foreach (int questionID in selectedQuestions)
                {
                    string command = $"DELETE FROM TriviaDB.dbo.Trivia_Table WHERE QuestionID = {questionID}";
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.ExecuteNonQuery();
                }

                // Close the database connection
                con.Close();

                // Refresh the datagrid to reflect the changes
                Read(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ReturnToMainScreen(object sender, RoutedEventArgs e)
        {
            // Navigate to MainScreen with player names
            MainWindow mainScreen = new MainWindow();
            mainScreen.Show();

            this.Close();
        }
    }
}
