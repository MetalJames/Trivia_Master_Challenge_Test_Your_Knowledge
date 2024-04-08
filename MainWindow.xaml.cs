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
            string player1Name = Player1Name.Text;
            string player2Name = Player2Name.Text;

            if (string.IsNullOrWhiteSpace(player1Name))
                player1Name = "Player One";
            if (string.IsNullOrWhiteSpace(player2Name))
                player2Name = "Player Two";

/*            GameScreen gameScreen = new GameScreen(player1Name, player2Name, MultiplayerCheckBox.IsChecked ?? false);
            gameScreen.Show();
            this.Close();*/
        }
    }
}