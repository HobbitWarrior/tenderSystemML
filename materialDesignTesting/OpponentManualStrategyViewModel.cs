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
    class OpponentManualStrategyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<listBoxVector> _manualVector = new ObservableCollection<listBoxVector>();
        public ObservableCollection<listBoxVector> manualVector { get { return _manualVector; } }

        public OpponentManualStrategyViewModel()
        {
            /*the following process should be called from the game settings MVVM, this is just a test*/
            ViewsMediator.NumberOfGames = 100;
            ViewsMediator.populateLists(ViewsMediator.NumberOfGames);



            if( ViewsMediator.User.Count>0)
            {
                int i = 0;
                foreach( double cell in ViewsMediator.User)
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
