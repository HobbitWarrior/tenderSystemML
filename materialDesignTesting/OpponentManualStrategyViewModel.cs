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
        public ObservableCollection<listBoxVector> manualVector { get { return ViewsMediator.OpponentObservable; } set { ViewsMediator.OpponentObservable = value; } }

        public OpponentManualStrategyViewModel()
        {

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
