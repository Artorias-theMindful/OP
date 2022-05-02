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
    class Win3
    {
        
        static private Window MainWindow;
        static private Window window = new Window();
        static private Grid grid = new Grid();

        static private TextBox TB = new TextBox();
        static private TextBox prev = new TextBox();

        static private Button main = new Button();
        static private Button b1 = new Button();
        static private Button b2 = new Button();
        static private Button b3 = new Button();
        static private Button b4 = new Button();
        static private Button b5 = new Button();
        static private Button b6 = new Button();
        static private Button b7 = new Button();
        static private Button b8 = new Button();
        static private Button b9 = new Button();
        static private Button b0 = new Button();
        static private Button b = new Button();
        static private Button bb = new Button();
        static private Button c = new Button();
        static private Button bbb = new Button();
        static private Button b11 = new Button();
        static private Button b12 = new Button();
        static private Button b13 = new Button();
        static private Button b14 = new Button();
        
        public Win3(Window myMainWindow)
        {
            window.Title = "Window 2";
            window.ResizeMode = ResizeMode.NoResize;
            window.Height = 450;
            window.Width = 800;

            int x = 118, y = 152;
            b.Content = "=";
            b.HorizontalAlignment = HorizontalAlignment.Left;
            b.Margin = new Thickness(x, y, 0, 0);
            b.VerticalAlignment = VerticalAlignment.Top;
            b.Width = 56;
            b.Height = 46;
            b.Click += Button_b;
            MainWindow = myMainWindow;
            x += 61;

            c.Content = "C";
            c.HorizontalAlignment = HorizontalAlignment.Left;
            c.Margin = new Thickness(x, y, 0, 0);
            c.VerticalAlignment = VerticalAlignment.Top;
            c.Width = 56;
            c.Height = 46;
            c.Click += Button_c;

            x += 61;

            bbb.Content = "<|";
            bbb.HorizontalAlignment = HorizontalAlignment.Left;
            bbb.Margin = new Thickness(x, y, 0, 0);
            bbb.VerticalAlignment = VerticalAlignment.Top;
            bbb.Width = 56;
            bbb.Height = 46;
            bbb.Click += Button_bbb;

            x -= 61;
            x -= 61;
            x -= 61;
            y += 50;

            b7.Content = "7";
            b7.HorizontalAlignment = HorizontalAlignment.Left;
            b7.Margin = new Thickness(x, y, 0, 0);
            b7.VerticalAlignment = VerticalAlignment.Top;
            b7.Width = 56;
            b7.Height = 46;
            b7.Click += Button_7;

            x += 61;

            b8.Content = "8";
            b8.HorizontalAlignment = HorizontalAlignment.Left;
            b8.Margin = new Thickness(x, y, 0, 0);
            b8.VerticalAlignment = VerticalAlignment.Top;
            b8.Width = 56;
            b8.Height = 46;
            b8.Click += Button_8;

            x += 61;

            b9.Content = "9";
            b9.HorizontalAlignment = HorizontalAlignment.Left;
            b9.Margin = new Thickness(x, y, 0, 0);
            b9.VerticalAlignment = VerticalAlignment.Top;
            b9.Width = 56;
            b9.Height = 46;
            b9.Click += Button_9;

            x += 61;

            b11.Content = "/";
            b11.HorizontalAlignment = HorizontalAlignment.Left;
            b11.Margin = new Thickness(x, y, 0, 0);
            b11.VerticalAlignment = VerticalAlignment.Top;
            b11.Width = 56;
            b11.Height = 46;
            b11.Click += Button_11;

            x = 57;
            y += 50;

            b4.Content = "4";
            b4.HorizontalAlignment = HorizontalAlignment.Left;
            b4.Margin = new Thickness(x, y, 0, 0);
            b4.VerticalAlignment = VerticalAlignment.Top;
            b4.Width = 56;
            b4.Height = 46;
            b4.Click += Button_4;

            x += 61;

            b5.Content = "5";
            b5.HorizontalAlignment = HorizontalAlignment.Left;
            b5.Margin = new Thickness(x, y, 0, 0);
            b5.VerticalAlignment = VerticalAlignment.Top;
            b5.Width = 56;
            b5.Height = 46;
            b5.Click += Button_5;

            x += 61;

            b6.Content = "6";
            b6.HorizontalAlignment = HorizontalAlignment.Left;
            b6.Margin = new Thickness(x, y, 0, 0);
            b6.VerticalAlignment = VerticalAlignment.Top;
            b6.Width = 56;
            b6.Height = 46;
            b6.Click += Button_6;

            x += 61;

            b12.Content = "X";
            b12.HorizontalAlignment = HorizontalAlignment.Left;
            b12.Margin = new Thickness(x, y, 0, 0);
            b12.VerticalAlignment = VerticalAlignment.Top;
            b12.Width = 56;
            b12.Height = 46;
            b12.Click += Button_12;

            x = 57;
            y += 50;

            b1.Content = "1";
            b1.HorizontalAlignment = HorizontalAlignment.Left;
            b1.Margin = new Thickness(x, y, 0, 0);
            b1.VerticalAlignment = VerticalAlignment.Top;
            b1.Width = 56;
            b1.Height = 46;
            b1.Click += Button_1;

            x += 61;

            b2.Content = "2";
            b2.HorizontalAlignment = HorizontalAlignment.Left;
            b2.Margin = new Thickness(x, y, 0, 0);
            b2.VerticalAlignment = VerticalAlignment.Top;
            b2.Width = 56;
            b2.Height = 46;
            b2.Click += Button_2;

            x += 61;

            b3.Content = "3";
            b3.HorizontalAlignment = HorizontalAlignment.Left;
            b3.Margin = new Thickness(x, y, 0, 0);
            b3.VerticalAlignment = VerticalAlignment.Top;
            b3.Width = 56;
            b3.Height = 46;
            b3.Click += Button_3;

            x += 61;

            b13.Content = "-";
            b13.HorizontalAlignment = HorizontalAlignment.Left;
            b13.Margin = new Thickness(x, y, 0, 0);
            b13.VerticalAlignment = VerticalAlignment.Top;
            b13.Width = 56;
            b13.Height = 46;
            b13.Click += Button_13;

            x = 118;
            y = 352;

            b0.Content = "0";
            b0.HorizontalAlignment = HorizontalAlignment.Left;
            b0.Margin = new Thickness(x, y, 0, 0);
            b0.VerticalAlignment = VerticalAlignment.Top;
            b0.Width = 56;
            b0.Height = 46;
            b0.Click += Button_0;

            x += 61;

            bb.Content = ",";
            bb.HorizontalAlignment = HorizontalAlignment.Left;
            bb.Margin = new Thickness(x, y, 0, 0);
            bb.VerticalAlignment = VerticalAlignment.Top;
            bb.Width = 56;
            bb.Height = 46;
            bb.Click += Button_bb;

            x += 61;

            b14.Content = "+";
            b14.HorizontalAlignment = HorizontalAlignment.Left;
            b14.Margin = new Thickness(x, y, 0, 0);
            b14.VerticalAlignment = VerticalAlignment.Top;
            b14.Width = 56;
            b14.Height = 46;
            b14.Click += Button_14;

            TB.Margin = new Thickness(57, 101, 0, 0);
            TB.Height = 46;
            TB.Width = 365;
            TB.HorizontalAlignment = HorizontalAlignment.Left;
            TB.VerticalAlignment = VerticalAlignment.Top;

            prev.Margin = new Thickness(57, 72, 0, 0);
            prev.Height = 23;
            prev.Width = 120;
            prev.HorizontalAlignment = HorizontalAlignment.Left;
            prev.VerticalAlignment = VerticalAlignment.Top;

            main.Content = "До головного вікна";
            main.HorizontalAlignment = HorizontalAlignment.Left;
            main.Margin = new Thickness(495, 336, 0, 0);
            main.VerticalAlignment = VerticalAlignment.Top;
            main.Width = 289;
            main.Height = 74;
            main.Click += Button_main;
            TB.Text = "";
            prev.Text = "";

            grid.Children.Add(b);
            grid.Children.Add(bb);
            grid.Children.Add(bbb);
            grid.Children.Add(b1);
            grid.Children.Add(b2);
            grid.Children.Add(b3);
            grid.Children.Add(b4);
            grid.Children.Add(b5);
            grid.Children.Add(b6);
            grid.Children.Add(b7);
            grid.Children.Add(b8);
            grid.Children.Add(b9);
            grid.Children.Add(b0);
            grid.Children.Add(b11);
            grid.Children.Add(b12);
            grid.Children.Add(b13);
            grid.Children.Add(b14);
            grid.Children.Add(c);
            grid.Children.Add(main);
            grid.Children.Add(TB);
            grid.Children.Add(prev);
            window.Content = grid;
            window.Show();
        }
        
        private void Button_1(object sender, RoutedEventArgs e)
        {
            TB.Text += "1";
        }
        private void Button_2(object sender, RoutedEventArgs e)
        {
            TB.Text += "2";
        }
        private void Button_3(object sender, RoutedEventArgs e)
        {
            TB.Text += "3";
        }
        private void Button_4(object sender, RoutedEventArgs e)
        {
            TB.Text += "4";
        }
        private void Button_5(object sender, RoutedEventArgs e)
        {
            TB.Text += "5";
        }
        private void Button_6(object sender, RoutedEventArgs e)
        {
            TB.Text += "6";
        }
        private void Button_7(object sender, RoutedEventArgs e)
        {
            TB.Text += "7";
        }
        private void Button_8(object sender, RoutedEventArgs e)
        {
            TB.Text += "8";
        }
        private void Button_9(object sender, RoutedEventArgs e)
        {
            TB.Text += "9";
        }
        private void Button_0(object sender, RoutedEventArgs e)
        {
            TB.Text += "0";
        }
        private void Button_b(object sender, RoutedEventArgs e)
        {
            calculate();
        }
        private void Button_bb(object sender, RoutedEventArgs e)
        {
            TB.Text += ",";
        }
        private void Button_c(object sender, RoutedEventArgs e)
        {
            TB.Text = "";
            prev.Text = "";
        }
        private void Button_bbb(object sender, RoutedEventArgs e)
        {
            if (TB.Text.Length > 0)
                TB.Text = TB.Text.Remove(TB.Text.Length - 1);
        }
        private void Button_11(object sender, RoutedEventArgs e)
        {
            if (prev.Text.Length > 0)
                if (prev.Text[prev.Text.Length - 1] == '/' || prev.Text[prev.Text.Length - 1] == '-' || prev.Text[prev.Text.Length - 1] == '+' || prev.Text[prev.Text.Length - 1] == 'X')
                {
                    calculate();
                }
            prev.Text = TB.Text + " /";
            TB.Text = "";
        }
        private void Button_12(object sender, RoutedEventArgs e)
        {
            if (prev.Text.Length > 0)
                if (prev.Text[prev.Text.Length - 1] == '/' || prev.Text[prev.Text.Length - 1] == '-' || prev.Text[prev.Text.Length - 1] == '+' || prev.Text[prev.Text.Length - 1] == 'X')
                {
                    calculate();
                }
            prev.Text = TB.Text + " X";
            TB.Text = "";
        }
        private void Button_13(object sender, RoutedEventArgs e)
        {
            if (prev.Text.Length > 0)
                if (prev.Text[prev.Text.Length - 1] == '/' || prev.Text[prev.Text.Length - 1] == '-' || prev.Text[prev.Text.Length - 1] == '+' || prev.Text[prev.Text.Length - 1] == 'X')
                {
                    calculate();
                }
            prev.Text = TB.Text + " -";
            TB.Text = "";
        }
        private void Button_14(object sender, RoutedEventArgs e)
        {
            if (prev.Text.Length > 0)
                if (prev.Text[prev.Text.Length - 1] == '/' || prev.Text[prev.Text.Length - 1] == '-' || prev.Text[prev.Text.Length - 1] == '+' || prev.Text[prev.Text.Length - 1] == 'X')
                {
                    calculate();
                }
            prev.Text = TB.Text + " +";
            TB.Text = "";
        }
        private void Button_main(object sender, RoutedEventArgs e)
        {
            window.Hide();
            MainWindow.Show();
        }
        private void calculate()
        {
            if (prev.Text.Length > 1)
            {
                double b = Convert.ToDouble(TB.Text);
                double a = Convert.ToDouble(prev.Text.Remove(prev.Text.Length - 2));

                if (prev.Text.ToString()[prev.Text.ToString().Length - 1] == '+')
                {
                    TB.Text = $"{a + b}";
                }
                if (prev.Text.ToString()[prev.Text.ToString().Length - 1] == '-')
                {
                    TB.Text = $"{a - b}";
                }
                if (prev.Text.ToString()[prev.Text.ToString().Length - 1] == 'X')
                {
                    TB.Text = $"{a * b}";
                }
                if (prev.Text.ToString()[prev.Text.ToString().Length - 1] == '/')
                {
                    TB.Text = $"{a / b}";
                }

            }
            prev.Text = "";
        }
        public void Show()
        {
            window.Show();
        }
    }
}
