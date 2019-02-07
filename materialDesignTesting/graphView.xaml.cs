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
using WindowsInput.Native;
using WindowsInput;


using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

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

        private void ResetZoomOnClick(object sender, RoutedEventArgs e)
        {
            //Use the axis MinValue/MaxValue properties to specify the values to display.
            //use double.Nan to clear it.
            X.MinValue = double.NaN;
            X.MaxValue = double.NaN;
            Y.MinValue = double.NaN;
            Y.MaxValue = double.NaN;
        }

        private double previousSliderValue=0;
        private void ResetZoomOnClick(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if(previousSliderValue != ZoomingSlidy.Value)
            {
                //X.MinValue = double.NaN;
                //X.MaxValue = double.NaN;
                //Y.MinValue = double.NaN;
                //Y.MaxValue = double.NaN;
                lvcHistogram.Zoom = ZoomingOptions.X;
                lvcHistogram.Pan = PanningOptions.X;
                if (previousSliderValue < ZoomingSlidy.Value)
                {
                    //X.MinValue = double.NaN;
                    //X.MaxValue = double.NaN;
                    //Y.MinValue = double.NaN;
                    //Y.MaxValue = double.NaN;
                    previousSliderValue = ZoomingSlidy.Value;
                    X.MinValue = Convert.ToDouble(Math.Ceiling(X.MinValue + ZoomingSlidy.Value / 100));
                    //X.MaxValue = Convert.ToDouble(Math.Ceiling(X.MaxValue - ZoomingSlidy.Value / 100));
                    //Y.MinValue = Convert.ToDouble(Y.MinValue + ZoomingSlidy.Value);
                    //Y.MaxValue = Convert.ToDouble(Y.MaxValue - ZoomingSlidy.Value);
                }
                else
                {
                    //X.MinValue = double.NaN;
                    //X.MaxValue = double.NaN;
                    //Y.MinValue = double.NaN;
                    //Y.MaxValue = double.NaN;
                    previousSliderValue = ZoomingSlidy.Value;
                    X.MinValue = Convert.ToDouble(Math.Ceiling(X.MinValue - ZoomingSlidy.Value / 100));
                    //X.MaxValue = Convert.ToDouble(Math.Ceiling(X.MaxValue + ZoomingSlidy.Value / 100));
                    //Y.MinValue = Convert.ToDouble(Y.MinValue - ZoomingSlidy.Value);
                    //Y.MaxValue = Convert.ToDouble(Y.MaxValue - ZoomingSlidy.Value);
                }
            }
            System.Console.WriteLine("Attempted to change the graphs zoom");
        }

        private void TreeViewItem_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Console.Write("clicked on a tree item");
        }



        #endregion
        //#region scrolling controllers and events

        //private void Axis_OnRangeChanged(RangeChangedEventArgs eventargs)
        //{
        //    var vm = (GraphViewModel)DataContext;

        //    var currentRange = eventargs.Range;

        //    if (currentRange < TimeSpan.TicksPerDay * 2)
        //    {
        //        vm.Formatter = x => new DateTime((long)x).ToString("t");
        //        return;
        //    }

        //    if (currentRange < TimeSpan.TicksPerDay * 60)
        //    {
        //        vm.Formatter = x => new DateTime((long)x).ToString("dd MMM yy");
        //        return;
        //    }

        //    if (currentRange < TimeSpan.TicksPerDay * 540)
        //    {
        //        vm.Formatter = x => new DateTime((long)x).ToString("MMM yy");
        //        return;
        //    }

        //    vm.Formatter = x => new DateTime((long)x).ToString("yyyy");
        //}

        //public void Dispose()
        //{
        //    var vm = (GraphViewModel)DataContext;
        //}
        //#endregion
    }
}
