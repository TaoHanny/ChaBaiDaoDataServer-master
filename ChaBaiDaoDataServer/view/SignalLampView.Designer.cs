namespace DataServer.view
{
    partial class SignalLampView
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
            this.ucAlarmLamp1 = new HZH_Controls.Controls.UCAlarmLamp();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucAlarmLamp1
            // 
            this.ucAlarmLamp1.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))))};
            this.ucAlarmLamp1.Lampstand = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ucAlarmLamp1.Location = new System.Drawing.Point(29, 75);
            this.ucAlarmLamp1.Name = "ucAlarmLamp1";
            this.ucAlarmLamp1.Size = new System.Drawing.Size(70, 71);
            this.ucAlarmLamp1.TabIndex = 28;
            this.ucAlarmLamp1.TwinkleSpeed = 200;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblTitle.Location = new System.Drawing.Point(130, -1);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(394, 200);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "标题";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SignalLampView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucAlarmLamp1);
            this.Controls.Add(this.lblTitle);
            this.Name = "SignalLampView";
            this.Size = new System.Drawing.Size(524, 200);
            this.ResumeLayout(false);

        }
        private HZH_Controls.Controls.UCAlarmLamp ucAlarmLamp1;
        private System.Windows.Forms.Label lblTitle;
        #endregion
    }
}