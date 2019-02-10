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
            SeriesCollection = loadSeriesCollection(graphType.expectation);
            SeriesCollectionAverages = loadSeriesCollection(graphType.average);
            SeriesCollectionOutcomes = loadSeriesCollection(graphType.outcome);
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
        #endregion
        #region Chart Values


        /// <summary>
        /// Fills the graph with dummy values.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public SeriesCollection loadHistogramValues(int size)
        {
            SeriesCollection _seriesCollection = new SeriesCollection();
            for (int i = 0; i < size; i++)
            {
                _seriesCollection.Add(new ColumnSeries
                {
                    Title = String.Format("{0}", i),
                    Values = new ChartValues<double> { i }
                });
            }
            for (int i = size; i > 0; i--)
            {
                _seriesCollection.Add(new ColumnSeries
                {
                    Title = String.Format("{0}", i),
                    Values = new ChartValues<double> { -i }
                });
            }
            return _seriesCollection;
        }

        /// <summary>
        /// fills the line chart with dummy values.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public SeriesCollection loadLineValues(int size)
        {
            SeriesCollection _seriesCollection = new SeriesCollection();
            if((size%2)==0)
            {
                _seriesCollection.Add(
               new LineSeries
               {
                   Title = "Dummy Series",
                   Values = new ChartValues<double> { 4, 6, 5, 2, 4 },
                   Stroke = Brushes.Coral,
                   Fill = Brushes.LightCoral
               }
             );
            }
            else
            {
                _seriesCollection.Add(
               new LineSeries
               {
                   Title = "Dummy Series",
                   Values = new ChartValues<double> { -10, 22, 3, 13, 10, 97 },
                   Stroke = Brushes.Coral,
                   Fill = Brushes.LightCoral
               }
           );
            }
            return _seriesCollection;
        }

        #region graphs visibility togglers

        private String _AverageGraphVisibility = "Hidden";
        public String AverageGraphVisibility
        {
            get
            {
                return _AverageGraphVisibility;
            }
            set
            {
                _AverageGraphVisibility = value;
                RaisePropertyChanged();
            }
        }


        private String _ExpectationGraphVisibility = "Visible";
        public String ExpectationGraphVisibility
        {
            get
            {
                return _ExpectationGraphVisibility;
            }
            set
            {
                _ExpectationGraphVisibility = value;
                RaisePropertyChanged();
            }
        }

        private String _OutcomeGraphVisibility = "Hidden";
        public String OutcomeGraphVisibility
        {
            get
            {
                return _OutcomeGraphVisibility;
            }
            set
            {
                _OutcomeGraphVisibility = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand<Type> showExpectation;
        public RelayCommand<Type> ShowExpectation
        {
            get
            {
                return showExpectation = new RelayCommand<Type>((type) =>
                    {
                        OutcomeGraphVisibility = "Hidden";
                        AverageGraphVisibility = "Hidden";
                        ExpectationGraphVisibility = "Visible";
                    });
            }
        }

        private RelayCommand<Type> showOutomce;
        public RelayCommand<Type> ShowOutcome
        {
            get
            {
                return showOutomce = new RelayCommand<Type>((type) =>
                {
                    OutcomeGraphVisibility = "Visible";
                    AverageGraphVisibility = "Hidden";
                    ExpectationGraphVisibility = "Hidden";
                    System.Console.WriteLine("just clicked on outcome");
                });
            }
        }

        private RelayCommand<Type> showAverage;
        public RelayCommand<Type> ShowAverage
        {
            get
            {
                return showAverage = new RelayCommand<Type>((type) =>
                {
                    OutcomeGraphVisibility = "Hidden";
                    AverageGraphVisibility = "Visible";
                    ExpectationGraphVisibility = "Hidden";
                });
            }
        }

        #endregion


        /// <summary>
        ///
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public SeriesCollection loadSeriesCollection(graphType graph)
        {
            double[] graphValues=null;

            switch (graph)
            {
                case graphType.expectation:
                    graphValues = ViewsMediator.gameResults.expectation == null ? null : ViewsMediator.gameResults.expectation;
                    return expectationGraph(graphValues, @"C:\newPro\tenderSystemML\qExpectationConstantLoss.csv");
                case graphType.outcome:
                    graphValues = ViewsMediator.gameResults.outcome == null ? null : ViewsMediator.gameResults.outcome;
                    return lineGraph(graphValues, "Outcomes", @"C:\newPro\tenderSystemML\qOutcomeConstantLoss.csv");
                case graphType.average:
                    graphValues = ViewsMediator.gameResults.average == null ? null : ViewsMediator.gameResults.average;
                    return lineGraph(graphValues, "Average", @"C:\newPro\tenderSystemML\qAverageConstantLoss");
                default:
                    return loadHistogramValues(50);

            }
        }
        /// <summary>
        /// the following method populates the histogram graoh with the results of the calculations.
        /// </summary>
        /// <param name="graphValues"></param>
        /// <returns></returns>
        public SeriesCollection expectationGraph(double[] graphValues,String filePath)
        {
            String line = String.Empty;
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            List<Double> vals = new List<double>();
            while ((line = file.ReadLine()) != null)
            {
                String[] parts_of_line = line.Split(',');
                for (int i = 0; i < parts_of_line.Length; i++)
                {
                    parts_of_line[i] = parts_of_line[i].Trim();
                    vals.Add(Convert.ToDouble(parts_of_line[i]));
                }

                // do with the parts of the line whatever you like

            }
            if (graphValues != null)
            {
                SeriesCollection _seriesCollection = new SeriesCollection();
                int valuesInterval = (int)Math.Ceiling((double)(graphValues.Length / 200))+1;
                for (int i = 0; i < graphValues.Length; i += valuesInterval)
                {
                    _seriesCollection.Add(new ColumnSeries
                    {
                        Title = String.Format("{0}", i),
                        Values = new ChartValues<double> {vals[i] }
                    });
                }
                return _seriesCollection;
            }
            else
                return loadHistogramValues(100);
        }


        /// <summary>
        /// the method fills the line graph with values from the calculations results.
        /// </summary>
        /// <param name="graphValues"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public SeriesCollection lineGraph(double[] graphValues,String name,String filePath)
        {
            String line = String.Empty;
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            List<Double> vals = new List<double>();
            while ((line = file.ReadLine()) != null)
            {
                String[] parts_of_line = line.Split(' ');
                for (int i = 0; i < parts_of_line.Length; i++)
                {
                    parts_of_line[i] = parts_of_line[i].Trim();
                    vals.Add(Convert.ToDouble(parts_of_line[i]));
                }

                // do with the parts of the line whatever you like

            }
            if (graphValues != null)
            {
                SeriesCollection _seriesCollection = new SeriesCollection();
                //show selected values, to fit in the chart, with a proportion of 1/200
                int valuesInterval = (int)Math.Ceiling((double)(graphValues.Length / 200))+1;
                ChartValues<double> graphChartValues = new ChartValues<double>();
                foreach(double val in vals)
                    graphChartValues.Add(val);

                _seriesCollection.Add(
                    new LineSeries
                    {
                        Title = name,
                        Values = graphChartValues,
                        Stroke = String.Compare(name, "Outcomes") == 0  ? Brushes.DarkSlateBlue : Brushes.DodgerBlue,
                        Fill = String.Compare(name, "Outcomes") == 0 ? Brushes.SlateBlue : Brushes.LightSkyBlue
                    });
                return _seriesCollection;
            }
            else
            {
                Random randNum = new Random();
                return loadLineValues(randNum.Next(0, 23));
            }
        }
        
        public SeriesCollection SeriesCollection { get; set; }
   
        public SeriesCollection SeriesCollectionAverages { get; set; }

        public SeriesCollection SeriesCollectionOutcomes { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        #endregion
        #region Fields Binding (properties)
        private int _sliderValueLeft = 25;
        private int _sliderValueRight = 25;
        private List<graph> _graphsTree = new List<graph>();
        public List<graph> graphTree
        {
            get
            {
                return _graphsTree;
            }
            set
            {
                _graphsTree = value;
            }
        }
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
