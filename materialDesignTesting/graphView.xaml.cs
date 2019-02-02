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
        }

        ///<summary>GraphViewModel reference</summary>
        private GraphViewModel graphViewModelRef;


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            graphViewModelRef = ((GraphViewModel)(this.DataContext));
            graphViewModelRef.zoomingBySlider();
            System.Console.WriteLine("just attempted to zooom by a slider :P");
        }

        public void ToogleZoomingMode(object sender, RoutedEventArgs e)
        {
            graphViewModelRef.ToogleZoomingMode(sender, e);
        }
    }
}
