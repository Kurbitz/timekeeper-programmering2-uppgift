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
    public partial class AddTask : Form
    {
        private Project project;
        public AddTask(Project project)
        {
            InitializeComponent();
            this.project = project;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            project.AddTask(txtName.Text);
            Task task = project.FindTask(txtName.Text);            
            TimeTaskForm ttm = new TimeTaskForm(project, task);
            this.Close();
            ttm.ShowDialog();
            
        }
    }
}
