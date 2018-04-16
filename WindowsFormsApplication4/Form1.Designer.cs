namespace WindowsFormsApplication4
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.screen = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gametimer = new System.Windows.Forms.Timer(this.components);
            this.shot_timer = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btn_restart = new System.Windows.Forms.Button();
            this.screen.SuspendLayout();
            this.SuspendLayout();
            // 
            // screen
            // 
            this.screen.Controls.Add(this.btn_restart);
            this.screen.Controls.Add(this.label1);
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.Location = new System.Drawing.Point(0, 0);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(584, 562);
            this.screen.TabIndex = 0;
            this.screen.TabStop = true;
            this.screen.Paint += new System.Windows.Forms.PaintEventHandler(this.screen_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gametimer
            // 
            this.gametimer.Enabled = true;
            this.gametimer.Interval = 10;
            this.gametimer.Tick += new System.EventHandler(this.gametimer_Tick);
            // 
            // shot_timer
            // 
            this.shot_timer.Enabled = true;
            this.shot_timer.Interval = 120;
            this.shot_timer.Tick += new System.EventHandler(this.shot_timer_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Stencil", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(470, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            // 
            // btn_restart
            // 
            this.btn_restart.BackColor = System.Drawing.SystemColors.Control;
            this.btn_restart.Enabled = false;
            this.btn_restart.Font = new System.Drawing.Font("Stencil", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_restart.Location = new System.Drawing.Point(198, 232);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(215, 83);
            this.btn_restart.TabIndex = 1;
            this.btn_restart.Text = "Restart ";
            this.btn_restart.UseVisualStyleBackColor = false;
            this.btn_restart.Visible = false;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.screen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.screen.ResumeLayout(false);
            this.screen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel screen;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer gametimer;
        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Timer shot_timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_restart;
    }
}

