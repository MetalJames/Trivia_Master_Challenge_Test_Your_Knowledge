using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trivia_Master_Challenge_Test_Your_Knowledge_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RDHALNI;Initial Catalog=TriviaDB;Integrated Security=True;TrustServerCertificate=True");

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            // Get player names
            string player1Name = string.IsNullOrEmpty(Player1Name.Text) ? "Player One" : Player1Name.Text;
            string player2Name = string.IsNullOrEmpty(Player2Name.Text) ? "Player Two" : Player2Name.Text;

            // Determine if multiplayer is selected
            bool isMultiplayer = MultiplayerCheckBox.IsChecked == true;

            // Fetch questions from the database
            List<Question> questions = FetchQuestionsFromDatabase();

            if (questions.Count > 0)
            {
                // Navigate to GameScreen with player names
                GameScreen gameScreen = new GameScreen(player1Name, player2Name, questions, isMultiplayer);
                gameScreen.Show();

                // Close current window
                this.Close();
            }
            else
            {
                MessageBox.Show("No questions found in the database. Check your connection.");
            }

        }

        private void Manage_Questions(object sender, RoutedEventArgs e)
        {

            // Navigate to Login Screen
            LoginScreen adminScreen = new LoginScreen();
            adminScreen.Show();

            // Close current window
            this.Close();
        }

        private void MultiplayerCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Enable Player 2 name textbox when Multiplayer checkbox is checked
            Player2Name.IsEnabled = true;
        }

        private void MultiplayerCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Disable Player 2 name textbox when Multiplayer checkbox is unchecked
            Player2Name.IsEnabled = false;
        }

        // Fetching Questions Section
        // Class representing a single trivia question
        public class Question
        {
            // Property to hold the text of the question
            public string? QuestionText { get; set; }

            // Proo hold the four possible answer options
            public string? AnswerOne { get; set; }
            public string? AnswerTwo { get; set; }
            public string? AnswerThree { get; set; }
            public string? AnswerFour { get; set; }

            // Prohold the correct answer to the question
            public string? CorrectAnswer { get; set; }
        }

        // Creating List with questions
        private List<Question> FetchQuestionsFromDatabase()
        {
            List<Question> questions = new List<Question>();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TriviaDB.dbo.Trivia_Table", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Question question = new Question
                    {
                        QuestionText = reader["Question"].ToString()!,
                        AnswerOne = reader["AnswerOne"].ToString()!,
                        AnswerTwo = reader["AnswerTwo"].ToString()!,
                        AnswerThree = reader["AnswerThree"].ToString()!,
                        AnswerFour = reader["AnswerFour"].ToString()!,
                        CorrectAnswer = reader["CorrectAnswer"].ToString()!,
                    };
                    questions.Add(question);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching questions: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return questions;
        }
    }
}