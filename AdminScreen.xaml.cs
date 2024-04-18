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
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {
        public AdminScreen()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RDHALNI;Initial Catalog=TriviaDB;Integrated Security=True;TrustServerCertificate=True");

        private void GetQuestions(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a new SQL command to fetch all records from the trivia table
                SqlCommand cmd = new SqlCommand("Select * from TriviaDB.dbo.Trivia_Table", con);

                // Create a DataTable to hold the fetched data
                DataTable dt = new DataTable();
                con.Open();

                // Execute the SQL command and retrieve the data using a SqlDataReader
                SqlDataReader sdr = cmd.ExecuteReader();

                // Load the data from the SqlDataReader into the DataTable
                dt.Load(sdr);
                con.Close();

                // Set the DataGrid's item source to the DataTable's default view
                // This will update the DataGrid to display the fetched data
                datagrid.ItemsSource = dt.DefaultView;

                // Set the DataGrid's opacity to 1 so it will display data
                datagrid.Opacity = 1;
            }
            catch (Exception ex)
            {
                // Close the database connection if an error occurs
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                // Log the exception or show a message to the user
                MessageBox.Show($"Failed to load data. Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            try
            {
                // Generate a new unique QuestionID
                // I decide to to change it to unique auto ID so there will be no errors
                int questionID = GenerateUniqueQuestionID();

                // Old method that uses user input, feel free to modify my code
                //int questionID = int.Parse(newQuestionIDTextBox.Text);

                // Get input values from text boxes
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
                //newQuestionIDTextBox.Text = ""; <- No longer need this field, feel free to modify my code
                newQuestionTextBox.Text = "";
                newAnswerOneTextBox.Text = "";
                newAnswerTwoTextBox.Text = "";
                newAnswerThreeTextBox.Text = "";
                newAnswerFourTextBox.Text = "";
                newCorrectAnswerTextBox.Text = "";

                // Refresh the data grid
                GetQuestions(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Helper functions to create Unique ID
        // Generate a unique QuestionID using querying the database for the maximum existing ID and adding 1,
        private int GenerateUniqueQuestionID()
        {
            int newQuestionID = GetMaxQuestionID() + 1;
            return newQuestionID;
        }

        // Query the database to get the maximum existing QuestionID
        private int GetMaxQuestionID()
        {
            string query = "SELECT MAX(QuestionID) FROM TriviaDB.dbo.Trivia_Table";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int maxID = (int)cmd.ExecuteScalar();
            con.Close();
            return maxID;
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

                //newQuestionIDTextBox.IsEnabled = false; <- No longer need to disable it as now ID adds automatically, feel fre to change anything you like :)

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

                //newQuestionIDTextBox.IsEnabled = true; <- No longer need to disable it as now ID adds automatically, feel fre to change anything you like :)
                newQuestionIDTextBox.Text = "Auto Generated";

                // Disable and hide the "Add New Question" button
                createButton.IsEnabled = true;
                createButton.Opacity = 100;
                createButtonContainer.SetValue(Panel.ZIndexProperty, 1);

                // Enable and show the "Update" button
                updateButton.IsEnabled = false;
                updateButton.Opacity = 0;
                updateButtonContainer.SetValue(Panel.ZIndexProperty, 0);

                // Refresh the datagrid to reflect the changes
                GetQuestions(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void DeleteQuestion(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if there are any questions in the datagrid
                if (datagrid.Items.Count == 0)
                {
                    MessageBox.Show("There are no questions to delete.");
                    return;
                }

                // Check if any question is selected
                if (datagrid.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select a question to delete.");
                    return;
                }
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
                GetQuestions(sender, e);
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