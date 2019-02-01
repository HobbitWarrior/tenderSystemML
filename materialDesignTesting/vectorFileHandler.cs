using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace materialDesignTesting
{



    public class vectorFileHandler
    {


    vectorFileHandler test = new vectorFileHandler();    
    public List<double> realval = new List<double>();
    public List<double> read_val = new List<double>();
    bool x;
  public string path = @"C:\projTest\vector.txt";
  public string output = @"C:\projTest\wtest.txt";
    



        public vectorFileHandler()
        {
            realval.Add(1);
            realval.Add(2);
            realval.Add(3);
            x = WriteToFile(output, realval);
            read_val = readFromeFile(path);

        }

  public  bool WriteToFile(string output ,List<double>val)
{
   
    
     try
     {

       //  if (!File.Exists(output))
      //   {
         //    Console.WriteLine("file not exist");
         //    File.Create(output);
        // }
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

  public  List<double> readFromeFile(string path)
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






    }


    
}
