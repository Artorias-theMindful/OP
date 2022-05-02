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
    class Win2
    {
        static private ComboBox[] comboBoxes = new ComboBox[9];
        static private Window MainWindow;
        static private Window window = new Window();
        static private Button goToMain = new Button();
        static private Grid grid = new Grid();
        static private List<int> list = new List<int>();
        static private bool s = false;
        static private int count = 0;
        public Win2(Window myMainWindow)
        {
            MainWindow = myMainWindow;
            window.Title = "Window 2";
            window.ResizeMode = ResizeMode.NoResize;
            window.Height = 450;
            window.Width = 800;
            Make_CB();
            goToMain.Content = "До головного вікна";
            goToMain.HorizontalAlignment = HorizontalAlignment.Left;
            goToMain.VerticalAlignment = VerticalAlignment.Top;
            goToMain.Height = 74;
            goToMain.Width = 289;
            goToMain.Margin = new Thickness(495, 336, 0, 0);
            goToMain.Click += GoToMain_Click;
            grid.Children.Add(goToMain);
        }
        private void Make_CB()
        {
            int x = 40, y = 70;
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    comboBoxes[(int)(3 * j) + i] = new ComboBox();
                    comboBoxes[(int)(3 * j) + i].Items.Add("X");

                    comboBoxes[(int)(3 * j) + i].Width = 85;
                    comboBoxes[(int)(3 * j) + i].Height = 62;
                    comboBoxes[(int)(3 * j) + i].HorizontalAlignment = HorizontalAlignment.Left;
                    comboBoxes[(int)(3 * j) + i].VerticalAlignment = VerticalAlignment.Top;
                    comboBoxes[(int)(3 * j) + i].Margin = new Thickness(x, y, 0, 0);
                    comboBoxes[(int)(3 * j) + i].SelectionChanged += Selection_Changed;
                    x += 90;
                    
                    
                    
                    grid.Children.Add(comboBoxes[(int)(3 * j) + i]);
                }
                x = 40;
                y += 70;

            }
            window.Content = grid;
            window.Show();
        }
        public void Show()
        {
            window.Show();
        }
        private void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            window.Hide();
            MainWindow.Show();


        }
        private void Selection_Changed(object sender, RoutedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            CB.IsEnabled = false;
            
            
            int a = ((int)CB.Margin.Left - 40)/90;
            int b = ((int)CB.Margin.Top - 70) / 70;
            list.Add(3 * a + b);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(!list.Contains(3 * j + i))
                    {
                        
                        if (s)
                        {

                            comboBoxes[(int)(3 * j) + i].Items.Remove("O");
                            comboBoxes[(int)(3 * j) + i].Items.Add("X");
                        }
                        else
                        {

                            comboBoxes[(int)(3 * j) + i].Items.Remove("X");
                            comboBoxes[(int)(3 * j) + i].Items.Add("O");
                        }
                    }
                    
                }

            }
            if (count % 2 == 0)
            {
                s = true;
            }
            else
            {
                s = false;
            }
                
            count++;
            window.Content = grid;
        }
    }
}
