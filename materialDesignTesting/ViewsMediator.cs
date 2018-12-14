using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace materialDesignTesting
{
    class ViewsMediator
    {
        private static Dictionary<String, progress> wizardProgress;
        
        public static void setWizardProgress ( String Tkey, progress Tvalue)
        {
            if (wizardProgress == null)
                wizardProgress = new Dictionary<string, progress>();
            if( !(String.IsNullOrEmpty(Tkey)) && Tvalue>=0 )
                wizardProgress.Add(Tkey, Tvalue);
        }

        public static progress getWizardProgress( String Tkey )
        {
            try
            {
                return wizardProgress[Tkey];
            }
            catch( Exception ex )
            {
                //Assuming the exception was raised due to a non existing key.
                return progress.blank;
            }
        }
    }
}
