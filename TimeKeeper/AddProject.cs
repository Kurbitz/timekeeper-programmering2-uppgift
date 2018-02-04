using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeKeeper
{
    public partial class AddProject : Form
    {
        Project project;
        public AddProject(Project project)
        {
            InitializeComponent();
            this.project = project;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
