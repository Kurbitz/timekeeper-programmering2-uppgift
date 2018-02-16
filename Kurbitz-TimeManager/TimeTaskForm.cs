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
        private Timer timer;
        TimeSpan elapsedTime;
        private Stopwatch watch;
        private DateTime startTime;
        string timeString;
        private bool timerRunning;
        private bool firstRun = true;
        
        public TimeTaskForm(Project project, Task task)
        {            
            InitializeComponent();
            this.project = project;
            this.task = task;

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
            timer.Start();
            watch.Start();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
      
        }
    }
}
