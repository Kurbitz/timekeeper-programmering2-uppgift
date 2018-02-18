using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurbitz_TimeManager
{
    [Serializable]
    public class Project
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public List<TimeTask> TimeTaskList { get; set; }
    }
}
