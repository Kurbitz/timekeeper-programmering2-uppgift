using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurbitz_TimeManager
{
    public partial class Form1 : Form
    {
        Project project;
        public Form1()
        {
            InitializeComponent();
            LoadData();
            UpdateList();
        }

        void LoadData()
        {
            SaveLoad sl = new SaveLoad();
            project = sl.LoadFromFile();
        }

        void UpdateList()
        {
            listTasks.Items.Clear();
            List<Task> tasks = project.GetProjectTasks();

            foreach (Task task in tasks)
            {
                listTasks.Items.Add(task.Name);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask at = new AddTask(project);
            at.ShowDialog();

            UpdateList();
        }

        private void nyttProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
