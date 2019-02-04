using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace materialDesignTesting
{

    /// <summary>
    ///  this class is responsible for inserting the vector of strategy manually
    /// </summary>
    class UserManualStrategyViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<listBoxVector> _manualVector = new ObservableCollection<listBoxVector>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<listBoxVector> manualVector { get { return _manualVector; } }

        public UserManualStrategyViewModel()
        {
            //remove girl
            /*the following process should be called from the game settings MVVM, this is just a test*/
            ViewsMediator.NumberOfGames = 100;
            ViewsMediator.populateLists(ViewsMediator.NumberOfGames);
            //end of remove girl


            if (ViewsMediator.User.Count > 0)
            {
                listBoxVector.refToVector = ViewsMediator.Opponent;
                //ViewsMediator.User = new List<double>(100);
                int i = 0;
                foreach (double cell in ViewsMediator.User)
                {
                    manualVector.Add(new listBoxVector(String.Format("{0}", i++), cell));
                }
            }
        }
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
