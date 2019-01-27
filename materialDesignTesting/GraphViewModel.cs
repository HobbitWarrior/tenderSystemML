using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace materialDesignTesting
{
    class GraphViewModel : INotifyPropertyChanged
    {
        public GraphViewModel()
        {
        }

        #region Fields Binding (properties)
        private int _sliderValue = 25;

        public double mean
        {
                get
                {
                return ViewsMediator.Mean; 
                }
               set
                {
                    ViewsMediator.Mean= value;
                    System.Console.WriteLine("the mean is: {0}", ViewsMediator.Mean);
                    RaisePropertyChanged();
                }
        }
        public double variance
        {
                get
                {
                return ViewsMediator.Variance;
            }
                set
                {
                    ViewsMediator.Variance= value;
                    RaisePropertyChanged(); 
                }
         }
        public double budgetSpent
         {
                get
                {
                    return ViewsMediator.BudgetSpent;
                }
                set
                {
                    ViewsMediator.BudgetSpent = value;
                     RaisePropertyChanged();
            }
         }
        public double averageGain
         {
                get
                {
                return ViewsMediator.AverageGain;
                }
                set
                {
                    ViewsMediator.AverageGain = value;
                }
         }


        public int sliderValue
        {
            set
            {
                if(value<=50 && value >=1)
                {
                    this._sliderValue = value;
                    RaisePropertyChanged();
                }
            }
            get
            {
                return this._sliderValue;
            }
        }
        #endregion

        //private ICommand clickOnBrowseButton;
        //public ICommand ClickOnBrowseButton
        //{
        //    get
        //    {
        //        return clickOnBrowseButton ?? (clickOnBrowseButton = new CommandHandler(() => null, true));
        //    }
        //}




      
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
