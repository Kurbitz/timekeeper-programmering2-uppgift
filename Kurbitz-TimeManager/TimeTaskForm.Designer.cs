namespace Kurbitz_TimeManager
{
    partial class TimeTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.elapsedTimeDisplay = new System.Windows.Forms.Label();
            this.btnComplete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(58, 165);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // elapsedTimeDisplay
            // 
            this.elapsedTimeDisplay.AutoSize = true;
            this.elapsedTimeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeDisplay.Location = new System.Drawing.Point(79, 70);
            this.elapsedTimeDisplay.Name = "elapsedTimeDisplay";
            this.elapsedTimeDisplay.Size = new System.Drawing.Size(120, 31);
            this.elapsedTimeDisplay.TabIndex = 1;
            this.elapsedTimeDisplay.Text = "00:00:00";
            // 
            // btnComplete
            // 
            this.btnComplete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnComplete.Location = new System.Drawing.Point(139, 165);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(75, 23);
            this.btnComplete.TabIndex = 2;
            this.btnComplete.Text = "Done!";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // TimeTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 246);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.elapsedTimeDisplay);
            this.Controls.Add(this.btnStart);
            this.Name = "TimeTaskForm";
            this.Text = "TimeTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label elapsedTimeDisplay;
        private System.Windows.Forms.Button btnComplete;
    }
}