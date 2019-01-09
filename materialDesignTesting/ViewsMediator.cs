using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace materialDesignTesting
{
    //<summary>A class that will contain all the data that needs to be shared between the menus of the program, and it will also 
    //keep the progress of completion of the wizard that is essential for the running of the Prediction Algorithm.
    //Author: Alex Zeltser</summary>
    class ViewsMediator : INotifyPropertyChanged
    {
        //<value>Tracks the progress of the wizard</value>
        private static Dictionary<String, progress> wizardProgress = new Dictionary<string, progress>();

        //<value>The following variables control the wizard's expander</value>
        public static String userExpander = "True";
        public static String opponentExpander = "True";
        public static String calculateExpander = "True";


        public event PropertyChangedEventHandler PropertyChanged;

        //<value>User's result vector</value>
        private static List<double> user =new List<double>();
        //<value>Opponent's result vector</value>
        private static List<double> opponent = new List<double>();

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

        
        public static  List<double> Opponent
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
        //<summary> Implementation of the INotifyPropertyChanged event raising</summary>
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
