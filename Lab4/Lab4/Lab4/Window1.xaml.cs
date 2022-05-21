using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        
        public Window1()
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
                if (Title == "Оновити абітуріента")
                {
                    if(Tb2.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Абітуріенти SET Surname = '" + Tb2.Text + "' WHERE ExamList = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb3.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Абітуріенти SET Name = '" + Tb3.Text + "' WHERE ExamList = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb4.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Абітуріенти SET SecName = '" + Tb4.Text + "' WHERE ExamList = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb5.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Абітуріенти SET PassportID = '" + Tb5.Text + "' WHERE ExamList = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb6.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Абітуріенти SET Medal = '" + Tb6.Text + "' WHERE ExamList = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb7.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Абітуріенти SET GroupID = '" + Tb7.Text + "' WHERE ExamList = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb8.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Абітуріенти SET School = '" + Tb8.Text + "' WHERE ExamList = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb9.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Абітуріенти SET Finished = '" + Tb9.Text + "' WHERE ExamList = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }

                }
                else if (Title == "Оновити групу")
                {
                    if (Tb2.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Групи SET GroupName = '" + Tb2.Text + "' WHERE IDGroup = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb3.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Групи SET IDFlow = '" + Tb2.Text + "' WHERE IDGroup = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                }
                else if (Title == "Оновити поток")
                {
                    if (Tb2.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Потоки SET FlowName = '" + Tb2.Text + "' WHERE IDFlow = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb3.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Потоки SET IDCathedra = '" + Tb2.Text + "' WHERE IDFlow = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                }
                else if (Title == "Оновити кафедру")
                {
                    if (Tb2.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Кафедри SET CathedraName = '" + Tb2.Text + "' WHERE IDCathedra = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb3.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Кафедри SET IDFacultative = '" + Tb2.Text + "' WHERE IDCathedra = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                }
                else if (Title == "Оновити факультет")
                {
                    if (Tb2.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Факультети SET FacultativeName = '" + Tb2.Text + "' WHERE IDFacultative = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    
                }
                else if (Title == "Оновити екзамен")
                {
                    if (Tb3.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Екзамени SET Date = '" + Tb3.Text + "' WHERE IDGroup = '" + Tb1.Text + "' AND IDSubject = '" + Tb2.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    if (Tb4.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Екзамени SET Auditory = '" + Tb4.Text + "' WHERE IDGroup = '" + Tb1.Text + "' AND IDSubject = '" + Tb2.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }

                }
                else if (Title == "Оновити оцінку")
                {
                    if (Tb3.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Студенти_Оцінки SET Mark = '" + Tb3.Text + "' WHERE IDStudent = '" + Tb1.Text + "' AND IDSubject = '" + Tb2.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    

                }
                else if (Title == "Оновити предмет")
                {
                    if (Tb2.Text != "")
                    {
                        command = new SqlCommand("UPDATE dbo.Предмети SET SubjectName = '" + Tb2.Text + "' WHERE IDSubject = '" + Tb1.Text + "'", connection);
                        command.ExecuteNonQuery();
                    }
                    

                }
                else
                {
                    command = new SqlCommand("INSERT INTO dbo.Абітуріенти (ExamList, Surname, Name, SecName, PassportID, Medal, GroupID, School, Finished) VALUES('" + Tb1.Text + "','" + Tb2.Text + "','" + Tb3.Text + "','" + Tb4.Text + "','" + Tb5.Text + "','" + Tb6.Text + "','" + Tb7.Text + "','" + Tb8.Text + "','" + Tb9.Text + "' )", connection);
                    command.ExecuteNonQuery();
                }
                
                connection.Close();
                this.Close();
            }
            catch(Exception h)
            {
                MessageBox.Show(h.Message);
            }
        }
    }
}
