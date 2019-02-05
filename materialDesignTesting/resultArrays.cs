using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Web.Script.Serialization;

namespace materialDesignTesting
{
    /// <summary>
    /// the following class will save the resulkts that are returned from the a JSON object
    /// after deserialization.
    /// </summary>
    class resultArrays
    {
        #region fields and properties
        public double[] outcome;
        public double[] average;
        public double[] expectation;
        #endregion
    }


}
