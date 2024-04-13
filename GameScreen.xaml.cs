﻿using System;
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

        // Initialize players score
        private int playerOneScore = 0;
        private int playerTwoScore = 0;

        public GameScreen(string player1Name, string player2Name, List<Question> questions)
        {
            InitializeComponent();

            // Store player names and questions
            this.playerOneName = player1Name;
            this.playerTwoName = player2Name;
            this.questions = questions;

            // Update UI part with player names
            Player1NameLabel.Text = player1Name;
            Player2NameLabel.Text = player2Name;

            // Display questions in the UI
            DisplayQuestions();
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
                .FirstOrDefault(rb => rb.IsChecked == true);

                // Get the content of the selected radio button
                string selectedAnswer = selectedRadioButton.Content.ToString();

                // Find the current question
                Question currentQuestion = questions.FirstOrDefault();

                // Check if the selected answer matches the correct answer
                if (selectedAnswer == currentQuestion.CorrectAnswer)
                {
                    // If correct, update the player's score
                    MessageBox.Show("Correct!");
                    playerOneScore++;
                    Player1Score.Text = playerOneScore.ToString();
                    // Update player 1's score (assuming you have a variable to track the score)
                    // player1Score++;
                    // Update the UI to reflect the new score
                    // Player1Score.Text = player1Score.ToString();
                }
                else
                {
                    // If incorrect, provide feedback
                    MessageBox.Show("Incorrect. Please try again.");
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
                    // End the game (you can implement this based on your game logic)
                    // Handle case when there are no questions available
                    Player1Question.Text = "No questions available";
                }
            }
        }

        private void SubmitClickPlayerTwo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
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
    }
}
