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
using LLab2;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Win1 win1 = null;
        private Win2 win2 = null;
        private Win3 win3 = null;
        private Win4 win4 = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }

        private void ToWin1_Click(object sender, RoutedEventArgs e)
        {
            
            if (win1 is null)
            {

                win1 = new Win1(this);
                
            }
            else
            {
                win1.Show();
            }
            

        }

        private void ToWin2_Click(object sender, RoutedEventArgs e)
        {
            if (win2 is null)
            {

                win2 = new Win2(this);

            }
            else
            {
                win2.Show();
            }
        }

        private void ToWin3_Click(object sender, RoutedEventArgs e)
        {
            if (win3 is null)
            {

                win3 = new Win3(this);

            }
            else
            {
                win3.Show();
            }
        }

        private void ToWin4_Click(object sender, RoutedEventArgs e)
        {
            if (win4 is null)
            {

                win4 = new Win4(this);

            }
            else
            {
                win4.Show();
            }
        }
    }
}
