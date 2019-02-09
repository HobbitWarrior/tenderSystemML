using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace materialDesignTesting
{


    /// <summary>
    /// This class is initialize the parameters of the game
    /// </summary>
    class GameSettingsViewModel : INotifyPropertyChanged
    {


        #region Properties
        public int K
        {
            get
            {
                return ViewsMediator.K;
            }
            set
            {
                //change the value, even though it may be not valid, and alert the user about the error
                ViewsMediator.K = value;
                //validation condition
                if (value>1)
                {
                    Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.K);
                    //update the value for the oppoent manual vector insertion
                    ViewsMediator.generateCollection();
                    RaisePropertyChanged();
                    ViewsMediator.isFormValid["K"] = true;
                }
                else
                    ViewsMediator.isFormValid["K"] = false;
                    
            }
        }

        public int n0
        {
            get
            {
                return ViewsMediator.n0;
            }
            set
            {
                ViewsMediator.n0 = value;
                if (validateField(value,"n0"))
                {
                    Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.n0);
                    RaisePropertyChanged();
                }
            }
        }
        public int m
        {
            get
            {
                return ViewsMediator.m;
            }
            set
            {
                ViewsMediator.m = value;
                if (validateField(value,"m"))
                {
                    Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.m);
                    RaisePropertyChanged();
                }
            }
        }
        public int N
        {
            get
            {
                return ViewsMediator.N;
            }
            set
            {
                ViewsMediator.N = value;
                if (value>1)
                {
                    Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.N);
                    ViewsMediator.isFormValid["N"] = true;
                    RaisePropertyChanged();
                }
                else
                    ViewsMediator.isFormValid["N"] = false;
            }
        }
        public int y
        {
            get
            {
                return ViewsMediator.y;
            }
            set
            {
                ViewsMediator.y = value;
                if (validateField(value,"y"))
                {
                    Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.y);
                    RaisePropertyChanged();
                }
            }
        }
        public int z
        {
            get
            {
                return ViewsMediator.z;
            }
            set
            {
                ViewsMediator.z = value;
                if (validateField(value,"z"))
                {
                    Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.z);
                    RaisePropertyChanged();
                }
            }
        }
        public int w
        {
            get
            {
                return ViewsMediator.w;
            }
            set
            {
                ViewsMediator.w = value;
                if (validateField(value,"w"))
                {
                    Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.w);
                    RaisePropertyChanged();
                }
            }
        }


        private String _gameOrder = "User";
        public String GameOrder
        {
            get
            {
                return _gameOrder;
            }
            set
            {
                _gameOrder = value;
                if (_gameOrder.Equals("System.Windows.Controls.ComboBoxItem: User"))
                    ViewsMediator.isUserFirst = true;
                else
                    ViewsMediator.isUserFirst = false;
                Console.WriteLine("NumberOfGames has changed to: {0}", _gameOrder);
                RaisePropertyChanged();
            }
        }

        #endregion

        #region INotifyPropertyChanged Implementation -- consider creating an abstract class

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
        #region methods

        /// <summary>
        /// the method performs basic validation of the value in the form
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool validateField(int value,string field)
        {
            if (value < 1 || value > ViewsMediator.N)
            {
                ViewsMediator.isFormValid[field] = false;
                return false;
            }
            ViewsMediator.isFormValid[field] = true;
            return true;
        }
        #endregion



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
        private double _messageBoxEnabled = 1;
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
        public string ErrorBody
        {
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

        private RelayCommand<Type> errorMessageDissimis;
        public RelayCommand<Type> ErrorMessageDissimis
        {
            get
            {
                return (errorMessageDissimis = new RelayCommand<Type>(
                     (vmType) =>
                     {
                         hideMessageBox();
                     }));
#endregion

            }
        }
    }
}
