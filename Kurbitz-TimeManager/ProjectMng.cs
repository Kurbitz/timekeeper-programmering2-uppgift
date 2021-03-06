﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurbitz_TimeManager
{
    public class ProjectMng
    {
        public string Name;
        private DateTime DateCreated;
        private List<TimeTask> taskList;


        private Project projectSave;


        public ProjectMng(Project _projectSave)
        {
            this.projectSave = _projectSave;
            if (Form1.OnCreation)
            {
                Project project = CreateProject();
                this.projectSave = project;
            }
            Name = projectSave.Name;
            DateCreated = projectSave.DateCreated;
            taskList = projectSave.TimeTaskList;
        }

        public Project CreateProject(string _name = "Untitled")
        {
            projectSave = new Project();
            List<TimeTask> newTimeTaskList = new List<TimeTask>();
            projectSave.Name = _name;
            projectSave.DateCreated = DateTime.Now;
            projectSave.TimeTaskList = newTimeTaskList;
            Form1.OnCreation = false;
            return projectSave;
        }

        public void SyncProject()
        {
            projectSave.Name = this.Name;
            projectSave.TimeTaskList = this.taskList;
            
        }

        public bool AddTask(string name)
        {
            if (FindTask(name) != null)
                return false;

            taskList.Add(new TimeTask(name));
            return true;
        }

        public void RemoveTask()
        {

        }

        public TimeTask FindTask(string name)
        {
            if (taskList != null)
            {
                foreach (TimeTask task in taskList)
                {
                    if (task.Name == name)
                        return task;
                }
            }
            
            return null;
        }

        public List<TimeTask> GetProjectTasks()
        {
            return taskList;
        }

        public TimeTask GetTask(int index)
        {
            return taskList[index];
        }
    }
}