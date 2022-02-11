using System;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter writer = new StreamWriter("text.txt", true);
            string text = TB1.Text;
            writer.WriteLine(text);
            writer.Close();
            TB1.Text = "";

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string id = TB2.Text, final = "";
            StreamReader reader = new StreamReader("text.txt");
            
            while (true)
            {
                if (reader.EndOfStream)
                    break;
                string line = reader.ReadLine();
                string[] arr = line.Split(' ');
                string currentid = arr[0];
                if (currentid != id)
                    final += $"{line}\n";
            }
            reader.Close();
            StreamWriter writer = new StreamWriter("text.txt");
            writer.WriteLine(final);
            writer.Close();
            TB2.Text = "";
        }

        

        private void Read_Click_1(object sender, RoutedEventArgs e)
        {
            StreamReader reader = new StreamReader("text.txt");
            string fileText = reader.ReadToEnd();
            reader.Close();
            Info.Content = fileText;
        }
    }
}
