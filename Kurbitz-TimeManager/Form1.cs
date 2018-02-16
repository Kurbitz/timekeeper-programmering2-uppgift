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
            InitializeListView();
            LoadData();
            UpdateList();        
            
        }

        private void InitializeListView()
        {

            listViewTasks.Columns.Add("Task", 170, HorizontalAlignment.Left);
            listViewTasks.Columns.Add("Time spent", -2, HorizontalAlignment.Left);
            listViewTasks.Columns.Add("Date Created", -2, HorizontalAlignment.Left);
            var item1 = new ListViewItem(new[] {"Task1","00:04:20","16-02-18"});
            listViewTasks.Items.Add(item1);
        }

        void LoadData()
        {
            SaveLoad sl = new SaveLoad();
            project = sl.LoadFromFile();
        }

        public void UpdateList()
        {
            listViewTasks.Items.Clear();
            List<Task> tasks = project.GetProjectTasks();

            foreach (Task task in tasks)
            {
                var listItem = new ListViewItem(new[] { task.Name,
                    task.totalTime.ToString(),
                    task.DateCreated.ToShortDateString() + " " + task.DateCreated.ToShortTimeString() });
                listViewTasks.Items.Add(listItem);
                
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

        private void listViewTasks_DoubleClick(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedIndices.Count > 0 )
            {
                Task task = project.GetTask(listViewTasks.SelectedIndices[0]);
                TimeTaskForm ttm = new TimeTaskForm(project, task, this);
                ttm.Show();
                UpdateList();
            }
        }
    }
}
