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
        //string python = @"E:/Python37";
        string python = @"cmd.exe";
        // python app to call
        string myPythonApp = @" /c python C:/Demo.py";
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
        //String[] args = { "n0", "m", "y", "z", "w" };
        Double[] args = { 1000, 0.25 , 0.25 , 0.25 , 0.25 };


        /// <summary>
        /// A helper function that combines a string array to a single string
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private String convertArrToString(Double[] arr)
        {
            String str = "";
            foreach (Double Val in arr)
                str+= String.Format("{0} ", Val);
            return str;
        }

        // Create new process start info
        public bool isDone = false;
        public externalProcessRunner()
        {
        }
        /// <summary>
        /// the following method will call an external python script,
        /// and return an array of the JSON response.
        /// </summary>
        /// <returns></returns>
        public resultArrays runCmd()
        {
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo();
            myProcessStartInfo.FileName = python;
            myProcessStartInfo.Arguments = String.Format("{0} {1}", myPythonApp, convertArrToString(args));
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            using (Process process = Process.Start(myProcessStartInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                    jsonHandler jh = new jsonHandler(result);
                    resultArrays ra = jh.deserialize();
                    return ra;
                }
            }
        }
    }
}
