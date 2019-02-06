using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace materialDesignTesting
{
    class jsonHandler
    {
        #region  fields and properties
        private String json; 
        #endregion


        public jsonHandler() { }

        public jsonHandler(String json)
        {
            if (json == null)
                throw new Exception("The application encountered an error. you attempted to pass an empty JSON response.");
            this.json = json;

        }

        /// <summary>
        /// the following method will deserialize a JSON response with three arrays to the 
        /// resultArray instance.
        /// </summary>
        /// <returns>resultArrays</returns>
        public resultArrays deserialize()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            System.Console.WriteLine(json);
            resultArrays[] r = ser.Deserialize<resultArrays[]>(json);
            System.Console.WriteLine("this is the json respone:");

            //remove later girl
            System.Console.WriteLine("result array");
            double[] array = r[0].outcome;
            foreach (double val in array)
                System.Console.Write("{0}", val);

            System.Console.WriteLine("result array");
            array = r[0].average;
            foreach (double val in array)
                System.Console.Write("{0}", val);

            System.Console.WriteLine("result array");
            array = r[0].expectation;
            foreach (double val in array)
                System.Console.Write("{0}", val);
            //end of remove
           
            return r[0];
        }


        //remove babe
        //a string to emulate a json that is received from the stdout
        //tring json = "[{\"average\":[0.0,0.0,0.0,0.0],\"expectation\":[0.0,0.0,0.0,0.0],\"outcome\":[0.0,0.0,0.0,0.0]}]";
    }
}







/////<summary>
/////properties to hold the graph arrays in the LiveCharts format
/////</summary>
//public SeriesCollection Outcome = new SeriesCollection();
//public SeriesCollection Average = new SeriesCollection();
//public SeriesCollection Expectation = new SeriesCollection();
//#endregion


//#region methods
///// <summary>
///// A method to deserialize a JSON object.
///// </summary>
///// <param name="json"></param>
//public void deserializeJSON(String json)
//{

//}
//#endregion