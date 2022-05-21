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
        public static string sttring;
        public static string stttring;
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
            ShowData("SELECT dbo.Абітуріенти.ExamList, dbo.Абітуріенти.Surname, dbo.Абітуріенти.Name, dbo.Абітуріенти.SecName, dbo.Групи.GroupName FROM dbo.Групи INNER JOIN dbo.Абітуріенти ON dbo.Групи.IDGroup = dbo.Абітуріенти.GroupID", dataGrid);
        }

        private void Groups_Click(object sender, RoutedEventArgs e)
        {
            ShowData("SELECT dbo.Факультети.IDFacultative, dbo.Факультети.FacultativeName, dbo.Групи.GroupName FROM     dbo.Факультети INNER JOIN dbo.Кафедри ON dbo.Факультети.IDFacultative = dbo.Кафедри.IDFacultative INNER JOIN dbo.Потоки ON dbo.Кафедри.IDCathedra = dbo.Потоки.IDCathedra INNER JOIN dbo.Групи ON dbo.Потоки.IDFlow = dbo.Групи.IDFlow", dataGrid);
        }

        private void Consultations_Click(object sender, RoutedEventArgs e)
        {
            ShowData("SELECT dbo.Консультації.Date, dbo.Абітуріенти.Surname, dbo.Абітуріенти.Name, dbo.Предмети.SubjectName FROM     dbo.Консультації INNER JOIN dbo.Абітуріенти ON dbo.Консультації.ExamList = dbo.Абітуріенти.ExamList INNER JOIN dbo.Предмети ON dbo.Консультації.IDSubject = dbo.Предмети.IDsubject", dataGrid);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            if (AddCombobox.Text == "Абітуріента")
            {
                Window1 window1 = new Window1();
                window1.Show();
            }
            else if(AddCombobox.Text == "Поток")
            {
                Window3 window3 = new Window3();
                sttring = "INSERT INTO dbo.Потоки (IDFlow, FlowName, IDCathedra) VALUES('";
                window3.label1.Content = "ID потоку";
                window3.label2.Content = "Ім'я потоку";
                window3.label3.Content = "ID кафедри";
                window3.Title = "Додати поток";
                window3.Show();
            }
            else if (AddCombobox.Text == "Групу")
            {
                Window3 window3 = new Window3();
                sttring = "INSERT INTO dbo.Групи (IDGroup, GroupName, IDFlow) VALUES('";
                window3.label1.Content = "ID групи";
                window3.label2.Content = "Ім'я групи";
                window3.label3.Content = "ID потоку";
                window3.Title = "Додати групу";
                window3.Show();
            }
            else if (AddCombobox.Text == "Кафедру")
            {
                Window3 window3 = new Window3();
                sttring = "INSERT INTO dbo.Кафедри (IDCathedra, CathedraName, IDFacultative) VALUES('";
                window3.label1.Content = "ID кафедри";
                window3.label2.Content = "Ім'я кафедри";
                window3.label3.Content = "ID факультету";
                window3.Title = "Додати кафедру";
                window3.Show();
            }
            else if (AddCombobox.Text == "Факультет")
            {
                Window3 window3 = new Window3();
                sttring = "INSERT INTO dbo.Факультети (IDFacultative, FacultativeName) VALUES('";
                window3.label1.Content = "ID Факультету";
                window3.label2.Content = "Ім'я факультету";
                window3.label3.Content = "";
                window3.Tb3.IsEnabled = false;
                window3.Title = "Додати факультет";
                window3.Show();
            }
            else if (AddCombobox.Text == "Оцінка")
            {
                Window3 window3 = new Window3();
                sttring = "INSERT INTO dbo.Студенти_Оцінки (IDStudent, IDSubject, Mark) VALUES('";
                window3.label1.Content = "ID студента";
                window3.label2.Content = "ID предмета";
                window3.label3.Content = "Оцінка";

                window3.Title = "Додати оцінку";
                window3.Show();
            }
            else if (AddCombobox.Text == "Консультацію")
            {
                Window5 window5 = new Window5();
                sttring = "INSERT INTO dbo.Консультації (ExamList, Date, Auditory, IDSubject) VALUES('";
                window5.label1.Content = "ID студента";
                window5.label2.Content = "Дата";
                window5.label3.Content = "Аудиторія";
                window5.label4.Content = "ID предмета";
                window5.Title = "Додати консультацію";
                window5.Show();
            }
            else if (AddCombobox.Text == "Екзамен")
            {
                Window5 window5 = new Window5();
                sttring = "INSERT INTO dbo.Екзамени (IDGroup, IDSubject, Date, Auditory) VALUES('";
                window5.label1.Content = "ID групи";
                window5.label2.Content = "ID предмета";
                window5.label3.Content = "Дата";
                window5.label4.Content = "Аудиторія";
                window5.Title = "Додати екзамен";
                window5.Show();
            }
            else if (AddCombobox.Text == "Предмет")
            {
                Window3 window3 = new Window3();
                sttring = "INSERT INTO dbo.Предмети (IDsubject, SubjectName) VALUES('";
                window3.label1.Content = "ID Предмету";
                window3.label2.Content = "Ім'я предмету";
                window3.label3.Content = "";
                window3.Tb3.IsEnabled = false;
                window3.Title = "Додати предмет";
                window3.Show();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            Window4 window4 = new Window4();
            if (DeleteCombobox.Text == "Абітурієнта")
            {
                window2.label.Content = "Введіть ID студента";
                stttring = "DELETE FROM dbo.Абітуріенти WHERE ExamList = '";
                window2.Title = "Видалити абітуріента";
                window2.Show();
            }
            else if (DeleteCombobox.Text == "Групу")
            {
                window2.label.Content = "Введіть ID групи";
                stttring = "DELETE FROM dbo.Групи WHERE IDGroup = '";
                window2.Title = "Видалити групу";
                window2.Show();
            }
            else if (DeleteCombobox.Text == "Поток")
            {
                window2.label.Content = "Введіть ID потоку";
                stttring = "DELETE FROM dbo.Потоки WHERE IDFlow = '";
                window2.Title = "Видалити поток";
                window2.Show();
            }
            else if (DeleteCombobox.Text == "Факультет")
            {
                window2.label.Content = "Введіть ID факультету";
                stttring = "DELETE FROM dbo.Факультети WHERE IDFacultative = '";
                window2.Title = "Видалити факультет";
                window2.Show();
            }
            else if (DeleteCombobox.Text == "Кафедру")
            {
                window2.label.Content = "Введіть ID кафедри";
                stttring = "DELETE FROM dbo.Кафедри WHERE IDCathedra = '";
                window2.Title = "Видалити кафедру";
                window2.Show();
            }
            else if (DeleteCombobox.Text == "Предмет")
            {
                window2.label.Content = "Введіть ID предмета";
                stttring = "DELETE FROM dbo.Предмети WHERE IDSubject = '";
                window2.Title = "Видалити предмет";
                window2.Show();
            }
            else if (DeleteCombobox.Text == "Оцінку")
            {
                window4.label1.Content = "Введіть екзаменаційний лист абітурієнта";
                window4.label2.Content = "Введіть ID предмету";
                
                window4.Title = "Видалити оцінку";
                window4.Show();
            }
            else if (DeleteCombobox.Text == "Консультацію")
            {
                window4.label1.Content = "Введіть екзаменаційний лист абітурієнта";
                window4.label2.Content = "Введіть ID предмету";

                window4.Title = "Видалити консультацію";
                window4.Show();
            }
            else if (DeleteCombobox.Text == "Екзамен")
            {
                window4.label1.Content = "Введіть ID групи";
                window4.label2.Content = "Введіть ID предмету";

                window4.Title = "Видалити Екзамен";
                window4.Show();
            }
            
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            
            if (UpdateCombobox.Text == "Абітурієнта")
            {
                window1.Title = "Оновити абітуріента";
                window1.Button.Content = "Оновити";

                window1.Show();
            }
            else if (UpdateCombobox.Text == "Групу")
            {
                window1.Title = "Оновити групу";
                window1.label1.Content = "ID групи";
                window1.label2.Content = "Ім'я групи";
                window1.label3.Content = "ІD потоку";
                window1.Button.Content = "Оновити";
                window1.label4.Content = "";
                window1.label5.Content = "";
                window1.label6.Content = "";
                window1.label7.Content = "";
                window1.label8.Content = "";
                window1.label9.Content = "";
                window1.Tb4.IsEnabled = false;
                window1.Tb5.IsEnabled = false;
                window1.Tb6.IsEnabled = false;
                window1.Tb7.IsEnabled = false;
                window1.Tb8.IsEnabled = false;
                window1.Tb9.IsEnabled = false;
                window1.Show();
            }
            else if (UpdateCombobox.Text == "Поток")
            {
                window1.Title = "Оновити поток";
                window1.label1.Content = "ID потоку";
                window1.label2.Content = "Ім'я потоку";
                window1.label3.Content = "ІD кафедри";
                window1.Button.Content = "Оновити";
                window1.label4.Content = "";
                window1.label5.Content = "";
                window1.label6.Content = "";
                window1.label7.Content = "";
                window1.label8.Content = "";
                window1.label9.Content = "";
                window1.Tb4.IsEnabled = false;
                window1.Tb5.IsEnabled = false;
                window1.Tb6.IsEnabled = false;
                window1.Tb7.IsEnabled = false;
                window1.Tb8.IsEnabled = false;
                window1.Tb9.IsEnabled = false;
                window1.Show();
            }
            else if (UpdateCombobox.Text == "Кафедру")
            {
                window1.Title = "Оновити кафедру";
                window1.label1.Content = "ID кафедри";
                window1.label2.Content = "Ім'я кафедри";
                window1.label3.Content = "ІD факультету";
                window1.Button.Content = "Оновити";
                window1.label4.Content = "";
                window1.label5.Content = "";
                window1.label6.Content = "";
                window1.label7.Content = "";
                window1.label8.Content = "";
                window1.label9.Content = "";
                window1.Tb4.IsEnabled = false;
                window1.Tb5.IsEnabled = false;
                window1.Tb6.IsEnabled = false;
                window1.Tb7.IsEnabled = false;
                window1.Tb8.IsEnabled = false;
                window1.Tb9.IsEnabled = false;

                window1.Show();
            }
            else if (UpdateCombobox.Text == "Факультет")
            {
                window1.Title = "Оновити факультет";
                window1.label1.Content = "ID факультету";
                window1.label2.Content = "Ім'я факультету";
                window1.label3.Content = "";
                window1.Button.Content = "Оновити";
                window1.label4.Content = "";
                window1.label5.Content = "";
                window1.label6.Content = "";
                window1.label7.Content = "";
                window1.label8.Content = "";
                window1.label9.Content = "";
                window1.Tb3.IsEnabled = false;
                window1.Tb4.IsEnabled = false;
                window1.Tb5.IsEnabled = false;
                window1.Tb6.IsEnabled = false;
                window1.Tb7.IsEnabled = false;
                window1.Tb8.IsEnabled = false;
                window1.Tb9.IsEnabled = false;
                window1.Show();
            }
            else if (UpdateCombobox.Text == "Оцінку")
            {
                window1.Title = "Оновити оцінку";
                window1.label1.Content = "ID студента";
                window1.label2.Content = "ID прдемета";
                window1.label3.Content = "Оцінка";
                window1.Button.Content = "Оновити";
                window1.label4.Content = "";
                window1.label5.Content = "";
                window1.label6.Content = "";
                window1.label7.Content = "";
                window1.label8.Content = "";
                window1.label9.Content = "";
                window1.Tb4.IsEnabled = false;
                window1.Tb5.IsEnabled = false;
                window1.Tb6.IsEnabled = false;
                window1.Tb7.IsEnabled = false;
                window1.Tb8.IsEnabled = false;
                window1.Tb9.IsEnabled = false;
                window1.Show();
            }
            else if (UpdateCombobox.Text == "Консультацію")
            {
                window1.Title = "Оновити консультацію";
                window1.label1.Content = "ID студента";
                window1.label2.Content = "Дата";
                window1.label3.Content = "Аудіторія";
                window1.Button.Content = "Оновити";
                window1.label4.Content = "ID предмету";
                window1.label5.Content = "";
                window1.label6.Content = "";
                window1.label7.Content = "";
                window1.label8.Content = "";
                window1.label9.Content = "";

                window1.Tb5.IsEnabled = false;
                window1.Tb6.IsEnabled = false;
                window1.Tb7.IsEnabled = false;
                window1.Tb8.IsEnabled = false;
                window1.Tb9.IsEnabled = false;
                window1.Show();
            }
            else if (UpdateCombobox.Text == "Екзамен")
            {
                window1.Title = "Оновити екзамен";
                window1.label1.Content = "ID групи";
                window1.label2.Content = "ID предмету";
                window1.label3.Content = "Дата";
                window1.Button.Content = "Оновити";
                window1.label4.Content = "Аудиторія";
                window1.label5.Content = "";
                window1.label6.Content = "";
                window1.label7.Content = "";
                window1.label8.Content = "";
                window1.label9.Content = "";
                
                window1.Tb5.IsEnabled = false;
                window1.Tb6.IsEnabled = false;
                window1.Tb7.IsEnabled = false;
                window1.Tb8.IsEnabled = false;
                window1.Tb9.IsEnabled = false;
                window1.Show();
            }
            else if (UpdateCombobox.Text == "Предмет")
            {
                window1.Title = "Оновити предмет";
                window1.label1.Content = "ID предмету";
                window1.label2.Content = "Ім'я предмету";
                window1.label3.Content = "";
                window1.Button.Content = "Оновити";
                window1.label4.Content = "";
                window1.label5.Content = "";
                window1.label6.Content = "";
                window1.label7.Content = "";
                window1.label8.Content = "";
                window1.label9.Content = "";
                window1.Tb3.IsEnabled = false;
                window1.Tb4.IsEnabled = false;
                window1.Tb5.IsEnabled = false;
                window1.Tb6.IsEnabled = false;
                window1.Tb7.IsEnabled = false;
                window1.Tb8.IsEnabled = false;
                window1.Tb9.IsEnabled = false;
                window1.Show();
            }
        }
    }
}
