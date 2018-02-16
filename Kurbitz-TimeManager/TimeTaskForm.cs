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
        Project project;
        Task task;
        Form form;
        private Timer timer;
        TimeSpan elapsedTime;
        private Stopwatch watch;
        private DateTime startTime;
        string timeString;
        private bool timerRunning;
        private bool firstRun = true;
        
        public TimeTaskForm(Project project, Task task, Form1 form)
        {            
            InitializeComponent();
            this.project = project;
            this.task = task;
            this.form = form;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (Timer_Tick);

            watch = new Stopwatch();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime = watch.Elapsed;
            //timeString = elapsedTime.Hours.ToString() + ":" + elapsedTime.Minutes.ToString() + ":" + elapsedTime.Seconds.ToString();

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
            
            task.AddTime(elapsedTime);

            this.Close();
        }
    }
}
