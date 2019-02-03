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
    /// Represents a single value in a vector.
    /// Used to get the input from the user, in a window of manual strategy.
    /// </summary>
    class listBoxVector:INotifyPropertyChanged
    {
        private String Index;
        private double Value;
        public String index { get { return Index; } set { Index = value; RaisePropertyChanged(); } }
        public double value { get { return Value; } set { Value = value; RaisePropertyChanged(); } }
        
        public listBoxVector(String _index,double _value)
        {
            index = _index;
            value = _value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
