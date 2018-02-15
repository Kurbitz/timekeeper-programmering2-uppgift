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
        TimeSpan totalElapsedTime;
        private Stopwatch watch;
        private DateTime startTime;
        private bool timerRunning;
        private bool notFirst = false;
        
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
            TimeSpan elapsedTime = watch.Elapsed;
            totalElapsedTime = elapsedTime;
            string timeString = totalElapsedTime.Hours.ToString() + ":" + totalElapsedTime.Minutes.ToString() + ":" + totalElapsedTime.Seconds.ToString();
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
