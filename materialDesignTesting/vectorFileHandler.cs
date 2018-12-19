using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace materialDesignTesting
{
    class vectorFileHandler
    {



public double[] WriteToFile(string path=@"C:\projTest\vector.txt",string output=@"C:\projTest\wtest.txt")
{
        //write to file
     //string path = @"C:\projTest\vector.txt";
     //string output = @"C:\projTest\wtest.txt";
     string[] val = { "aa", "b", "c" };
    double[] realval;
     try
     {
        

         StringBuilder builder = new StringBuilder();
         for (int i = 0; i < val.Length; i++)
             builder.AppendLine(val[i]);

         File.WriteAllText(output, builder.ToString());
         return
     }
     catch (Exception err)
     {
         Console.WriteLine(err.Message);
     }



}

public double[] readVector(string path)
        {
            string[] text;
            double[] realval;
              try
                 {
                      if (!File.Exists(path))
                         {
                           Console.WriteLine("file not exist");
                            //return ;
                           }

                        text = File.ReadAllLines(path);
         for (int i = 0; i < text.Length; i++)
         {
             var temp = text[i].Replace("\t", "").Split(' ');
             realval[i] =Int32( temp[i]);
         }
         return realval;
     }
     catch (Exception err)
     {
         Console.WriteLine(err.Message);
     }


        }
    }
}
