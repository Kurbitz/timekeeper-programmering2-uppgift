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
        Project projectSave;
        ProjectMng mng;
        static public bool OnCreation { get; set; }
        public Form1()
        {
            OnCreation = true;
            InitializeComponent();
            InitializeListView();
            projectSave = new Project();
            this.mng = new ProjectMng(projectSave);
            LoadData();
            UpdateList();        
            
        }

        private void InitializeListView()
        {

            listViewTasks.Columns.Add("TimeTask", 170, HorizontalAlignment.Left);
            listViewTasks.Columns.Add("Time spent", -2, HorizontalAlignment.Left);
            listViewTasks.Columns.Add("Date Created", -2, HorizontalAlignment.Left);
            var item1 = new ListViewItem(new[] {"Task1","00:04:20","16-02-18"});
            listViewTasks.Items.Add(item1);
        }

        void LoadData()
        {
            
        }

        public void UpdateList()
        {
            listViewTasks.Items.Clear();
            List<TimeTask> tasks = mng.GetProjectTasks();
            this.Text = projectSave.Name;
            if (tasks != null)
            {
                foreach (TimeTask task in tasks)
                {
                    string timeString =
                    string.Format("{0:00}:{1:00}:{2:00}",
                                  task.totalTime.Hours,
                                  task.totalTime.Minutes,
                                  task.totalTime.Seconds);
                    var listItem = new ListViewItem(new[] { task.Name,
                    timeString,
                    task.DateCreated.ToShortDateString() + " " + task.DateCreated.ToShortTimeString() });
                    listViewTasks.Items.Add(listItem);

                }
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask at = new AddTask(mng);
            at.ShowDialog();

            UpdateList();
        }

        private void nyttProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO Save before vreating new project
            using (NewProject np = new NewProject())
            {
                DialogResult dr = np.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Project newProject = CreateProject(np.ProjectName);
                    ProjectMng projectMng = new ProjectMng(newProject);
                    this.mng = projectMng;
                    this.projectSave = newProject;
                
                }
            }

            UpdateList();            
            
        }

        public Project CreateProject(string _name)
        {
            Project newProjectSave = new Project();
            newProjectSave.Name = _name;
            newProjectSave.DateCreated = DateTime.Now;
            newProjectSave.TimeTaskList = new List<TimeTask>();
            return newProjectSave;
        }

        private void listViewTasks_DoubleClick(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedIndices.Count > 0 )
            {
                TimeTask task = mng.GetTask(listViewTasks.SelectedIndices[0]);
                TimeTaskForm ttm = new TimeTaskForm(mng, task, this);
                ttm.Show();
                UpdateList();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLoad sl = new SaveLoad();
            sl.SaveToFile(projectSave, projectSave.Name);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "c:\\";
            fileDialog.Filter = "Project data files|*.dat";
            fileDialog.Title = "Select a project file";
            fileDialog.RestoreDirectory = true;
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveLoad sl = new SaveLoad();
                this.Text = fileDialog.FileName;
            }
        }

        private void rmvBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
