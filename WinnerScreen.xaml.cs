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
    /// Interaction logic for WinnerScreen.xaml
    /// </summary>
    public partial class WinnerScreen : Window
    {
        private string player1Name;
        private string player2Name;
        private List<Question> questions;
        private bool isMultiplayer;
        private int selectedQuestionCount;

        public WinnerScreen(string playerOneName, string playerTwoName, int player1Score, int player2Score, List<Question> questions, bool isMultiplayer, int selectedQuestionCount)
        {
            InitializeComponent();
            Player1ScoreText.Text = $"{playerOneName}:";
            Player2ScoreText.Text = $"{playerTwoName}:";
            Player1Score.Text = $"{player1Score}";
            Player2Score.Text = $"{player2Score}";

            // Determine the winner based on scores
            string winnerName = player1Score > player2Score ? playerOneName : playerTwoName;
            if (player1Score == player2Score)
            {
                winnerName = "It's a tie!";
            }
            WinnerTextBlock.Text = $"Winner: {winnerName}";

            // Store the player names, questions, and multiplayer flag
            this.player1Name = playerOneName;
            this.player2Name = playerTwoName;
            this.questions = questions;
            this.isMultiplayer = isMultiplayer;
            this.selectedQuestionCount = selectedQuestionCount;
        }

        // Play Again button click event handler
        public void PlayAgain(object sender, RoutedEventArgs e)
        {
            // Perform actions to reset the game or navigate back to the game screen
            GameScreen gameScreen = new GameScreen(player1Name, player2Name, questions, isMultiplayer, selectedQuestionCount);
            gameScreen.Show();
            // Close the current WinnerScreen
            this.Close();
        }

        private void ReturnToMainScreen(object sender, RoutedEventArgs e)
        {
            // Navigate to MainScreen
            MainWindow mainScreen = new MainWindow();
            mainScreen.Show();

            this.Close();
        }

    }
}
