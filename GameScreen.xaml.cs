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

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // Your submit button logic goes here
            MessageBox.Show("Test");
        }

        // Method to display questions in the UI











        private void DisplayQuestions()
        {
            // Clear any existing questions from the UI
            QuestionsStackPanel.Children.Clear();

            // Iterate through the questions and create TextBlock elements for each question
            foreach (var question in questions)
            {
                // Create a TextBlock for the question text
                TextBlock questionTextBlock = new TextBlock();
                questionTextBlock.Text = question.QuestionText;
                questionTextBlock.FontSize = 16;
                questionTextBlock.Margin = new Thickness(0, 10, 0, 0);

                // Create TextBlocks for answer options
                TextBlock answerOneTextBlock = new TextBlock();
                answerOneTextBlock.Text = $"A. {question.AnswerOne}";
                answerOneTextBlock.Margin = new Thickness(20, 5, 0, 0);

                TextBlock answerTwoTextBlock = new TextBlock();
                answerTwoTextBlock.Text = $"B. {question.AnswerTwo}";
                answerTwoTextBlock.Margin = new Thickness(20, 5, 0, 0);

                TextBlock answerThreeTextBlock = new TextBlock();
                answerThreeTextBlock.Text = $"C. {question.AnswerThree}";
                answerThreeTextBlock.Margin = new Thickness(20, 5, 0, 0);

                TextBlock answerFourTextBlock = new TextBlock();
                answerFourTextBlock.Text = $"D. {question.AnswerFour}";
                answerFourTextBlock.Margin = new Thickness(20, 5, 0, 0);

                // Add the question and answer TextBlocks to the StackPanel
                QuestionsStackPanel.Children.Add(questionTextBlock);
                QuestionsStackPanel.Children.Add(answerOneTextBlock);
                QuestionsStackPanel.Children.Add(answerTwoTextBlock);
                QuestionsStackPanel.Children.Add(answerThreeTextBlock);
                QuestionsStackPanel.Children.Add(answerFourTextBlock);
            }
        }


    }
}
