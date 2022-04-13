using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Pract2;
using static System.Math;
using System.Linq;
namespace Lab2
{
    /// <summary>
    /// Interaction logic for WindowTeach.xaml
    /// </summary>
    public partial class WindowTeach : Window
    {
        static int attempts = 0;
        public void WriteInFile(string filePath, string text, bool append)
        {
            StreamWriter streamWriter = new StreamWriter(filePath, append);
            streamWriter.Write(text);
            streamWriter.Close();
        }
        private double MatSpodiv(int[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum / arr.Length;
        }
        private double Dispersion1(int[] arr)
        {
            double totalSum1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                totalSum1 += Pow(arr[i], 2);
            }
            totalSum1 = totalSum1 / (arr.Length - 1);
            double totalSum2 = Pow(MatSpodiv(arr), 2);
            return totalSum1 - totalSum2;
        }
        private int[][] GetToothArr(int[,] arr)
        {
            int[][] curArr = new int[arr.GetLength(0)][];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                curArr[i] = new int[arr.GetLength(1)];
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    curArr[i][j] = arr[i, j];
                }
            }
            return curArr;
        }
        public bool OKline(int[,] arr, string file1, string file2)
        {
            bool hasOKline = false;
            int OK = 0;
            int[][] toothArr = GetToothArr(arr);
            for (int i = 0; i < toothArr.Length; i++)
            {
                for (int j = 0; j < toothArr[i].Length; j++)
                {
                    int indexToRemove = j;
                    int[] tmpLine = toothArr[i].Where((source, index) => index != indexToRemove).ToArray();
                    double matSpod = MatSpodiv(tmpLine);
                    double disp = Dispersion1(tmpLine);
                    double standardDeviation = Sqrt(disp);
                    double t_p = Abs((toothArr[i][j] - matSpod) / (standardDeviation));
                    double t_T = 2.5;
                    if (t_p > t_T)
                    {
                        toothArr[i] = toothArr[i].Where((source, index) => index != indexToRemove).ToArray();
                        OK++;
                    }
                }
                if (OK == 0)
                {
                    hasOKline = true;
                }
            }
            if (!hasOKline)
            {
                return false;
            }
            
            string str1 = "";
            for (int i = 0; i < toothArr.Length; i++)
            {
                for (int j = 0; j < toothArr[i].Length; j++)
                {
                    str1 += $"{toothArr[i][j]}\t";
                }
                str1 += "\n";
            }
            WriteInFile(file1, str1, false);

            string str2 = "";
            for (int i = 0; i < toothArr.Length; i++)
            {
                str2 += $"Математичне сподівання №{i + 1} = {MatSpodiv(toothArr[i])}\n";
                str2 += $"Математична дисперсія №{i + 1} = {Dispersion1(toothArr[i])}\n\n";
            }
            WriteInFile(file2, str2, false);
            return true;
        }
        
        public WindowTeach()
        {
            InitializeComponent();
            attempts = GetAttempts();
            TextBlock1.Text = attempts.ToString();
            WriteInFile("__Data 1__.txt", "", false);
        }
        private void TimeService()
        {
            int localCounter = 0;
            int[,] arr = new int[GetAttempts(), TheWord.Text.Length - 1];
            StreamReader read = new StreamReader("__Data 1__.txt");
            while (!read.EndOfStream)
            {
                string line = read.ReadLine();
                string[] splittedLine = line.Split("\t");
                for (int j = 0; j < splittedLine.Length - 1; j++)
                {
                    arr[localCounter, j] = int.Parse(splittedLine[j]);
                }
                localCounter++;
            }
            read.Close();
            bool hasValuableLine = OKline(arr, "__Еталонні значення 1__.txt", "__Мат дисперсія та сподівання 1__.txt");
            if (!hasValuableLine)
            {
                WindowForNotifications windowForNotifications = new WindowForNotifications();
                windowForNotifications.Show();
            }
        }
        private int GetAttempts()
        {
            int numOfAttempts = 1;
            if (Combobox1 != null)
            {
                ComboBoxItem comboBoxItem = (ComboBoxItem)Combobox1.SelectedItem;
                string selectedText = comboBoxItem.Content.ToString();
                numOfAttempts = int.Parse(selectedText);
            }
            return numOfAttempts;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Hide();
            mainWindow.Show();
        }

        private void InputTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InputTextBox.Text = "";
            counter = 0;
            WriteInFile("__Data 1__.txt", "", false);
        }

        private void Combobox1_DropDownClosed(object sender, EventArgs e)
        {
            attempts = GetAttempts();
            TextBlock1.Text = attempts.ToString();
        }
        private void DecreaseAttempts()
        {
            attempts--;
            if (attempts == 0)
            {
                InputTextBox.Background = Brushes.Red;
                InputTextBox.IsEnabled = false;
                TimeService();
            }
            TextBlock1.Text = attempts.ToString();
        }
        private void DeleteLineInFile()
        {
            StreamReader streamReader = new StreamReader("__Data 1__.txt");
            string[] splittedText = streamReader.ReadToEnd().Split("\n");
            string editedData = "";
            for (int i = 0; i < splittedText.Length - 1; i++)
            {
                editedData += splittedText[i];
                editedData += "\n";
            }
            streamReader.Close();
            WriteInFile("__Data 1__.txt", editedData, false);
        }

        private void InputTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (InputTextBox.Text.Length >= TheWord.Text.Length)
            {
                if (InputTextBox.Text == TheWord.Text)
                {
                    DecreaseAttempts();
                    WriteInFile("__Data 1__.txt", "\n", true);
                    InputTextBox.Text = "";
                }
                else
                {
                    DeleteLineInFile();
                    InputTextBox.Text = "";
                }
                counter = 0;
            }
        }
        static int counter = 0;
        static Stopwatch stopwatch = new Stopwatch();
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (counter == 0)
            {
                stopwatch.Start();
            }
            else if (counter == 12)
            {
                
                TimeSpan time = stopwatch.Elapsed;
                WriteInFile("__Data 1__.txt", time.Milliseconds.ToString() + "\t", true);
                stopwatch.Stop();
            }
            else
            {
                
                TimeSpan time = stopwatch.Elapsed;
                WriteInFile("__Data 1__.txt", time.Milliseconds.ToString() + "\t", true);
                stopwatch.Restart();
            }
            counter++;
        }
    }
}
