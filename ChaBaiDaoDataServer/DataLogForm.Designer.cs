
namespace DataServer
{
    partial class DataLogForm
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
            this.timeLineView1 = new DataServer.view.TimeLineView();
            this.SuspendLayout();
            // 
            // timeLineView1
            // 
            this.timeLineView1.AutoScroll = true;
            this.timeLineView1.AutoSize = true;
            this.timeLineView1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timeLineView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeLineView1.Location = new System.Drawing.Point(0, 61);
            this.timeLineView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timeLineView1.Name = "timeLineView1";
            this.timeLineView1.Size = new System.Drawing.Size(800, 389);
            this.timeLineView1.TabIndex = 3;
            // 
            // DataLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyleColor = System.Drawing.Color.Maroon;
            this.BorderStyleSize = 10;
            this.BorderStyleType = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.timeLineView1);
            this.FrmTitle = "点击返回(退出)";
            this.IsFullSize = false;
            this.Name = "DataLogForm";
            this.Text = "DataLogForm";
            this.Controls.SetChildIndex(this.timeLineView1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private view.TimeLineView timeLineView1;
    }
}