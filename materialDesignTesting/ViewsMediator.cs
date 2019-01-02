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

        public event PropertyChangedEventHandler PropertyChanged;


        private static List<double> user =new List<double>();
        private static List<double> opponent = new List<double>();

        //<ummary> the following properties will control the probablity???????? vectors of the players. </summary>
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
        /*<summary>
        * The following method tracks the progress in each section of the game setting wizard.
        * </summary>*/
        public static bool setWizardProgress ( String Tkey, progress Tvalue)
        {
                if (Tvalue >= 0)
                {
                    try
                    {
                        wizardProgress.Add(Tkey, Tvalue);
                        return true;
                    }
                    // ArgumentException inherits from ArgumentNullException
                    catch(ArgumentException AE)
                    {
                        return false;
                    }
            }
            return false;      
        }
        /*<summary>
         * controlls the expander of each section via binding
         * (Non Static)
         * </summary>
         */
        public Boolean getWizardProgress( String Tkey )
        {
            try
            {
                return wizardProgress[Tkey] == progress.loaded ? true : false;
            }
            catch( Exception ex )
            {
                //Assuming the exception was raised due to a non existing key.
                Console.WriteLine(ex.Message);
                return false;
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
