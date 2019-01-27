using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace materialDesignTesting
{
    class GameSettingsViewModel : INotifyPropertyChanged
    {
        #region Variables
        #endregion

        #region Properties
        public int NumberOfGames
        {
            get
            {
                return ViewsMediator.NumberOfGames;
            }
            set
            {
                ViewsMediator.NumberOfGames = value;
                Console.WriteLine("NumberOfGames has changed to: {0}", ViewsMediator.NumberOfGames);
                RaisePropertyChanged();
            }
        }


        public String GamesOrder
        {
            get
            {
                return ViewsMediator.GameOrder;
            }
            set
            {
                ViewsMediator.GameOrder = value;
                Console.WriteLine("GameOrder has changed to: {0}", ViewsMediator.GameOrder);
                RaisePropertyChanged();
            }
        }

        public int PrizeAmount
        {
            get
            {
                return ViewsMediator.PrizeAmount;
            }
            set
            {
                ViewsMediator.PrizeAmount = value;
                Console.WriteLine("PrizeAmount has changed to: {0}", ViewsMediator.PrizeAmount);
                RaisePropertyChanged();
            }
        }

        public int BidValue
        {
            get
            {
                return ViewsMediator.BidValue;
            }
            set
            {
                ViewsMediator.BidValue = value;
                Console.WriteLine("bidValue has changed to: {0}", ViewsMediator.BidValue);
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

    }
}
