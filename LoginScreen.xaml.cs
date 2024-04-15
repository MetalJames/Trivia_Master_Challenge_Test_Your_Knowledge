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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            // Check if the login and password are correct
            string expectedLogin = "admin";
            string expectedPassword = "admin";
            string inputLogin = LoginTextBox.Text;
            string inputPassword = PasswordBox.Password;
            bool isHuman = HumanCheckBox.IsChecked ?? false;

            if (inputLogin == expectedLogin && inputPassword == expectedPassword && isHuman)
            {
                // Navigate to AdminScreen to manage the questions
                AdminScreen manageQuestionsScreen = new AdminScreen();
                manageQuestionsScreen.Show();

                this.Close();
            }
            else if (inputLogin != expectedLogin || inputPassword != expectedPassword)
            {
                // Show error message if login or password is incorrect
                MessageBox.Show("Incorrect login or password. Please try again.");
            }
            else
            {
                // Show error message if checkbox is incorrect
                MessageBox.Show("So, are you really a human being?");
            }
        }


        private void HomeClick(object sender, RoutedEventArgs e)
        {
            // Navigate to MainScreen
            MainWindow mainScreen = new MainWindow();
            mainScreen.Show();

            this.Close();
        }
    }
}
