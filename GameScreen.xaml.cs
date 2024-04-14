using System;
using System.Collections.Generic;
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
using static Trivia_Master_Challenge_Test_Your_Knowledge_.MainWindow;

namespace Trivia_Master_Challenge_Test_Your_Knowledge_
{
    /// <summary>
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Window
    {
        // Variables to store player names
        private string playerOneName;
        private string playerTwoName;

        // Questions
        private List<Question> questions;

        // Multiplayer flag
        private bool isMultiplayer;

        // Initialize players score
        private int playerOneScore = 0;
        private int playerTwoScore = 0;

        public GameScreen(string player1Name, string player2Name, List<Question> questions, bool isMultiplayer)
        {
            InitializeComponent();

            // Store player names and questions
            this.playerOneName = player1Name;
            this.playerTwoName = player2Name;
            this.questions = questions;
            this.isMultiplayer = isMultiplayer;

            // Update UI part with player names
            Player1NameLabel.Text = player1Name;
            Player2NameLabel.Text = player2Name;

            DisplayPlayers(isMultiplayer);

            // Display questions in the UI
            DisplayQuestions();
            DisplayQuestionsPlayerTwo();
        }

        private void DisplayPlayers(bool isMultiplayer)
        {
            if (isMultiplayer)
            {
                // If multiplayer is enabled, set PlayerOneGrid and PlayerTwoGrid to visible
                PlayerOneGrid.Visibility = Visibility.Visible;
                PlayerTwoGrid.Visibility = Visibility.Visible;
            }
            else
            {
                // If multiplayer is not enabled, set PlayerOneGrid to visible and adjust its margin
                PlayerOneGrid.Visibility = Visibility.Visible;
                PlayerTwoGrid.Visibility = Visibility.Collapsed;

                // If multiplayer is not enabled, ensure the middle separator is collapsed
                MiddleSeparator.Visibility = Visibility.Collapsed;

                // Set the Grid.Column attached property of PlayerOneGrid child elements
                Grid.SetColumn(PlayerOneGrid, 1);

                // Clear the existing ColumnDefinitions
                GridChangeForOnePlayer.ColumnDefinitions.Clear();

                // Create new ColumnDefinition objects with the desired widths
                ColumnDefinition firstColumn = new ColumnDefinition();
                firstColumn.Width = new GridLength(1, GridUnitType.Star);

                ColumnDefinition secondColumn = new ColumnDefinition();
                secondColumn.Width = new GridLength(3, GridUnitType.Star);

                ColumnDefinition thirdColumn = new ColumnDefinition();
                thirdColumn.Width = new GridLength(1, GridUnitType.Star);

                // Add the new ColumnDefinition objects to the ColumnDefinitions collection of the grid
                GridChangeForOnePlayer.ColumnDefinitions.Add(firstColumn);
                GridChangeForOnePlayer.ColumnDefinitions.Add(secondColumn);
                GridChangeForOnePlayer.ColumnDefinitions.Add(thirdColumn);

            }
        }


        private void SubmitClickPlayerOne(object sender, RoutedEventArgs e)
        {
            // Check if any radio button is checked for player 1
            if (Player1AnswerA.IsChecked == true || Player1AnswerB.IsChecked == true ||
                Player1AnswerC.IsChecked == true || Player1AnswerD.IsChecked == true)
            {
                // Determine which radio button is checked for player 1
                RadioButton selectedRadioButton = new List<RadioButton>
                { Player1AnswerA, Player1AnswerB, Player1AnswerC, Player1AnswerD }
                .FirstOrDefault(rb => rb.IsChecked == true)!;

                // Get the content of the selected radio button
                string selectedAnswer = selectedRadioButton?.Content.ToString()!;

                // Find the current question
                Question currentQuestion = questions.FirstOrDefault()!;

                // Check if the selected answer matches the correct answer
                if (selectedAnswer == currentQuestion?.CorrectAnswer)
                {
                    MessageBox.Show("Correct!");
                    // If correct, update the player's score
                    playerOneScore++;
                    // Update the UI to reflect the new score
                    Player1Score.Text = playerOneScore.ToString();
                }
                else
                {
                    // If incorrect, provide feedback
                    MessageBox.Show("Incorrect.");
                }

                // Clear the checked state of all radio buttons
                Player1AnswerA.IsChecked = false;
                Player1AnswerB.IsChecked = false;
                Player1AnswerC.IsChecked = false;
                Player1AnswerD.IsChecked = false;

                // Remove the current question from the list
                questions.RemoveAt(0);

                // Load the next question or end the game if there are no more questions
                if (questions.Any())
                {
                    // Display the next question
                    DisplayQuestions();
                }
                else
                {
                    // End the game
                    // Handle case when there are no questions available
                    Player1Question.Text = "No questions available";
                    Player1AnswerA.Opacity = 0;
                    Player1AnswerB.Opacity = 0;
                    Player1AnswerC.Opacity = 0;
                    Player1AnswerD.Opacity = 0;
                    SubmitPlayerOne.IsEnabled = false;
                }
            }
        }

        private void SubmitClickPlayerTwo(object sender, RoutedEventArgs e)
        {
            // Check if any radio button is checked for player 1
            if (Player2AnswerA.IsChecked == true || Player2AnswerB.IsChecked == true ||
                Player2AnswerC.IsChecked == true || Player2AnswerD.IsChecked == true)
            {
                // Determine which radio button is checked for player 1
                RadioButton selectedRadioButton = new List<RadioButton>
                { Player2AnswerA, Player2AnswerB, Player2AnswerC, Player2AnswerD }
                .FirstOrDefault(rb => rb.IsChecked == true)!;

                // Get the content of the selected radio button
                string selectedAnswer = selectedRadioButton?.Content.ToString()!;

                // Find the current question
                Question currentQuestion = questions.FirstOrDefault()!;

                // Check if the selected answer matches the correct answer
                if (selectedAnswer == currentQuestion?.CorrectAnswer)
                {
                    MessageBox.Show("Correct!");
                    // If correct, update the player's score
                    playerTwoScore++;
                    // Update the UI to reflect the new score
                    Player2Score.Text = playerTwoScore.ToString();
                }
                else
                {
                    // If incorrect, provide feedback
                    MessageBox.Show("Incorrect.");
                }

                // Clear the checked state of all radio buttons
                Player2AnswerA.IsChecked = false;
                Player2AnswerB.IsChecked = false;
                Player2AnswerC.IsChecked = false;
                Player2AnswerD.IsChecked = false;

                // Remove the current question from the list
                questions.RemoveAt(0);

                // Load the next question or end the game if there are no more questions
                if (questions.Any())
                {
                    // Display the next question
                    DisplayQuestionsPlayerTwo();
                }
                else
                {
                    // End the game
                    // Handle case when there are no questions available
                    Player2Question.Text = "No questions available";
                    Player2AnswerA.Opacity = 0;
                    Player2AnswerB.Opacity = 0;
                    Player2AnswerC.Opacity = 0;
                    Player2AnswerD.Opacity = 0;
                    SubmitPlayerTwo.IsEnabled = false;
                }
            }
        }

        // Method to display questions in the UI
        private void DisplayQuestions()
        {
            // Check if there are questions available
            if (questions.Any())
            {
                // Set the text of the text block to the question text of the first question
                Player1Question.Text = questions[0].QuestionText;
                Player1AnswerA.Content = questions[0].AnswerOne;
                Player1AnswerB.Content = questions[0].AnswerTwo;
                Player1AnswerC.Content = questions[0].AnswerThree;
                Player1AnswerD.Content = questions[0].AnswerFour;
            }
            else
            {
                // Handle case when there are no questions available
                Player1Question.Text = "No questions available";
            }
        }

        // Method to display questions in the UI
        private void DisplayQuestionsPlayerTwo()
        {
            // Check if there are questions available
            if (questions.Any())
            {
                // Set the text of the text block to the question text of the first question
                Player2Question.Text = questions[0].QuestionText;
                Player2AnswerA.Content = questions[0].AnswerOne;
                Player2AnswerB.Content = questions[0].AnswerTwo;
                Player2AnswerC.Content = questions[0].AnswerThree;
                Player2AnswerD.Content = questions[0].AnswerFour;
            }
            else
            {
                // Handle case when there are no questions available
                Player2Question.Text = "No questions available";
            }
        }
    }
}
