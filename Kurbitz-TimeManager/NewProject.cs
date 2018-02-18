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
    public partial class NewProject : Form
    {
        public string ProjectName { get; set; }
        public NewProject()
        {
            InitializeComponent();
            
        }

        public void btnAccept_Click(object sender, EventArgs e)
        {
            ProjectName = lblName.Text;
        }
    }
}
