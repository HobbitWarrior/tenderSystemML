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
    /// A class that will contains all the data that is shared between the menus of the program, 
    /// all the properties and fields are static and accessible all over the app.
    /// </summary>


    class ViewsMediator : INotifyPropertyChanged
    {

        #region Expander Progress Variables
        //<value>The following variables control the wizard's expander</value>
        public static String userExpander = "True";
        public static String opponentExpander = "True";
        public static String gameSettingsExpander = "True";
        public static String calculateExpander = "True";
        #endregion


        #region Game Settings Variables
        //<summary>Game General Settings Variables</summary>
        //<value>Number Of Games</value>
        public static int NumberOfGames=0;

        //<value>Define who will play first</value>
        public static String GameOrder="";

        //<value>Prize Amount</value>
        public static int PrizeAmount=0;

        //<value>Bid Value</value>
        public static int BidValue=0;
        #endregion

        #region Grpah Display Variables
        public static double Mean;
        public static double Variance;
        public static double BudgetSpent;
        public static double AverageGain;
        public static object Graph; //not sure yet how it will be displayed :P
        #endregion

        #region Game Probability Vectors
        //<value>User's result vector</value>
        private static List<double> user = new List<double>();
        //<value>Opponent's result vector</value>
        private static List<double> opponent = new List<double>();
        #endregion

        #region Game results vectors
        /// <summary>
        /// an object tha will contain the game results for analytics
        /// </summary>
        public static resultArrays gameResults;
        #endregion

        #region SnackBar message queue
        /// <summary>
        /// Stores the messages for the snackBar, informs the user about events in the app.
        /// </summary>
        public static List<string> messagesForSnacky = new List<string>();
        #endregion
        #region global flags and progress trackers
        public static progress trackWizardProgress = 0; 
        #endregion
        public static string pythonRunResult = "";
        //<summary> the following properties will control the probablity???????? vectors of the players. </summary>
        public static List<double> User {
            get
            {
                return user;
            }
            set
            {
                if (value != null)
                    user = value;
            }
        }


        public static List<double> Opponent
        {
            get
            {
                return opponent;
            }
            set
            {
                if (value != null)
                    opponent = value;
            }
        }
        /// <summary>
        /// The following list will fill the vectors with dummy values in the amount of possible rounds in a game.
        /// Will be used after the user entered the NumberOfGames.
        /// </summary>
        /// <param name="size"></param>
        public static void populateLists(int size)
        {
            for(int i=0;i<size;i++)
            {
                user.Add(0);
                opponent.Add(0);
            }
        }



        #region INotifyPropertyChanged Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        ///<summary> Implementation of the INotifyPropertyChanged event raising</summary>
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