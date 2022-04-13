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
    /// Interaction logic for WindowCheck.xaml
    /// </summary>
    public partial class WindowCheck : Window
    {
        static int numOfAtttempts = 0;
        static int counter = 0;
        static Stopwatch stopwatch = new Stopwatch();
        public bool check = false;
        public void WriteInFile(string filePath, string text, bool append)
        {
            StreamWriter streamWriter = new StreamWriter(filePath, append);
            streamWriter.Write(text);
            streamWriter.Close();
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
        private double MatSpodiv(int[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum / arr.Length;
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
        public bool GetValuableArray(int[,] arr, string file1, string file2)
        {
            bool hasValuableLine = false;
            int valuableCounter = 0;
            int[][] Arr2 = GetToothArr(arr);
            for (int i = 0; i < Arr2.Length; i++)
            {
                for (int j = 0; j < Arr2[i].Length; j++)
                {
                    int indexToRemove = j;
                    int[] thiss = Arr2[i].Where((source, index) => index != indexToRemove).ToArray();
                    double matSpod = MatSpodiv(thiss);
                    double disp = Dispersion1(thiss);
                    double standardDeviation = Sqrt(disp);
                    double t_p = Abs((Arr2[i][j] - matSpod) / (standardDeviation));

                    double t_T = 2.5;
                    if (t_p > t_T)
                    {
                        Arr2[i] = Arr2[i].Where((source, index) => index != indexToRemove).ToArray();
                        valuableCounter++;
                    }
                }
                if (valuableCounter == 0)
                {
                    hasValuableLine = true;
                }
            }
            if (!hasValuableLine)
            {
                return false;
            }
            
            string str1 = "";
            for (int i = 0; i < Arr2.Length; i++)
            {
                for (int j = 0; j < Arr2[i].Length; j++)
                {
                    str1 += $"{Arr2[i][j]}\t";
                }
                str1 += "\n";
            }
            WriteInFile(file1, str1, false);

            string str2 = "";
            for (int i = 0; i < Arr2.Length; i++)
            {
                str2 += $"Математичне сподівання {i + 1} = {MatSpodiv(Arr2[i])}\n";
                str2 += $"Математична дисперсія {i + 1} = {Dispersion1(Arr2[i])}\n\n";
            }
            WriteInFile(file2, str2, false);
            return true;
        }
        private double Dispersion2(int[] arr)
        {
            double totalSum1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                totalSum1 += Pow(arr[i], 2);
            }
            totalSum1 = totalSum1 / arr.Length;
            double totalSum2 = Pow(MatSpodiv(arr), 2);
            return totalSum1 - totalSum2;
        }

        private double FindFisher(int[] arr1, int[] arr2)
        {
            double disp1 = Dispersion2(arr1);
            double disp2 = Dispersion2(arr2);
            double fisher = Max(Pow(disp1, 2), Pow(disp2, 2)) / Min(Pow(disp1, 2), Pow(disp2, 2));
            return fisher;
        }
        private int GetNumOfValuableAttempts(string file)
        {
            int res = 0;
            StreamReader streamReader = new StreamReader(file);
            string[] text = streamReader.ReadToEnd().Split("\n");
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Length > 1)
                {
                    res++;
                }
            }
            streamReader.Close();
            return res;
        }
        private int[][] GetMeaningToothArr(string source, int attempts)
        {
            StreamReader streamReader = new StreamReader(source);
            int counter = 0;
            int[][] res = new int[attempts][];
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] lineArr = line.Split("\t");
                if (lineArr.Length == 13)
                {
                    res[counter] = new int[12];
                    for (int i = 0; i < 12; i++)
                    {
                        res[counter][i] = int.Parse(lineArr[i]);
                    }
                    counter++;
                }
            }
            streamReader.Close();
            return res;
        }
        public bool AreSimilar()
        {
            int attempts1 = GetNumOfValuableAttempts("__Еталонні значення 1__.txt");
            int attempts2 = GetNumOfValuableAttempts("__Еталонні значення 2__.txt");
            int[][] toothArr1 = GetMeaningToothArr("__Еталонні значення 1__.txt", attempts1);
            int[][] toothArr2 = GetMeaningToothArr("__Еталонні значення 2__.txt", attempts2);
            bool a = true;
            double totalMyFisher = 0;
            double fisherCounter = 0;
            for (int i = 0; i < toothArr1.Length; i++)
            {
                if (toothArr1[i] != null)
                {
                    for (int j = 0; j < toothArr2.Length; j++)
                    {
                        if (toothArr2[j] != null)
                        {
                            double myFisher = FindFisher(toothArr1[i], toothArr2[j]);
                            double fisher = 2.79;
                            totalMyFisher += fisher;
                            fisherCounter++;
                            if (myFisher > fisher)
                            {
                                a = false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return a;
        }
        public WindowCheck()
        {
            InitializeComponent();
            TextBlock1.Text = TheWord.Text.Length.ToString();
            numOfAtttempts = GetNumberOfAttempts();
            TextBlock1.Text = numOfAtttempts.ToString();
            TextBlock6.Text = numOfAtttempts.ToString();
        }

        private void InputTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InputTextBox.Text = "";
            counter = 0;
            WriteInFile("__Data 2__.txt", "", false);
        }

        private void Combobox1_DropDownClosed_1(object sender, EventArgs e)
        {
            numOfAtttempts = GetNumberOfAttempts();
            TextBlock6.Text = numOfAtttempts.ToString();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Hide();
            mainWindow.Show();
        }
        private double[] Authentification2(int[][] toothArr)
        {
            double[] mathArr = new double[toothArr.Length];
            for (int i = 0; i < toothArr.Length; i++)
            {
                if (toothArr[i] != null)
                {
                    mathArr[i] = MatSpodiv(toothArr[i]);
                }
            }
            return mathArr;
        }

        private double[] Authentification(int[][] toothArr)
        {
            double[] dispArr = new double[toothArr.Length];
            for (int i = 0; i < toothArr.Length; i++)
            {
                if (toothArr[i] != null)
                {
                    dispArr[i] = Dispersion2(toothArr[i]);
                }
            }
            return dispArr;
        }
        public double CheckAuthentification()
        {
            int attempts1 = GetNumOfValuableAttempts("__Еталонні значення 1__.txt");
            int attempts2 = GetNumOfValuableAttempts("__Еталонні значення 2__.txt");
            int[][] toothArr1 = GetMeaningToothArr("__Еталонні значення 1__.txt", attempts1);
            int[][] toothArr2 = GetMeaningToothArr("__Еталонні значення 2__.txt", attempts2);
            double[] dispArr1 = Authentification(toothArr1);
            double[] dispArr2 = Authentification(toothArr2);
            double[] mathArr1 = Authentification2(toothArr1);
            double[] mathArr2 = Authentification2(toothArr2);
            int length = 0;
            for (int i = 0; i < dispArr1.Length; i++)
            {
                if (dispArr1[i] != 0)
                {
                    length++;
                }
            }
            double[] arrP = new double[length];
            double dispersion = 0, t_p = 0;
            int r = 0;
            for (int i = 0; i < dispArr2.Length; i++)
            {
                if (dispArr2[i] != 0)
                {
                    for (int j = 0; j < dispArr1.Length; j++)
                    {
                        if (dispArr1[j] != 0)
                        {
                            dispersion = Pow(((Pow(dispArr1[j], 2) + Pow(dispArr2[i], 2)) * 11) / 23, 0.5);
                            t_p = Abs(mathArr1[j] - mathArr2[i]) / (dispersion * Sqrt(1.0 * 2 / 12));
                            
                            double t_T = 2.5;
                            if (t_p <= t_T)
                            {
                                r++;
                            }
                        }
                    }
                    arrP[i] = 1.0 * r / toothArr1.Length;
                    r = 0;
                }
            }
            double finaleP = 0;
            for (int i = 0; i < arrP.Length; i++)
            {
                finaleP += arrP[i];
            }
            return 1.0 * finaleP / arrP.Length;
        }
        private void TimeService()
        {
            int localCounter = 0;
            int[,] arr = new int[GetNumberOfAttempts(), TheWord.Text.Length - 1];
            StreamReader read = new StreamReader("__Data 2__.txt");
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
            bool hasValuableLine = GetValuableArray(arr, "__Еталонні значення 2__.txt", "__Мат дисперсія та сподівання 2__.txt");
            if (!hasValuableLine)
            {
                WindowForNotifications windowForNotifications = new WindowForNotifications();
                windowForNotifications.Show();
            }
            else
            {
                if (AreSimilar())
                {
                    TextBlock2.Text = "однорідні";
                }
                else
                {
                    TextBlock2.Text = "неоднорідні";
                }
                double P = CheckAuthentification();
                TextBlock3.Text = P.ToString();
                
                if(check == true)
                {
                    double P_1 = Find_P1();
                    TextBlock4.Text = P_1.ToString();
                }
                else
                {
                    double P_2 = Find_P2();
                    TextBlock5.Text = P_2.ToString();
                }
                
            }
        }

        private int GetNumberOfAttempts()
        {
            int numOfAtttempts = 1;
            if (Combobox1 != null)
            {
                ComboBoxItem comboBoxItem = (ComboBoxItem)Combobox1.SelectedItem;
                string selectedText = comboBoxItem.Content.ToString();
                numOfAtttempts = int.Parse(selectedText);
            }
            return numOfAtttempts;
        }

        private void DecreaseAttempts()
        {
            numOfAtttempts--;
            if (numOfAtttempts == 0)
            {
                InputTextBox.Background = Brushes.Red;
                InputTextBox.IsEnabled = false;
                TimeService();
            }
            TextBlock6.Text = numOfAtttempts.ToString();
        }

        private void DeleteLineInFile()
        {
            StreamReader streamReader = new StreamReader("__Data 2__.txt");
            string[] splittedText = streamReader.ReadToEnd().Split("\n");
            string editedData = "";
            for (int i = 0; i < splittedText.Length - 1; i++)
            {
                editedData += splittedText[i];
                editedData += "\n";
            }
            streamReader.Close();
            WriteInFile("__Data 2__.txt", editedData, false);
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (counter == 0)
            {
                stopwatch.Start();
            }
            else if (counter == 12)
            {
                stopwatch.Stop();
                TimeSpan time = stopwatch.Elapsed;
                WriteInFile("__Data 2__.txt", time.Milliseconds.ToString() + "\t", true);
            }
            else
            {
                stopwatch.Stop();
                TimeSpan time = stopwatch.Elapsed;
                WriteInFile("__Data 2__.txt", time.Milliseconds.ToString() + "\t", true);
                stopwatch.Restart();
            }
            counter++;
        }

        private void InputTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (InputTextBox.Text.Length >= TheWord.Text.Length)
            {
                if (InputTextBox.Text == TheWord.Text)
                {
                    DecreaseAttempts();
                    WriteInFile("__Data 2__.txt", "\n", true);
                    InputTextBox.Text = "";
                }
                else
                {
                    DeleteLineInFile();
                    InputTextBox.Text = "";
                }
                counter = 0;
            }
            TextBlock1.Text = InputTextBox.Text.Length.ToString();
        }
        private int GetNumOfValuableAttempts1(string file)
        {
            StreamReader read = new StreamReader(file);
            string[] text = read.ReadToEnd().Split("\n");
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                string[] line = text[i].Split("\t");
                if (line.Length == 13)
                {
                    num++;
                }
            }

            read.Close();
            return num;
        }
        
        public double Find_P1()
        {
            int rightAttempts = GetNumOfValuableAttempts1("__Еталонні значення 2__.txt");
            int allAttempts = GetNumOfValuableAttempts("__Data 2__.txt");
            return 1.0 * (allAttempts - rightAttempts) / allAttempts;
        }

        public double Find_P2()
        {
            int allAttepts = GetNumOfValuableAttempts("__Data 2__.txt");
            int rightAttempts = GetNumOfValuableAttempts1("__Еталонні значення 2__.txt");
            return 1.0 * rightAttempts / allAttepts;
        }
        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            check = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            check = false;
        }
    }
}
