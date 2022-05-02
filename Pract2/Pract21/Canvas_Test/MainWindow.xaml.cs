using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Math;

namespace Canvas_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Polygon> PolygonList = new List<Polygon>();
        static Random rnd = new Random();
        static int Radius = 20;
        static DispatcherTimer dT = new DispatcherTimer();
        static int PointCount = 4;
        static PointCollection Point_Collection = new PointCollection();
        static List<Ellipse> List_Ellipses = new List<Ellipse>();
        static int[] Used_Indexes = new int[PointCount];
        static int counter = 0;


        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            InitPoints();
            InitPolygons();
            PlotPoints();
            Used_Indexes = new int[PointCount];
            dT = new DispatcherTimer();

            int[] bestWayIndexes = GetBestWay();
            PutPointPairInPolygonList(bestWayIndexes);

            dT.Tick += new EventHandler(PlotCut);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 500);
        }

        private void PutPointPairInPolygonList(int[] bestWayIndexes)
        {
            
            Point p1, p2;
            for (int i = 0; i < bestWayIndexes.Length; i++)
            {
                
                if (i == bestWayIndexes.Length - 1)
                {
                    PointCollection curPoints = new PointCollection();
                    p1 = Point_Collection[bestWayIndexes[i]];
                    curPoints.Add(p1);
                    p2 = Point_Collection[bestWayIndexes[0]];
                    curPoints.Add(p2);
                    
                    PolygonList[i].Points = curPoints;
                }
                else
                {
                    PointCollection curPoints = new PointCollection();
                    p1 = Point_Collection[bestWayIndexes[i]];
                    curPoints.Add(p1);
                    p2 = Point_Collection[bestWayIndexes[i + 1]];
                    curPoints.Add(p2);
                    
                    PolygonList[i].Points = curPoints;
                }
            }
        }

        private void PlotCut(object sender, EventArgs e)
        {
            if (counter == PointCount)
            {
                dT.Stop();
                return;
            }
            MyCanvas.Children.Add(PolygonList[counter]);
            counter++;
            
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            
            
                Comboboxx.IsEnabled = false;
                dT.Start();
            
        }

        private void InitPolygons()
        {
            for (int i = 0; i < PointCount; i++)
            {
                Polygon myPolygon = new Polygon();
                myPolygon.Stroke = System.Windows.Media.Brushes.Black;
                myPolygon.StrokeThickness = 1;
                PolygonList.Add(myPolygon);
            }
        }

        private void InitPoints()
        {
            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();
                p.X = rnd.Next(Radius, (int)(MainWin.Width * 0.75 - 3 * Radius));
                p.Y = rnd.Next(Radius, (int)(MainWin.Height * 0.90 - 3 * Radius));
                Point_Collection.Add(p);
            }

            for (int i = 0; i < PointCount; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.StrokeThickness = 0;
                ellipse.Height = ellipse.Width = Radius;
                ellipse.Stroke = Brushes.Black;
                ellipse.Fill = Brushes.Goldenrod;
                List_Ellipses.Add(ellipse);
            }
        }

        private void PlotPoints()
        {
            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(List_Ellipses[i], Point_Collection[i].X - Radius / 2);
                Canvas.SetTop(List_Ellipses[i], Point_Collection[i].Y - Radius / 2);
                MyCanvas.Children.Add(List_Ellipses[i]);
            }
        }

        private int[] GetBestWay()
        {
            int minIndex = 0;
            int[] way = new int[PointCount];
            for (int i = 0; i < PointCount; i++)
            {
                minIndex = GetMinIndex(Point_Collection, minIndex);
                if (i == PointCount - 1)
                {
                    break;
                }
                way[i + 1] = minIndex;
                Used_Indexes[i] = minIndex;
            }
            return way;
        }

        private int GetMinIndex(PointCollection points, int index)
        {
            Point p1 = Point_Collection[index];
            int x1 = (int)p1.X;
            int y1 = (int)p1.Y;
            int x2, y2 = 0;
            double min = int.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < PointCount; i++)
            {
                if (!Used_Indexes.Contains(i))
                {
                    Point p2 = Point_Collection[i];
                    x2 = (int)p2.X;
                    y2 = (int)p2.Y;
                    double len = Sqrt(Pow(x1 - x2, 2) + Pow(y1 - y2, 2));
                    if (len < min)
                    {
                        min = len;
                        minIndex = i;
                    }
                }
            }
            return minIndex;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            PointCount = Convert.ToInt32(item.Content);
            MyCanvas.Children.Clear();
            InitPoints();
            InitPolygons();
            Start();
        }
    }
}


