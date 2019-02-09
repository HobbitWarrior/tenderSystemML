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
        /// <value>
        /// an indicator of the game settings form validity
        /// </value>
        public static Dictionary<string,bool> isFormValid = new Dictionary<string, bool>()
        {
            {"K",   false },
            {"N",   false },
            {"n0",  false },
            {"m",   false },
            {"y",   false },
            {"z",   false },
            {"w",   false }
        };
        //<value>Number Of Games</value>
        public static int K=3;

        //<value>n0</value>
        public static int n0=1;

        //<value>m</value>
        public static int m=2;

        //<value>y</value>
        public static int y = 4;
        //<value>z</value>
        public static int z = 5;
        //<value>w</value>
        public static int w = 6;
        //<value>N</value>
        public static int N = 7;

        /// <value>a falg to control the playing order, if true the user will play first</value>
        public static bool isUserFirst = true;
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

        public static ObservableCollection<listBoxVector> OpponentObservable =  new ObservableCollection<listBoxVector>();

        public static void generateCollection()
        {
            ViewsMediator.populateLists(ViewsMediator.K);
            ViewsMediator.OpponentObservable.Clear();
            if (ViewsMediator.Opponent.Count > 0)
            {
                //listBoxVector.refToVector = ViewsMediator.Opponent;
                //ViewsMediator.User = new List<double>(100);
                    OpponentObservable.Clear();
                    int i = 0;
                    foreach (double cell in ViewsMediator.Opponent)
                    {
                        OpponentObservable.Add(new listBoxVector(String.Format("{0}", i++), cell));
                    }
            }
        }

        #endregion

        #region Game results vectors
        /// <summary>
        /// an object tha will contain the game results for analytics
        /// </summary>
        public static resultArrays gameResults = new resultArrays();
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
        //remove possibly
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
            opponent.Clear();
            listBoxVector.refToVector = opponent;
            for(int i=0;i<size;i++)
            {
                //user.Add(0);
                opponent.Add(0);
            }
        }

        public static bool isDoneCalcualtingQ = false;

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