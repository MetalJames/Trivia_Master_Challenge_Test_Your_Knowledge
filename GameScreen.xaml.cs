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
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Window
    {
        // Variables to store player names
        private string playerOneName;
        private string playerTwoName;

        public GameScreen(string player1Name, string player2Name)
        {
            InitializeComponent();

            // Store player names
            this.playerOneName = player1Name;
            this.playerTwoName = player2Name;

            // Update UI part with player names
            Player1NameLabel.Text = player1Name;
            Player2NameLabel.Text = player2Name;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // Your submit button logic goes here
            MessageBox.Show("Test");
        }
    }
}
