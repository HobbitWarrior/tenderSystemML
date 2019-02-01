using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace materialDesignTesting
{
    class externalProcessRunner
    {
        // full path of python interpreter  
        string python = @"C:\Program Files\Python37\python.exe";

        // python app to call  
        string myPythonApp = "Demo.py";


        public string myString = "";
        // Create new process start info 
        public bool isDone = false;
        public externalProcessRunner()
        {
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;

            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;

            // start process 
            myProcess.Start();

            // Read the standard output of the app we called.  
            StreamReader myStreamReader = myProcess.StandardOutput;
            myString = myStreamReader.ReadLine();

            // System.Console.WriteLine(myString);
            ViewsMediator.pythonRunResult = myString;
            // wait exit signal from the app we called 
            myProcess.WaitForExit();

            // close the process 
            myProcess.Close();
            isDone = true;

        }


      
    }
}
