using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using LLab2;

namespace LLab2
{
    class Win1
    {
        static private Label label1 = new Label();
        static private TextBox TB1 = new TextBox();
        static private Button add = new Button();
        static private Label label2 = new Label();
        static private TextBox TB2 = new TextBox();
        static private Button delete = new Button();
        static private Button read = new Button();
        static private Button goToMain = new Button();
        static private Window window = new Window();
        static private Grid grid = new Grid();
        static private Label info = new Label();
        static private Window MainWindow;
        public Win1(Window myMainWindow)
        {
            MainWindow = myMainWindow;
            window.Title = "Window 1";
            window.ResizeMode = ResizeMode.NoResize;
            window.Height = 450;
            window.Width = 800;


            grid.Width = 800;
            grid.Height = 450;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.ShowGridLines = true;



            label1.Content = "Додати студента";
            label1.Margin = new Thickness(10, 68, 0, 0);

            grid.Children.Add(label1);

            TB1.Height = 23;
            TB1.Width = 222;
            TB1.VerticalAlignment = VerticalAlignment.Top;
            TB1.HorizontalAlignment = HorizontalAlignment.Left;
            TB1.Margin = new Thickness(10, 101, 0, 0);

            grid.Children.Add(TB1);

            add.Content = "Додати";
            add.VerticalAlignment = VerticalAlignment.Top;
            add.HorizontalAlignment = HorizontalAlignment.Left;
            add.Height = 23;
            add.Width = 86;
            add.Margin = new Thickness(253, 101, 0, 0);
            add.Click += Add_Click;

            grid.Children.Add(add);

            label2.Content = "Видалити за номером";
            label2.HorizontalAlignment = HorizontalAlignment.Left;
            label2.VerticalAlignment = VerticalAlignment.Top;
            label2.Margin = new Thickness(10, 159, 0, 0);

            grid.Children.Add(label2);

            TB2.HorizontalAlignment = HorizontalAlignment.Left;
            TB2.Height = 23;
            TB2.Margin = new Thickness(10, 192, 0, 0);
            TB2.VerticalAlignment = VerticalAlignment.Top;
            TB2.Width = 222;

            grid.Children.Add(TB2);

            delete.Content = "Видалити";
            delete.HorizontalAlignment = HorizontalAlignment.Left;
            delete.VerticalAlignment = VerticalAlignment.Top;
            delete.Height = 23;
            delete.Width = 86;
            delete.Margin = new Thickness(253, 192, 0, 0);
            delete.Click += Delete_Click;

            grid.Children.Add(delete);

            read.Content = "Прочитати дані";
            read.HorizontalAlignment = HorizontalAlignment.Left;
            read.VerticalAlignment = VerticalAlignment.Top;
            read.Height = 30;
            read.Width = 145;
            read.Margin = new Thickness(10, 264, 0, 0);
            read.Click += Read_Click;

            grid.Children.Add(read);

            goToMain.Content = "До головного вікна";
            goToMain.HorizontalAlignment = HorizontalAlignment.Left;
            goToMain.VerticalAlignment = VerticalAlignment.Top;
            goToMain.Height = 74;
            goToMain.Width = 289;
            goToMain.Margin = new Thickness(495, 336, 0, 0);
            goToMain.Click += GoToMain_Click;

            grid.Children.Add(goToMain);

            info.Content = "";
            info.HorizontalAlignment = HorizontalAlignment.Left;
            info.VerticalAlignment = VerticalAlignment.Top;
            info.Margin = new Thickness(10, 299, 0, 0);
            info.Height = 111;
            info.Width = 480;

            grid.Children.Add(info);

            window.Content = grid;
            window.Show();

        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            StreamReader reader = new StreamReader("text.txt");
            string fileText = reader.ReadToEnd();
            reader.Close();
            info.Content = fileText;
        }

        public void Show()
        {
            window.Show();
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
        private void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            window.Hide();
            MainWindow.Show();
            

        }
    }
}
