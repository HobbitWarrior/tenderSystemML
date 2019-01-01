using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace materialDesignTesting
{
    class ViewsMediator : INotifyPropertyChanged
    {
        private static Dictionary<String, progress> wizardProgress;

        public event PropertyChangedEventHandler PropertyChanged;

        /*<summary>
        * The following method tracks the progress in each section of the game setting wizard.
        S* </summary>*/
        public static void setWizardProgress ( String Tkey, progress Tvalue)
        {
            if (wizardProgress == null)
            {
                wizardProgress = new Dictionary<string, progress>();
                if (!(String.IsNullOrEmpty(Tkey)) && Tvalue >= 0)
                    wizardProgress.Add(Tkey, Tvalue);
                else
                    wizardProgress.Add(Tkey, progress.blank);
            }
                      
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
                return false;
            }
        }
    }
}
