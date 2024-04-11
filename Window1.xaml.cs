using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RDHALNI;Initial Catalog=TriviaDB;Integrated Security=True;TrustServerCertificate=True");

        private void Read(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from TriviaDB.dbo.Trivia_Table", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Create(object sender, RoutedEventArgs e)
        {


            string command = "INSERT INTO TriviaDB.dbo.Trivia_Table(QuestionID, Question, AnswerOne, AnswerTwo, AnswerThree, AnswerFour, CorrectAnswer) " +
                "VALUES(125, 'John', 'Smitrh', '28', 'male', 'false', 'LOL')";
            SqlCommand cmd = new SqlCommand(command, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
            Read(sender, e);
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            string command = "UPDATE TriviaDB.dbo.Trivia_Table SET Question = 'MoinCruft' WHERE QuestionID = 001";
            SqlCommand cmd = new SqlCommand(command, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
            Read(sender, e);
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            string command = "DELETE FROM TriviaDB.dbo.Trivia_Table  WHERE QuestionID=125";
            SqlCommand cmd = new SqlCommand(command, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
            Read(sender, e);
        }
    }
}
