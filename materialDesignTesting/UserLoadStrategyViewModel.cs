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
    //<summary>Dont forget to wirte summary</summary>



    /// <summary>
    /// In this class give the option to load user's strategy
    /// </summary>
    class UserLoadStrategyViewModel :INotifyPropertyChanged
    {
        public UserLoadStrategyViewModel()
        {
            canExecute = true;     
        }
        #region fields and properties
        private bool canExecute;
        private ICommand clickOnBrowseButton;
        public ICommand ClickOnBrowseButton
        {
            get
            {
                return clickOnBrowseButton ?? (clickOnBrowseButton = new CommandHandler(() => openDialog(), canExecute));
            }
        }


        private String fileName = "[PlaceHolder]";


        public String FileName
        {
            get { return fileName; }
            set {
                fileName = value;
                RaisePropertyChanged();
            }
        }


        private List<Double> _userVector = new List<double>();
        public List<Double> userVector
        {
            get { return _userVector; }
            set { _userVector = (_userVector!= value && value != null) ? value : _userVector; }
        }

        #endregion


        ///<summary>
        ///The following method is handling the opening of a new dialog event
        ///</summary>
        public void openDialog()
        {
            Console.WriteLine("Just called a button click event!!!! Yay! :)");

            //Open dialog
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Gets the selected file name and display it in a TextBox.S
            //load the contents ffrom the file in a TextBlock
            if (result == true)
            {
                FileName= openFileDlg.FileName;
                //this method will read all the contents of the provided file
                //FileName = System.IO.File.ReadAllText(openFileDlg.FileName);
                Console.WriteLine("the opendialog.filename:  {0}", FileName);
                //A temp method, returns a 1000 dimensional Vector
                genetrateRandomVector(1000);


                //queues a success message in the snackBar
                MainWindow.Snackbar.MessageQueue.Enqueue("File Successfully Loaded");
                vectorFileHandler vfm = new vectorFileHandler();
                userVector = vfm.readFromFile("userOutcome.csv");
                if (userVector.Count > 0)
                {
                    //store in the view mediator
                    ViewsMediator.User = userVector;
                    //set expander to false
                    ViewsMediator.userExpander = "False";
                    ViewsMediator.opponentExpander = "True";

                    Console.WriteLine("The following vectors were generated: ");
                    Console.WriteLine("User: ");
                    foreach (double value in ViewsMediator.User)
                        Console.Write("{0} ", value);
                    Console.WriteLine("\nOpponent: ");
                    foreach (double value in ViewsMediator.Opponent)
                        Console.Write("{0} ", value);

                    //queues a success message in the snackBar
                    MainWindow.Snackbar.MessageQueue.Enqueue("File Successfully Loaded");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        ///<summary>
        ///A temp stub function that instantiates the two probability vectors
        ///</summary
        private void genetrateRandomVector(int n)
        {
            fileManager fl = new fileManager();
            ViewsMediator.User = fl.generateRandomVector(1000);
            ViewsMediator.Opponent = fl.generateRandomVector(1000);
        }
    }
}
