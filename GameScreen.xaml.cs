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

        // Variables to store questions for each player
        private List<Question> playerOneQuestions;
        private List<Question> playerTwoQuestions;

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

            // Shuffle the list of questions
            ShuffleQuestions(questions);


            // Divide the shuffled questions between players
            if (isMultiplayer)
            {
                // For multiplayer mode, assign half of the questions to each player
                int halfCount = questions.Count / 2;
                this.playerOneQuestions = questions.Take(halfCount).ToList();
                this.playerTwoQuestions = questions.Skip(halfCount).ToList();
            }
            else
            {
                // For single player mode, assign all questions to player one
                this.playerOneQuestions = questions;
                this.playerTwoQuestions = new List<Question>(); // Empty list for player two
            }

            // Update UI part with player names
            Player1NameLabel.Text = player1Name;
            Player2NameLabel.Text = player2Name;

            DisplayPlayers(isMultiplayer);

            // Display questions in the UI
            DisplayQuestions();
            DisplayQuestionsPlayerTwo();
        }

        // Shuffle the list of questions
        private void ShuffleQuestions(List<Question> questions)
        {
            Random rng = new Random();
            int n = questions.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Question value = questions[k];
                questions[k] = questions[n];
                questions[n] = value;
            }
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
                Question currentQuestion = playerOneQuestions.FirstOrDefault()!;

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
                playerOneQuestions.RemoveAt(0);

                // Load the next question or end the game if there are no more questions
                if (playerOneQuestions.Any())
                {
                    // Display the next question
                    DisplayQuestions();
                }
                else
                {
                    // End the game
                    // After processing the answer, check if the game has ended
                    CheckForEndOfGame();
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
                Question currentQuestion = playerTwoQuestions.FirstOrDefault()!;

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
                playerTwoQuestions.RemoveAt(0);

                // Load the next question or end the game if there are no more questions
                if (playerTwoQuestions.Any())
                {
                    // Display the next question
                    DisplayQuestionsPlayerTwo();
                }
                else
                {
                    // End the game
                    // After processing the answer, check if the game has ended
                    CheckForEndOfGame();
                }
            }
        }

        // Method to display questions in the UI
        private void DisplayQuestions()
        {
            // Check if there are questions available
            if (playerOneQuestions.Any())
            {
                // Set the text of the text block to the question text of the first question
                Player1Question.Text = playerOneQuestions[0].QuestionText;
                Player1AnswerA.Content = playerOneQuestions[0].AnswerOne;
                Player1AnswerB.Content = playerOneQuestions[0].AnswerTwo;
                Player1AnswerC.Content = playerOneQuestions[0].AnswerThree;
                Player1AnswerD.Content = playerOneQuestions[0].AnswerFour;
            }
            else
            {
                // Handle case when there are no questions available
                Player1Question.Text = "No questions available";
            }
        }

        // Method to display questions for player two in the UI
        private void DisplayQuestionsPlayerTwo()
        {
            // Check if there are questions available for player two
            if (playerTwoQuestions.Any())
            {
                // Set the text of the text block to the question text of the first question
                Player2Question.Text = playerTwoQuestions[0].QuestionText;
                Player2AnswerA.Content = playerTwoQuestions[0].AnswerOne;
                Player2AnswerB.Content = playerTwoQuestions[0].AnswerTwo;
                Player2AnswerC.Content = playerTwoQuestions[0].AnswerThree;
                Player2AnswerD.Content = playerTwoQuestions[0].AnswerFour;
            }
            else
            {
                // Handle case when there are no questions available for player two
                Player2Question.Text = "No questions available";
            }
        }
        private void CheckForEndOfGame()
        {
            if (!playerOneQuestions.Any() && !playerTwoQuestions.Any())
            {
                // Open the winner screen with the calculated winner and scores
                WinnerScreen winnerScreen = new WinnerScreen(playerOneName, playerTwoName, playerOneScore, playerTwoScore);
                winnerScreen.Show();

                // Close the current game window after showing the winner screen
                this.Close();
            }
        }
    }
}
