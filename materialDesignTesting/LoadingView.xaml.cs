using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for LoadingView.xaml
    /// </summary>
    public partial class LoadingView : UserControl, INotifyPropertyChanged
    {
        public LoadingView()
        {
            DataContext = this;
            InitializeComponent();
            //MainWindow.Snackbar.MessageQueue.Enqueue("Done :)");
            externalProcessRunner epr = new externalProcessRunner();
            //validate and save the results in the view mediator
            showMessageBox("Whoops, Something went wrong", "Something went wrong, the external script runner 'externalProccessRunner' did not return results array.");
            if ((ViewsMediator.gameResults = epr.runCmd()) == null)
            {
                MainWindow.Snackbar.MessageQueue.Enqueue("Something went wrong, the external script runner 'externalProccessRunner' did not return results array.");
                showMessageBox("Whoops, Something went wrong", "Something went wrong, the external script runner 'externalProccessRunner' did not return results array.");
            }
            else
                MainWindow.Snackbar.MessageQueue.Enqueue("Done :) Click Next to prceed to results.");
            //if the calculation is done change the transition between the wizard windows button controller.
            System.Console.WriteLine("finished reading from the pipe, loading graphs");
            ViewsMediator.isDoneCalcualtingQ = true;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Alert Box Properties and methods
        /// <summary>
        /// a method that shows the message box 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="Body"></param>
        public void showMessageBox(String header, String Body)
        {
            messageBoxEnabled = 0.5;
            AlerBoxVisibility = "Visible";
            ErrorHead = header;
            ErrorBody = Body;
        }
        public void hideMessageBox()
        {
            messageBoxEnabled = 1;
            AlerBoxVisibility = "Hidden";
        }
        private string _AlerBoxVisibility = "Hidden";
        public string AlerBoxVisibility
        {
            get
            {
                return _AlerBoxVisibility;
            }
            set
            {
                _AlerBoxVisibility = value;
                RaisePropertyChanged();
            }
        }
        //message box view controller
        private double _messageBoxEnabled =1;
        public double messageBoxEnabled
        {
            get
            {
                return _messageBoxEnabled;
            }
            set
            {
                _messageBoxEnabled = value;
                RaisePropertyChanged();
            }
        }
        private string _ErrorHead;
        public string ErrorHead
        {
            get
            {
                return _ErrorHead;
            }
            set
            {
                _ErrorHead = value;
                RaisePropertyChanged();
            }
        }
        private string _ErrorBody;
        public string ErrorBody {
            get
            {
                return _ErrorBody;
            }
                set
            {
                _ErrorBody = value;
                RaisePropertyChanged();
            }
        }

        private void ErrorMessageDissimis(object sender, RoutedEventArgs e)
        {
            hideMessageBox();
        }
        #endregion

    }
}
