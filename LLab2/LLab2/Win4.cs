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
    class Win4
    {
        static private Window MainWindow;
        static private Window window = new Window();
        static private Grid grid = new Grid();
        static private Label label = new Label();
        static private Button main = new Button();
        public Win4(Window myMainWindow)
        {
            MainWindow = myMainWindow;
            window.Title = "Window 4";
            window.ResizeMode = ResizeMode.NoResize;
            window.Height = 450;
            window.Width = 800;
            label.Content = "Лунев Артем, КП-11, 2022 рік";
            label.Margin = new Thickness(10, 68, 0, 0);
            
            grid.Children.Add(label);
            main.Content = "До головного вікна";
            main.HorizontalAlignment = HorizontalAlignment.Left;
            main.Margin = new Thickness(495, 336, 0, 0);
            main.VerticalAlignment = VerticalAlignment.Top;
            main.Width = 289;
            main.Height = 74;
            main.Click += Button_main;
            grid.Children.Add(main);
            window.Content = grid;
            window.Show();
        }
        private void Button_main(object sender, RoutedEventArgs e)
        {
            window.Hide();
            MainWindow.Show();
        }
        public void Show()
        {
            window.Show();
        }
    }
}
