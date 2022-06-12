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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        static int a = 0;
        SqlCommand command;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter adapter;
        static DataTable table = new DataTable();
        public Admin()
        {
            InitializeComponent();
            ShowData("SELECT Name AS [Ім'я], Surname AS Фамілія, Login AS Логін, Password AS Пароль, Status, Restriction FROM     dbo.Users", dataGrid);
            ShowMember(a);
            for(int i = 0; i < table.Rows.Count; i++)
            {
                MembersList.Items.Add(table.Rows[i][2]);
            }
        }
        void ShowData(string SqlQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);

            connection.Open();
            table.Clear();
            command = new SqlCommand(SqlQuery, connection);
            adapter = new SqlDataAdapter(command);
            
            adapter.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;

            connection.Close();

        }
        void ShowMember(int b)
        {
            
            Name.Content = table.Rows[b][0];
            Surname.Content = table.Rows[b][1];
            Login.Content = table.Rows[b][2];
            Status.Content = table.Rows[b][4];
            Restriction.Content = table.Rows[b][5];
            
        }
        private void changepassword_Click(object sender, RoutedEventArgs e)
        {
            if (RestrictionPassword(newpassword1.Text))
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
                connection.Close();


                if (password.Text == adminpassword && newpassword1.Text != null && newpassword2.Text == newpassword1.Text)
                {
                    connection.Open();
                    command = new SqlCommand("UPDATE dbo.Users SET dbo.Users.Password = '" + newpassword1.Text + "' WHERE Login = 'ADMIN' ", connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Try again");
                }


                ShowData("SELECT Name AS [Ім'я], Surname AS Фамілія, Login AS Логін, Password AS Пароль, Status, Restriction FROM     dbo.Users", dataGrid);
            }
            else
                MessageBox.Show("restricted password");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a++;
            if (a == table.Rows.Count)
                a = 0;
            ShowMember(a);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            a--;
            if (a == -1)
                a = table.Rows.Count - 1;
            ShowMember(a);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                command = new SqlCommand("insert into dbo.Users (Login, Restriction, Status) values('" + NewMember.Text + "', 0, 1)", connection);
                command.ExecuteNonQuery();
                ShowData("SELECT Name AS [Ім'я], Surname AS Фамілія, Login AS Логін, Password AS Пароль, Status, Restriction FROM     dbo.Users", dataGrid);
                MembersList.Items.Add(NewMember.Text);
                NewMember.Text = "";
                connection.Close();
                
            }
            catch
            {
                MessageBox.Show("try again");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (StatusCheck.IsChecked == true && MembersList.SelectedItem != null)
            {
                connection.Open();
                command = new SqlCommand("UPDATE dbo.Users SET dbo.Users.Status = '1' WHERE Login = '" + MembersList.SelectedItem.ToString() + "'", connection);
                command.ExecuteNonQuery();
                connection.Close();
                ShowData("SELECT Name AS [Ім'я], Surname AS Фамілія, Login AS Логін, Password AS Пароль, Status, Restriction FROM     dbo.Users", dataGrid);
            }
            else if(MembersList.SelectedItem != null)
            {
                connection.Open();
                command = new SqlCommand("UPDATE dbo.Users SET dbo.Users.Status = '0' WHERE Login = '" + MembersList.SelectedItem.ToString() + "'", connection);
                command.ExecuteNonQuery();
                connection.Close();
                ShowData("SELECT Name AS [Ім'я], Surname AS Фамілія, Login AS Логін, Password AS Пароль, Status, Restriction FROM     dbo.Users", dataGrid);
            }
            else
            {
                MessageBox.Show("choose login");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (RestrictionCheck.IsChecked == true && MembersList.SelectedItem != null)
            {
                connection.Open();
                command = new SqlCommand("UPDATE dbo.Users SET dbo.Users.Restriction = '1' WHERE Login = '" + MembersList.SelectedItem.ToString() + "'", connection);
                command.ExecuteNonQuery();
                connection.Close();
                ShowData("SELECT Name AS [Ім'я], Surname AS Фамілія, Login AS Логін, Password AS Пароль, Status, Restriction FROM     dbo.Users", dataGrid);
            }
            else if (MembersList.SelectedItem != null)
            {
                connection.Open();
                command = new SqlCommand("UPDATE dbo.Users SET dbo.Users.Restriction = '0' WHERE Login = '" + MembersList.SelectedItem.ToString() + "'", connection);
                command.ExecuteNonQuery();
                connection.Close();
                ShowData("SELECT Name AS [Ім'я], Surname AS Фамілія, Login AS Логін, Password AS Пароль, Status, Restriction FROM     dbo.Users", dataGrid);
            }
            else
            {
                MessageBox.Show("choose login");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
        public bool RestrictionPassword(string password)
        {
            for(int i = 0; i < password.Length; i ++)
            {
                
                if (!char.IsLetter(password[i]) && !char.IsNumber(password[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void MembersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(MembersList.SelectedItem.ToString().Trim() == "ADMIN")
            {
                StatusCheck.IsEnabled = false;
            }
            else
            {
                StatusCheck.IsEnabled = true;
            }
        }
    }
}
