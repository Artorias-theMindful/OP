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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
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

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "1";
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "2";
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "3";
        }

        private void b0_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "0";
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "4";
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "5";
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "6";
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "7";
        }

        private void b8_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "8";
        }

        private void b9_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += "9";
        }

        private void bb_Click(object sender, RoutedEventArgs e)
        {
            TB.Text += ",";
        }

        private void b44_Click(object sender, RoutedEventArgs e)
        {

            if (prev.Text.Length > 0)
                if (prev.Text[prev.Text.Length - 1] == '/' || prev.Text[prev.Text.Length - 1] == '-' || prev.Text[prev.Text.Length - 1] == '+' || prev.Text[prev.Text.Length - 1] == 'X')
                {
                    calculate();
                }
            prev.Text = TB.Text + " +";
            TB.Text = "";
        }

        private void b33_Click(object sender, RoutedEventArgs e)
        {
            if(prev.Text.Length > 0)
                if (prev.Text[prev.Text.Length - 1] == '/' || prev.Text[prev.Text.Length - 1] == '-' || prev.Text[prev.Text.Length - 1] == '+' || prev.Text[prev.Text.Length - 1] == 'X')
                {
                    calculate();
                }
            prev.Text = TB.Text + " -";
            TB.Text = "";
        }

        private void b22_Click(object sender, RoutedEventArgs e)
        {
            if (prev.Text.Length > 0)
                if (prev.Text[prev.Text.Length - 1] == '/' || prev.Text[prev.Text.Length - 1] == '-' || prev.Text[prev.Text.Length - 1] == '+' || prev.Text[prev.Text.Length - 1] == 'X')
                {
                    calculate();
                }
            prev.Text = TB.Text + " X";
            TB.Text = "";
        }

        private void b11_Click(object sender, RoutedEventArgs e)
        {
            if (prev.Text.Length > 0)
                if (prev.Text[prev.Text.Length - 1] == '/' || prev.Text[prev.Text.Length - 1] == '-' || prev.Text[prev.Text.Length - 1] == '+' || prev.Text[prev.Text.Length - 1] == 'X')
                {
                    calculate();
                }
            prev.Text = TB.Text + " /";
            TB.Text = "";
        }

        private void bbb_Click(object sender, RoutedEventArgs e)
        {
            if(TB.Text.Length > 0)
                TB.Text = TB.Text.Remove(TB.Text.Length - 1);
        }

        private void c_Click(object sender, RoutedEventArgs e)
        {
            TB.Text = "";
            prev.Text = "";
            
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            calculate();

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
    }
}
