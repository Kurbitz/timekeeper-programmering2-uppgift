using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurbitz_TimeManager
{
    public class Task
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan totalTime;

        public Task(string name)
        {
            Name = name;
            DateCreated = DateTime.Now;
            totalTime = TimeSpan.Zero;
        }

        public void AddTime(TimeSpan time)
        {
            totalTime = time;
        }

        
    }
}
