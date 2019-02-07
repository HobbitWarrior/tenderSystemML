using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace materialDesignTesting
{

    /// <summary>
    /// A helper class to read CSV files 
    /// </summary>



    public class vectorFileHandler
    {


   // vectorFileHandler test = new vectorFileHandler();    
    public List<double> realval = new List<double>();
    public List<double> read_val = new List<double>();
    bool x;
    public string path = @"C:\projTest\vector.txt";
    public string output = @"C:\projTest\wtest.txt";




        /// <summary>
        /// this function writen to file
        /// </summary>
        /// <param name="output">the path of the file that we want to write.</param>
        ///  <param name="val">list that stores the contents that we want to writ to file.</param>
        /// <returns>
        /// return 1 if the writing was successful ,else return 0  
        /// </returns>


        public bool WriteToFile(string output ,List<double>val)
        {
            try
            {
            StringBuilder builder = new StringBuilder();
            foreach( double item in val )
                 builder.Append(String.Format("{0} ",item));

         File.WriteAllText(output, builder.ToString());
         return true;
     }
     catch (Exception err)
     {
         Console.WriteLine(err.Message);
     }

     return false;

}


        /// <summary>
        /// this function is read from file
        /// </summary>
        /// <param name="path">the path of the file that we want to read.</param>
        /// <returns>
        /// return list that stores the contents of the file  
        /// </returns>

        public List<double> readFromFile(string path)
        {
            string[] text;
            List<double> realval = new List<double>();
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("file not exist");
                    return null ;
                }

                text = File.ReadAllLines(path);
                for (int i = 0; i < text.Length; i++)
                {
                    var temp = text[i].Replace("\t", "").Split(' ');
                    for (int j = 0; j < (temp.Length-1); j++)
                        realval.Add(double.Parse(temp[j]));
                }
                return realval;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            return null;
        }

        /// <summary>
        /// Reads a vector from the provided file, removes commas, spaces and newline chars
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public List<Double> readFromFileVer2(String file)
        {
            if (String.IsNullOrEmpty(file))
                return new List<double>();
            try
            {
                var lines = File.ReadAllLines(file);
                List<Double> vector = new List<double>();
                foreach (string line in lines)
                    vector.Add(Convert.ToDouble(line.Replace(",", "").Replace("\n", "").Replace(" ","")));
                System.Console.WriteLine(vector);
                return vector;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("error in reading file.\n {0}", ex.Message);
            }
            return null;
        }



    }


    
}
