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

namespace Trivia_Master_Challenge_Test_Your_Knowledge_
{
    /// <summary>
    /// Interaction logic for WinnerScreen.xaml
    /// </summary>
    public partial class WinnerScreen : Window
    {
        public WinnerScreen(string playerOneName, string playerTwoName, int player1Score, int player2Score)
        {
            InitializeComponent();
            Player1ScoreText.Text = $"{playerOneName} Score: {player1Score}";
            Player2ScoreText.Text = $"{playerTwoName} Score: {player2Score}";

            // Determine the winner based on scores
            string winnerName = player1Score > player2Score ? playerOneName : playerTwoName;
            if (player1Score == player2Score)
            {
                winnerName = "It's a tie!";
            }
            WinnerTextBlock.Text = $"Winner: {winnerName}";
        }

        public void PlayAgain (object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
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
