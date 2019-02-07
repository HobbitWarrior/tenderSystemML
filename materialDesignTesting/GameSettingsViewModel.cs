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
        #region Fields
        private Dictionary<String, int> trackFields = new Dictionary<string, int>();
        #endregion

        #region Properties
        public int K
        {
            get
            {
                return ViewsMediator.K;
            }
            set
            {
                ViewsMediator.K = value;
                Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.K);
                //update the value for the oppoent manual vector insertion
                ViewsMediator.generateCollection();
                RaisePropertyChanged();
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
                Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.n0);
                RaisePropertyChanged();
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
                Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.m);
                RaisePropertyChanged();
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
                Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.N);
                RaisePropertyChanged();
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
                Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.y);
                RaisePropertyChanged();
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
                Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.z);
                RaisePropertyChanged();
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
                ViewsMediator.w= value;
                Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.w);
                RaisePropertyChanged();
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
        //TODO: implement some field validation and tracking the filling of values in the  fields, and on completion of the form inform the snackbar
        #endregion
    }
}
