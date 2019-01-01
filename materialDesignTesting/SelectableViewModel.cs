using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace materialDesignTesting
{
    class SelectableViewModel
    {
        public char Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Food {get;set;}
        public bool IsSelected { get; set; }
    }
}
