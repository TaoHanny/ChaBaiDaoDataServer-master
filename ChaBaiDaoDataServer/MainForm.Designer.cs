using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChaBaiDaoDataServer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panControl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panControl
            // 
            this.panControl.AutoScroll = true;
            this.panControl.AutoSize = true;
            this.panControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panControl.Location = new System.Drawing.Point(0, 61);
            this.panControl.Name = "panControl";
            this.panControl.Size = new System.Drawing.Size(524, 0);
            this.panControl.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(342, 270);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "查看最新数据      ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BorderStyleColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(524, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panControl);
            this.IsShowCloseBtn = true;
            this.Name = "MainForm";
            this.Title = "哗啦啦-数拓网络检测";
            this.Controls.SetChildIndex(this.panControl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        #endregion

        private System.Windows.Forms.Panel panControl;
        private Label label1;
    }
}

