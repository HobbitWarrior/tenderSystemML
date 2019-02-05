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
        externalProcessRunner(string pythonPath, String scriptPath)
        {
            //validate and initialize the values
            if(!String.IsNullOrEmpty(pythonPath)&&String.IsNullOrEmpty(scriptPath))
            {
                python = pythonPath;
                myPythonApp = scriptPath;
            }
        }

        /// <summary>
        ///a temp variable to hold all the parameters that are sent to the function
        /// </summary>
        String[] args = { "n0", "m", "y", "z", "w" };


        /// <summary>
        /// A helper function that combines a string array to a single string
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private String convertArrToString(String[] arr)
        {
            String str = "";
            foreach (String Val in arr)
                str+= String.Format("{0} ", Val);
            return str;
        }
        
        // Create new process start info 
        public bool isDone = false;
        public externalProcessRunner()
        {
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout, and disable the shell
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            //Build the arguments String.
            myProcessStartInfo.Arguments = String.Format("{0} {1}", myPythonApp, convertArrToString(args));
            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;

            // start process 
            myProcess.Start();

            // Read the standard output of the app we called.  
                using (StreamReader reader = myProcess.StandardOutput)
                {
                    string myString = reader.ReadToEnd();
                     //write the result to the console and save them in the static viewsMediator
                    System.Console.WriteLine(myString);
                    ViewsMediator.pythonRunResult = myString;
                    // wait exit signal from the app we called 
                    myProcess.WaitForExit();

                    // close the process 
                    myProcess.Close();
                    isDone = true;

                }
        }

        public void run_cmd()
        {
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo();
            myProcessStartInfo.FileName = "my/full/path/to/python.exe";
            myProcessStartInfo.Arguments = String.Format("{0} {1}", myPythonApp, convertArrToString(args));
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            using (Process process = Process.Start(myProcessStartInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }



    }
}
