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
    /// The class updated the values of the provided vector in the viewsMediator class.
    /// </summary>
    class listBoxVector:INotifyPropertyChanged
    {
        private String Index;
        private double Value;
        public static List<double> refToVector = null;
        public String index { get { return Index; } set { Index = value; RaisePropertyChanged(); } }
        public double value
        {
            get
            {
                return Value;
            }
            set
            {
                if(value!=0)
                {
                    if (refToVector != null)
                    {
                        refToVector[Convert.ToInt32(Index)] = Value = value;
                        System.Console.WriteLine("copied succesfuly {0}", refToVector[Convert.ToInt32(Index)]);
                        RaisePropertyChanged();
                    }
                       
                }
            }
        }
        
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
