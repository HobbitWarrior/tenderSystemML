using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace materialDesignTesting
{
    class OpponentLoadStrategyViewModel
    {
        public OpponentLoadStrategyViewModel()
        {
            canExecute = true;
        }
        private bool canExecute;
        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return clickCommand ?? (clickCommand = new CommandHandler(() => MyAction(), canExecute));
            }
        }



        public void MyAction()
        {
            Console.WriteLine("Just called a button click event!!!! Yay! :)");
        }


    }
}

