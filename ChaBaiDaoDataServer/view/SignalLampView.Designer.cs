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
            this.title = new System.Windows.Forms.Label();
            this.picComputer1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picComputer1)).BeginInit();
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
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(130, -1);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(430, 200);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "标题";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.ForeColor = System.Drawing.Color.Green;
            this.title.Location = new System.Drawing.Point(111, 20);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(188, 19);
            this.title.TabIndex = 29;
            this.title.Text = "已加入的数拓设备:";
            // 
            // picComputer1
            // 
            this.picComputer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picComputer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picComputer1.Image = global::ChaBaiDaoDataServer.Properties.Resources.computer1;
            this.picComputer1.Location = new System.Drawing.Point(14, 58);
            this.picComputer1.Name = "picComputer1";
            this.picComputer1.Size = new System.Drawing.Size(96, 94);
            this.picComputer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picComputer1.TabIndex = 30;
            this.picComputer1.TabStop = false;
            // 
            // SignalLampView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picComputer1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.ucAlarmLamp1);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SignalLampView";
            this.Size = new System.Drawing.Size(560, 200);
            ((System.ComponentModel.ISupportInitialize)(this.picComputer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private HZH_Controls.Controls.UCAlarmLamp ucAlarmLamp1;
        private System.Windows.Forms.Label lblTitle;
        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox picComputer1;
    }
}