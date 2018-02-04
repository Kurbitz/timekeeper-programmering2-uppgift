using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper
{   [Serializable]
    public class Project
    {
        public string name { get; set;}
        public List<double> times { get; set;}
        public double time { get; set;}

        public Project()
        {

        }
        
    }
}
