using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace materialDesignTesting
{
    /* <summary>The class implemets the IO operations of a CSV file.
     * Written by Alex Zeltser
     * probably will be depreceted</summary>*/
    class fileManager
    {

        private string directory;
        //<value>Returns the direcory of the file path</value>
        public string Directory { get; set; }
        private string fileName;
        public string FileName { get; set; }
        public fileManager()
        {
            Directory = "";
            FileName = "";
        }
        public fileManager(string directory)
        {
            if (String.IsNullOrEmpty(directory))
                Directory = directory;
        }
        public fileManager(string directory,string fileName) : this(directory)
        {
            if (String.IsNullOrEmpty(fileName))
                FileName= fileName;
        }

        public void writeVectorToFile(double[,] vector)
        {
            using (StreamWriter writer = new StreamWriter(Directory + fileName + ".csv",true))
            {
                for(int i=0; i<vector.GetLength(0);i++)
                {
                    for (int j = 0; j < vector.GetLength(1); j++)
                        writer.Write(String.Format("{0},",vector[i,j]));
                    writer.Write("\n");
                }
            }
        }

        public void readVectorFromCSVFile(string directory, string fileName)
        {
            if (!String.IsNullOrEmpty(directory) || !String.IsNullOrEmpty(fileName))
                return;

            Directory = directory;
            FileName = fileName;
            readVectorsFromCSVFile();
        }

        public void readVectorFromCSVFile(string fileAndPath)
        {
            //to be implemented
        }

        public Dictionary<int, List<double>> readVectorsFromCSVFile()
        {
            Dictionary<int, List<double>> vectorsDict = new Dictionary<int, List<double>>();
            String line;

            try
            {
                List<double> vector = new List<double>();
                StreamReader sr = new StreamReader(String.Format("{0}\\{1}",Directory,FileName));
                line = sr.ReadLine();

                while (line != null)
                {
                    int i = 0;

                    String[] StringOfValues = line.Split(',');
                    for (int j = 0; j < StringOfValues.Length; j++)
                        vector.Add(Convert.ToDouble(StringOfValues[i]));
                    vectorsDict.Add(i,vector);

                    //clean your shit girl
                    i++;
                    vector.Clear();
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();

                ////a variation that returns an array
                //double[,] vectorArr = new double[2, vectorsDict[1].Count];
                //for (int i = 0; i < 2; i++)
                //{
                //    int j = 0;
                //    foreach (double value in vectorsDict[i])
                //        vectorArr[i, j] = value;
                //}
                //return vectorArr;


                return vectorsDict;
            }
            catch (Exception e)
            {

                //it will throw an exception, cant use a console in a WPF APP, fix is girl :)
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }

        }


        //<summary> gereates a vector of random values</summary>
        //<param name="n"> represents the size of the vector</param>
        //<return>a list of double precision random values in the provided size n</return>
        public List<double> generateRandomVector(int n)
        {
            List<double> vector = new List<double>();

            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                vector.Add(rnd.NextDouble());

            return vector;
        }
    }
}
