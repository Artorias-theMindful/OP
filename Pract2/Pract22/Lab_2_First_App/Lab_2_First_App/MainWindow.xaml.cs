using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lab_2_First_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DispatcherTimer dT;
        static Random rnd = new Random();
        static int Radius = 15;
        static int PointCount = 5;
        static int PopulationCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> Ellipse_Array = new List <Ellipse>();
        static PointCollection Point_Collection = new PointCollection();
        static int[][] ways;
        public MainWindow()
        {
            dT = new DispatcherTimer();

            InitializeComponent();
            InitPoints();
            InitPolygon();

            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(OneStep);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 1000);            
        }

        private void InitPoints()
        {
            Random rnd = new Random();
            Point_Collection.Clear();
            Ellipse_Array.Clear();

            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(Radius, (int)(0.75*MainWin.Width)-3*Radius);
                p.Y = rnd.Next(Radius, (int)(0.90*MainWin.Height-3*Radius));                
                Point_Collection.Add(p);
            }

            for (int i = 0; i < PointCount; i++)
            { 
                Ellipse el = new Ellipse();

                el.StrokeThickness = 0;
                el.Height = el.Width = Radius;
                el.Stroke = Brushes.Black;
                el.Fill = Brushes.Red;
                Ellipse_Array.Add(el); 
            }            
        }

        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;            
            myPolygon.StrokeThickness = 1;            
        }

        private void PlotPoints()
        {            
            for (int i=0; i<PointCount; i++)
            {
                Canvas.SetLeft(Ellipse_Array[i], Point_Collection[i].X - Radius/2);
                Canvas.SetTop(Ellipse_Array[i], Point_Collection[i].Y - Radius/2);
                MyCanvas.Children.Add(Ellipse_Array[i]);
            }
        }


        private void PlotWay(int [] BestWayIndex)
        {
            PointCollection Points = new PointCollection();

            for (int i = 0; i < BestWayIndex.Length; i++)
                Points.Add(Point_Collection[BestWayIndex[i]]);

            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }
        
        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            GetWays();
            if (dT.IsEnabled)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
            }
            else
            {                
                NumElemCB.IsEnabled = false;
                dT.Start();
            }
        }

        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();
        }
        private void VelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            dT.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));
        }

        private void NumPopulation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
            PopulationCount = Convert.ToInt32(item.Content);
            
        }
        
        private void GetWays()
        {
            ways = new int[2 * PopulationCount][];
            int[] data = new int[PointCount];
            for (int i = 0; i < PointCount; i++)
                data[i] = i;
            for (int i = 0; i < PopulationCount; i++)
            {
                for (int j = data.Length - 1; j > 0; j--)
                {
                    int f = rnd.Next(j + 1);

                    var temp = data[f];
                    data[f] = data[j];
                    data[j] = temp;
                }
                ways[i] = new int[PointCount];
                for (int j = 0; j < PointCount; j++)
                {

                    ways[i][j] = data[j];
                }
            }
        }

        private void OneStep(object sender, EventArgs e)
        {
            MyCanvas.Children.Clear();
            //InitPoints();
            PlotPoints();
            PlotWay(GetBestWay());
        }

        private int[] GetBestWay()
        {
            
            
            for (int i = 0; i < PopulationCount; i++)
            {
                int i1 = rnd.Next(PopulationCount - 1);
                int i2 = rnd.Next(PopulationCount - 1);
                int cross = rnd.Next(PointCount);
                int[] temp1 = new int[PointCount];
                int[] temp2 = new int[PointCount];
                for (int j = 0; j < cross; j++)
                {
                    temp1[j] = ways[i1][j];
                    temp2[j] = ways[i2][j];
                }
                for (int j = cross; j < PointCount; j++)
                {
                    temp1[j] = ways[i2][j];
                    temp2[j] = ways[i1][j];
                }
                if (rnd.Next(1) == 0)
                {
                    ways[i + PopulationCount] = MakeChild(temp1, temp2);
                }
                else
                {
                    ways[i + PopulationCount] = MakeChild(temp2, temp1);
                }
                if (rnd.NextDouble() < Convert.ToDouble(mutation.Text))
                {
                    int i11 = rnd.Next(PointCount);
                    int i22 = rnd.Next(PointCount);
                    if (i11 < i22)
                    {
                        for (int j = 0; j <= (i22 - i11) / 2; j++)
                        {
                            int k = ways[i + PopulationCount][i11 + j];
                            ways[i + PopulationCount][i11 + j] = ways[i + PopulationCount][i22 - j];
                            ways[i + PopulationCount][i22 - j] = k;
                        }
                    }
                    else
                        for (int j = 0; j <= (i11 - i22) / 2; j++)
                        {
                            int k = ways[i + PopulationCount][i22 + j];
                            ways[i + PopulationCount][i22 + j] = ways[i + PopulationCount][i11 - j];
                            ways[i + PopulationCount][i11 - j] = k;
                        }
                }

            }
            
            double[] distances = new double[ways.Length];
            

            for (int i = 0; i < ways.Length; i++)
            {
                distances[i] = FindDistance(ways[i]);
                
            }
            for (int i = 0; i < distances.Length; i++)
            {
                for (int j = 0; j < distances.Length - 1; j++)
                {
                    if(distances[j] > distances[j + 1])
                    {
                        double dist = distances[j];
                        distances[j] = distances[j + 1];
                        distances[j + 1] = dist;

                        int[] way = ways[j];
                        ways[j] = ways[j + 1];
                        ways[j + 1] = way;
                    }
                }
            }
            

            

            return ways[0];
            
        }

        private int[] MakeChild(int[] temp1, int[] temp2)
        {
            List<int> repeating = new List<int>();
            int[] temp = new int[2 * temp1.Length];
            for(int i = 0; i < temp1.Length; i++)
            {
                temp[i] = temp1[i];
            }
            for (int i = 0; i < temp1.Length; i++)
            {
                temp[temp1.Length + i] = temp2[i];
            }
            int[] child = new int[PointCount];
            int count = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (!repeating.Contains(temp[i]))
                {
                    child[count] = temp[i];
                    repeating.Add(temp[i]);
                    count++;
                }

            }

            return child;
        } 

        private double FindDistance(int[] way)
        {
            double distance = 0;
            for(int i = 1; i < way.Length; i++)
            {
                Point p1 = Point_Collection[way[i - 1]];
                double x1 = p1.X;
                double y1 = p1.Y;
                Point p2 = Point_Collection[way[i]];
                double x2 = p2.X;
                double y2 = p2.Y;
                distance += Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            }
            Point plast1 = Point_Collection[way[0]];
            double xlast1 = plast1.X;
            double ylast1 = plast1.Y;
            Point plast2 = Point_Collection[way[way.Length - 1]];
            double xlast2 = plast2.X;
            double ylast2 = plast2.Y;
            distance += Math.Sqrt(Math.Pow(xlast1 - xlast2, 2) + Math.Pow(ylast1 - ylast2, 2));
            return distance;
        }

        
    }
}