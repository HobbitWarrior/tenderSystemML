using LiveCharts.Events;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;


namespace materialDesignTesting
{
    /// <summary>
    /// Interaction logic for graphView.xaml
    /// </summary>
    public partial class graphView : UserControl
    {
        public graphView()
        {
            InitializeComponent();
            graphViewModelRef = ((GraphViewModel)(this.DataContext));
            System.Console.Write("the ref value {0}\n", graphViewModelRef);
        }
        
        ///<summary>GraphViewModel reference</summary>
        private GraphViewModel graphViewModelRef;

        #region slider events
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Point relativePoint = graphGrid.PointToScreen(new Point(0d, 0d));
            System.Console.Write("\nValeHasChangedEvent:the relative point is {0}", relativePoint);
            SetCursorPos((int)relativePoint.X, (int)relativePoint.Y);


        }

        public void ToogleZoomingMode(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("just attempted to zoom by the mousewheel YAY!!! :P");
            graphViewModelRef.ToogleZoomingMode(sender, e);
        }

        #endregion
        #region scrolling controllers and events

        private void Axis_OnRangeChanged(RangeChangedEventArgs eventargs)
        {
            var vm = (GraphViewModel)DataContext;

            var currentRange = eventargs.Range;

            if (currentRange < TimeSpan.TicksPerDay * 2)
            {
                vm.Formatter = x => new DateTime((long)x).ToString("t");
                return;
            }

            if (currentRange < TimeSpan.TicksPerDay * 60)
            {
                vm.Formatter = x => new DateTime((long)x).ToString("dd MMM yy");
                return;
            }

            if (currentRange < TimeSpan.TicksPerDay * 540)
            {
                vm.Formatter = x => new DateTime((long)x).ToString("MMM yy");
                return;
            }

            vm.Formatter = x => new DateTime((long)x).ToString("yyyy");
        }

        public void Dispose()
        {
            var vm = (GraphViewModel)DataContext;
        }
        #endregion
    }
}
