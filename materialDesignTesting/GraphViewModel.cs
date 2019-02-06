using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;




using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace materialDesignTesting
{
    class GraphViewModel : INotifyPropertyChanged
    {
        public GraphViewModel()
        {
            SeriesCollection = loadSeriesCollection(graphType.average);
            Labels = xLabels(1000);
            Formatter = value => value.ToString("N");
        }

        #region graph scrolling controls
        private double _minX=6;
        public double MinX
        {
            get { return _minX; }
            set { _minX = value > 0 ? value : 0; ZoomIn(-2); }
        }

        private double _maxX=6;
        public double MaxX
        {
            get { return _maxX; }
            set { _maxX = value < 100 ? value : 100 ; ZoomIn(2); }
        }


        public void ZoomIn(double zoomVal)
        {
            if(zoomVal <100)
                _maxX = zoomVal;
        }

        #endregion
        #region Graph View and Controllers

        //sliderbars min and maximum fields
        private int _leftSlideBarTail = 1;
        private int _leftSlideBarHead = 50;
        private int _rightSlideBarTail = 1;
        private int _rightSlideBarHead = 50;

        public int leftSlidebarTail
        {
            get { return _leftSlideBarTail; }
            set { if (_leftSlideBarTail != value) _leftSlideBarTail = value; }
        }
        public int leftSlideBarHead
        {
            get { return _leftSlideBarHead; }
            set { if (_leftSlideBarHead != value) _leftSlideBarHead = value; }
        }
        public int rightSlidebarTail
        {
            get { return _rightSlideBarTail; }
            set { if (_rightSlideBarTail != value) _rightSlideBarTail = value; }
        }
        public int rightSlidebarHead
        {
            get { return _rightSlideBarHead; }
            set { if (_rightSlideBarHead != value) _rightSlideBarHead = value; }
        }


        public string[] xLabels(int size)
        {
            string[] Labels = new string[size];
            for (int i = 0; i < size; i++)
                Labels[i] = String.Format("{0}", i);
            return Labels;
        }


        //disables tooltips
        public object Datatooltip
        {
            get
            {
                return null;
            }
        }


        public SeriesCollection loadHistogramValues(int size)
        {
            SeriesCollection = new SeriesCollection();
            for (int i = 0; i < size; i++)
            {
                SeriesCollection.Add(new ColumnSeries
                {
                    Title = String.Format("{0}", i),
                    Values = new ChartValues<double> { i }
                });
            }
            for (int i = size; i > 0; i--)
            {
                SeriesCollection.Add(new ColumnSeries
                {
                    Title = String.Format("{0}", i),
                    Values = new ChartValues<double> { -i }
                });
            }
            return SeriesCollection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns> 
        public SeriesCollection loadSeriesCollection(graphType graph)
        {
            Task.Factory.StartNew(() =>
            {

            });


            double[] graphValues=null;
            if (graph == graphType.outcome)
                graphValues = ViewsMediator.gameResults.outcome;
            else
            {
                if (graph == graphType.average)
                    graphValues = ViewsMediator.gameResults.average;
                else
                    graphValues = ViewsMediator.gameResults.expectation;
            }

            if (graphValues != null)
            {
                SeriesCollection = new SeriesCollection();
                for (int i = 0; i < graphValues.Length; i++)
                {
                    SeriesCollection.Add(new ColumnSeries
                    {
                        Title = String.Format("{0}", i),
                        Values = new ChartValues<double> { graphValues[i] }
                    });
                }
                return SeriesCollection;
            }
            else
                return loadHistogramValues(100);
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        #endregion

        #region Fields Binding (properties)
        private int _sliderValueLeft = 25;
        private int _sliderValueRight = 25;

        public double mean
        {
            get
            {
                return ViewsMediator.Mean;
            }
            set
            {
                ViewsMediator.Mean = value;
                System.Console.WriteLine("the mean is: {0}", ViewsMediator.Mean);
                RaisePropertyChanged();
            }
        }
        public double variance
        {
            get
            {
                return ViewsMediator.Variance;
            }
            set
            {
                ViewsMediator.Variance = value;
                RaisePropertyChanged();
            }
        }
        public double budgetSpent
        {
            get
            {
                return ViewsMediator.BudgetSpent;
            }
            set
            {
                ViewsMediator.BudgetSpent = value;
                RaisePropertyChanged();
            }
        }
        public double averageGain
        {
            get
            {
                return ViewsMediator.AverageGain;
            }
            set
            {
                ViewsMediator.AverageGain = value;
            }
        }


        public int sliderValueLeft
        {
            set
            {
                if (value <= 50 && value >= 1)
                {
                    this._sliderValueLeft = value;
                    RaisePropertyChanged();
                }
            }
            get
            {
                return this._sliderValueLeft;
            }
        }
        public int sliderValueRight
        {
            set
            {
                if (value <= 50 && value >= 1)
                {
                    this._sliderValueRight = value;
                    RaisePropertyChanged();
                }
            }
            get
            {
                return this._sliderValueRight;
            }
        }
        #endregion


        #region Zooming and Panning fields and methods


        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private ZoomingOptions _zoomingMode;

        public ZoomingOptions ZoomingMode
        {
            get { return _zoomingMode; }
            set
            {
                _zoomingMode = value;
                RaisePropertyChanged();
            }
        }

        public void zoomingBySlider()
        {
            ZoomingMode = ZoomingOptions.X;
            System.Console.Write("just got to the zooming event");
        }

        public void ToogleZoomingMode(object sender, RoutedEventArgs e)
        {
            switch (ZoomingMode)
            {
                case ZoomingOptions.None:
                    ZoomingMode = ZoomingOptions.X;
                    break;
                case ZoomingOptions.X:
                    ZoomingMode = ZoomingOptions.Y;
                    break;
                case ZoomingOptions.Y:
                    ZoomingMode = ZoomingOptions.Xy;
                    break;
                case ZoomingOptions.Xy:
                    ZoomingMode = ZoomingOptions.None;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class ZoomingModeCoverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ZoomingOptions)value)
            {
                case ZoomingOptions.None:
                    return "None";
                case ZoomingOptions.X:
                    return "X";
                case ZoomingOptions.Y:
                    return "Y";
                case ZoomingOptions.Xy:
                    return "XY";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}

