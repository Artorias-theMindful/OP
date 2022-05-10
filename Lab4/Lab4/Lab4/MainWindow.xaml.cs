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

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;

        }
        void ShowData(string SqlQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);
            
            connection.Open();

            command = new SqlCommand(SqlQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;

            connection.Close();

        }

        private void Subjects_Click(object sender, RoutedEventArgs e)
        {
            ShowData("SELECT IDsubject, SubjectName FROM     dbo.Предмети", dataGrid);
        }

        private void Marks_Click(object sender, RoutedEventArgs e)
        {
            ShowData("SELECT dbo.Абітуріенти.Surname, dbo.Предмети.SubjectName, dbo.Студенти_Оцінки.Mark FROM     dbo.Студенти_Оцінки INNER JOIN dbo.Абітуріенти ON dbo.Студенти_Оцінки.IDStudent = dbo.Абітуріенти.ExamList INNER JOIN dbo.Предмети ON dbo.Студенти_Оцінки.IDSubject = dbo.Предмети.IDsubject", dataGrid);
        }

        private void Students_Click(object sender, RoutedEventArgs e)
        {
            ShowData("SELECT GroupName, Surname, Name FROM dbo.Групи INNER JOIN dbo.Абітуріенти ON dbo.Групи.IDGroup = dbo.Абітуріенти.GroupID", dataGrid);
        }

        private void Groups_Click(object sender, RoutedEventArgs e)
        {
            ShowData("SELECT dbo.Факультети.FacultativeName, dbo.Групи.GroupName FROM     dbo.Факультети CROSS JOIN dbo.Групи", dataGrid);
        }

        private void Consultations_Click(object sender, RoutedEventArgs e)
        {
            ShowData("SELECT dbo.Консультації.Date, dbo.Абітуріенти.Surname, dbo.Абітуріенти.Name, dbo.Предмети.SubjectName FROM     dbo.Консультації INNER JOIN dbo.Абітуріенти ON dbo.Консультації.ExamList = dbo.Абітуріенти.ExamList INNER JOIN dbo.Предмети ON dbo.Консультації.IDSubject = dbo.Предмети.IDsubject", dataGrid);
        }
    }
}
