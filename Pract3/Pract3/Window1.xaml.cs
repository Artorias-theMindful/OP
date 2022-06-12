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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using static Pract3.MainWindow;
namespace Pract3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        SqlCommand command;
        SqlConnection connection = new SqlConnection(connectionString);
        int a = 0;
        public Window1()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            command = new SqlCommand("select dbo.Users.Password from dbo.Users where dbo.Users.Login = 'ADMIN'", connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            string adminpassword = "";
            while (sqlDataReader.Read())
            {
                adminpassword = sqlDataReader.GetValue(0).ToString().Trim();             
            }
            if(adminpassword == txtPassword.Text)
            {
                Admin admin = new Admin();
                connection.Close();
                admin.Show();
                Close();
            }
            else
            {
                a++;
                if (a == 3)
                    Application.Current.Shutdown();
                MessageBox.Show("incorrect password try " + a.ToString());
                
            }
        }
    }
}
