using System;
using System.Diagnostics;
using MaterialDesignThemes.Wpf;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;


namespace materialDesignTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Snackbar Snackbar;
        public MainWindow()
        {
            InitializeComponent();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2500);
            }).ContinueWith(t =>
            {
                //note you can use the message queue from any thread, but just for the demo here we 
                //need to get the message queue from the snackbar, so need to be on the dispatcher
                MainSnackbar.MessageQueue.Enqueue("Welcome to Material Design In XAML Tookit");
            }, TaskScheduler.FromCurrentSynchronizationContext());

           // DataContext = new MainWindowViewModel(MainSnackbar.MessageQueue);

            Snackbar = this.MainSnackbar;
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
            //var sampleMessageDialog = new SampleMessageDialog
            //{
            //    Message = { Text = ((ButtonBase)sender).Content.ToString() }
            //};

            //await DialogHost.Show(sampleMessageDialog, "RootDialog");
        }

        private void OnCopy(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string stringValue)
            {
                try
                {
                    Clipboard.SetDataObject(stringValue);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }
        }

        private void sapir(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("you just clicked on me :) it tickles :)");
        }

        private void ListBoxItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Console.Write("just clicked");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //a string to emulate a json that is received from the stdout
            String json = "[{\"average\":[0.0,0.0,0.0,0.0],\"expectation\":[0.0,0.0,0.0,0.0],\"outcome\":[0.0,0.0,0.0,0.0]}]";
            jsonHandler jh = new jsonHandler(json);
            resultArrays ra = jh.deserialize();
            ViewsMediator.gameResults = ra;
            System.Console.Write("just something to hold a break point");
        }
    }
}
