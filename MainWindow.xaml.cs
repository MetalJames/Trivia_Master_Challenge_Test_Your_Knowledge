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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            // Get player names
            string player1Name = string.IsNullOrEmpty(Player1Name.Text) ? "Player One" : Player1Name.Text;
            string player2Name = string.IsNullOrEmpty(Player2Name.Text) ? "Player Two" : Player2Name.Text;

            // Navigate to GameScreen with player names
            GameScreen gameScreen = new GameScreen(player1Name, player2Name);
            gameScreen.Show();

            // Close current window
            this.Close();
        }

        private void Manage_Questions(object sender, RoutedEventArgs e)
        {

            // Navigate to Window1 with player names
            Window1 adminScreen = new Window1();
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
    }
}