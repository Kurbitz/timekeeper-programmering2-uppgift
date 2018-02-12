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
    public partial class TimeTaskForm : Form
    {
        Project project;
        Task task;
        private Timer timer;
        private DateTime startTime;
        private int elapsedTime = 0;
        private bool timerRunning;
        private bool notFirst = false;
        
        public TimeTaskForm(Project project, Task task)
        {            
            InitializeComponent();
            this.project = project;
            this.task = task;

            // Create a new timer and trigger the Tick event once per 1000ms.
            timer = new Timer();
            timer.Interval = 1000;          
            
            timer.Tick += new EventHandler(TimerTick);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var timeSinceStart = new DateTime(timeSinceStart.Hour, timeSinceStart.Minute, timeSinceStart.Second);
            elapsedTime++;
            elapsedTimeDisplay.Text = timeSinceStart.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // If the timer already isn't running
            if (!timerRunning)
            {
                // Set start time to now
                if (!notFirst)
                {
                    startTime = DateTime.Now;
                    notFirst = true;
                }
                ;
                timer.Start();
                timerRunning = true;
            }
            else
            {
                timer.Stop();      
                timerRunning = false;
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            timer.Stop();
            task.AddTime(totalElapsedTime);
            Close();            
        }
    }
}
