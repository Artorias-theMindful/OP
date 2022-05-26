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
using Lab4;
namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        public Window3()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                if(this.Title == "Додати факультет")
                    command = new SqlCommand(MainWindow.sttring + Tb1.Text + "','" + Tb2.Text + "')", connection);
                else if (this.Title == "Додати предмет")
                    command = new SqlCommand(MainWindow.sttring + Tb1.Text + "','" + Tb2.Text + "')", connection);
                else
                    command = new SqlCommand(MainWindow.sttring + Tb1.Text + "','" + Tb2.Text + "','" + Tb3.Text + "')", connection);
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }
        }
    }
}
