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
        private DateTime DateCreated { get; set; }
        private List<Task> taskList;


        public Project(string name)
        {
            Name = name;
            DateCreated = DateTime.Now;
            taskList = new List<Task>();
        }

        public bool AddTask(string name)
        {
            if (FindTask(name) != null)
                return false;

            taskList.Add(new Task(name));
            return true;
        }

        public Task FindTask(string name)
        {
            foreach (Task task in taskList)
            {
                if (task.Name == name)
                    return task;
            }
            return null;
        }

        public List<Task> GetProjectTasks()
        {
            return taskList;
        }

        public Task GetTask(int index)
        {
            return taskList[index];
        }
    }
}