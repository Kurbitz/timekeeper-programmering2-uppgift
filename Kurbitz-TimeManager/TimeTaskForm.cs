using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurbitz_TimeManager
{
    public partial class TimeTaskForm : Form
    {
        private ProjectMng project;
        private TimeTask timeTask;
        private Form form;
        private Timer timer;
        private TimeSpan elapsedTime;
        private Stopwatch watch;
        string timeString;
        
        public TimeTaskForm(ProjectMng project, TimeTask timeTask, Form1 form)
        {            
            InitializeComponent();
            this.project = project;
            this.timeTask = timeTask;
            this.form = form;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (Timer_Tick);

            watch = new Stopwatch();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            elapsedTime = watch.Elapsed;
            timeString =
                string.Format("{0:00}:{1:00}:{2:00}",
                              elapsedTime.Hours,
                              elapsedTime.Minutes,
                              elapsedTime.Seconds);
            elapsedTimeDisplay.Text = timeString;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!watch.IsRunning)
            {
                timer.Start();
                watch.Start();
                btnStart.Text = "Stop";
            }
            else
            {
                timer.Stop();
                watch.Stop();
                btnStart.Text = "Start";
            }

        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            timer.Stop();
            watch.Stop();

            
            timeTask.AddTime(elapsedTime);
            var mainForm = Application.OpenForms.OfType<Form1>().Single();
            mainForm.UpdateList();
            this.Close();
        }
    }
}
