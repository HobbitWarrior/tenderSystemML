using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace materialDesignTesting
{
    class UserLoadStrategyViewModel :INotifyPropertyChanged
    {
        public UserLoadStrategyViewModel()
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


        private String fileName = "[PlaceHolder]";

        public event PropertyChangedEventHandler PropertyChanged;

        public String FileName
        {
            get { return fileName; }
            set {
                fileName = value;
                RaisePropertyChanged();
            }
        }

        public void MyAction()
        {
            Console.WriteLine("Just called a button click event!!!! Yay! :)");

            //Open dialog
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                FileName= openFileDlg.FileName;
                //this method will read all the contents of the provided file
                //FileName = System.IO.File.ReadAllText(openFileDlg.FileName);
                Console.WriteLine(String.Format("the opendialog.filename:  {0}", FileName));
            }
        }


        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
