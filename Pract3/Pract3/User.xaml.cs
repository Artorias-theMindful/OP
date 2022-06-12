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
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        static int a = 0;
        SqlCommand command;
        SqlConnection connection = new SqlConnection(connectionString);
        public User()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand("select dbo.Users.Status from dbo.Users where dbo.Users.Login = '" + Login1.Text + "'", connection);
            SqlDataReader sqlDataReader12 = command.ExecuteReader();
            string status = "";
            while (sqlDataReader12.Read())
            {
                status = sqlDataReader12.GetValue(0).ToString().Trim();
            }
            connection.Close();
            if (status == "True")
            {


                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command = new SqlCommand("select dbo.Users.Password from dbo.Users where dbo.Users.Login = '" + Login1.Text + "'", connection);
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    string password = "";
                    while (sqlDataReader.Read())
                    {
                        password = sqlDataReader.GetValue(0).ToString().Trim();
                    }
                    connection.Close();
                    if (Password1.Text == password)
                    {
                        Name1.IsEnabled = true;
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        command = new SqlCommand("select dbo.Users.Name from dbo.Users where dbo.Users.Login = '" + Login1.Text + "'", connection);
                        SqlDataReader sqlDataReader1 = command.ExecuteReader();
                        string name = "";
                        while (sqlDataReader1.Read())
                        {
                            name = sqlDataReader1.GetValue(0).ToString().Trim();
                        }
                        connection.Close();
                        Name1.Text = name;
                        Surname1.IsEnabled = true;
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        command = new SqlCommand("select dbo.Users.Surname from dbo.Users where dbo.Users.Login = '" + Login1.Text + "'", connection);
                        SqlDataReader sqlDataReader2 = command.ExecuteReader();
                        string surname = "";
                        while (sqlDataReader2.Read())
                        {
                            surname = sqlDataReader2.GetValue(0).ToString().Trim();
                        }
                        connection.Close();
                        Password2.Text = password;
                        Password2.IsEnabled = true;
                        Password3.IsEnabled = true;
                        Change.IsEnabled = true;
                    }
                    else
                    {
                        a++;
                        if (a == 3)
                            Application.Current.Shutdown();
                        MessageBox.Show("try " + (a).ToString());

                    }
                }
                catch
                {
                    a++;
                    if (a == 3)
                        Application.Current.Shutdown();
                    MessageBox.Show("try " + (a).ToString());
                }
            }
            else if(status == "False")
            {
                MessageBox.Show("Ви забанені");
            }
            else
            {
                MessageBox.Show("There is no such a user");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand("select dbo.Users.Restriction from dbo.Users where dbo.Users.Login = '" + Login1.Text + "'", connection);
                SqlDataReader sqlDataReader2 = command.ExecuteReader();
                string restriction = "";
                while (sqlDataReader2.Read())
                {
                    restriction = sqlDataReader2.GetValue(0).ToString().Trim();
                }
                connection.Close();
                if (restriction == "True")
                {
                    if (RestrictionPassword(Password2.Text))
                    {
                        if (Password2.Text == Password3.Text)
                        {

                            command = new SqlCommand("UPDATE dbo.Users SET dbo.Users.Password = '" + Password1.Text + "', dbo.Users.Name = '" + Name2.Text + "', dbo.Users.Surname = '" + Surname1.Text + "' WHERE Login = '" + Login1.Text + "'", connection);
                            command.ExecuteNonQuery();
                            Password1.Text = "";
                            Password2.Text = "";
                            Login1.Text = "";
                            Name1.Text = "";
                            Surname1.Text = "";
                            Password2.Text = "";
                            Password3.Text = "";
                            MessageBox.Show("Success!");
                        }
                        else
                        {
                            MessageBox.Show("Incorrect passwords");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Restricted password");
                    }
                }
                else
                {
                    if (Password2.Text == Password3.Text)
                    {
                        connection.Open();
                        command = new SqlCommand("UPDATE dbo.Users SET dbo.Users.Password = '" + Password2.Text + "', dbo.Users.Name = '" + Name1.Text + "', dbo.Users.Surname = '" + Surname1.Text + "' WHERE Login = '" + Login1.Text + "'", connection);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Success!");
                        Password1.Text = "";
                        Password2.Text = "";
                        Login1.Text = "";
                        Name1.Text = "";
                        Surname1.Text = "";
                        Password2.Text = "";
                        Password3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Incorrect passwords");
                    }
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Try again");
            }
            
        }
        public bool RestrictionPassword(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {

                if (!char.IsLetter(password[i]) && !char.IsNumber(password[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login2.Text == "")
                {
                    MessageBox.Show("Fill all necessary fields!");
                }
                else
                {
                    if (Password4.Text == Password5.Text)
                    {
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        command = new SqlCommand("insert into dbo.Users (Login, Name, Surname, Password, Status, Restriction) values('" + Login2.Text + "','" + Name2.Text + "','" + Surname2.Text + "','" + Password4.Text + "', 1, 0)", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Success!");
                        Login2.Text = "";
                        Name2.Text = "";
                        Surname2.Text = "";
                        Password4.Text = "";
                        Password5.Text = "";

                        connection.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Try again (login already exists)");
            }
            
        }
    }
}
