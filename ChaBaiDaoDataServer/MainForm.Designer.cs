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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panControl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.自动开机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainUpdateNetIp = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panControl
            // 
            this.panControl.AutoScroll = true;
            this.panControl.AutoSize = true;
            this.panControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panControl.Location = new System.Drawing.Point(0, 61);
            this.panControl.Name = "panControl";
            this.panControl.Size = new System.Drawing.Size(560, 0);
            this.panControl.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Image = global::ChaBaiDaoDataServer.Properties.Resources.interface1;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(333, 280);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "     点击检查POS数据接口状态";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Image = global::ChaBaiDaoDataServer.Properties.Resources.minImage;
            this.label2.Location = new System.Drawing.Point(470, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "           ";
            this.label2.Click += new System.EventHandler(this.MinClose_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自动开机ToolStripMenuItem,
            this.显示窗体ToolStripMenuItem,
            this.隐藏窗体ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // 自动开机ToolStripMenuItem
            // 
            this.自动开机ToolStripMenuItem.Name = "自动开机ToolStripMenuItem";
            this.自动开机ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.自动开机ToolStripMenuItem.Text = "自动开机";
            // 
            // 显示窗体ToolStripMenuItem
            // 
            this.显示窗体ToolStripMenuItem.Name = "显示窗体ToolStripMenuItem";
            this.显示窗体ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.显示窗体ToolStripMenuItem.Text = "显示窗体";
            // 
            // 隐藏窗体ToolStripMenuItem
            // 
            this.隐藏窗体ToolStripMenuItem.Name = "隐藏窗体ToolStripMenuItem";
            this.隐藏窗体ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.隐藏窗体ToolStripMenuItem.Text = "隐藏窗体";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "数拓工具";
            this.notifyIcon1.Visible = true;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // mainUpdateNetIp
            // 
            this.mainUpdateNetIp.AutoSize = true;
            this.mainUpdateNetIp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainUpdateNetIp.ForeColor = System.Drawing.Color.ForestGreen;
            this.mainUpdateNetIp.Location = new System.Drawing.Point(12, 284);
            this.mainUpdateNetIp.Name = "mainUpdateNetIp";
            this.mainUpdateNetIp.Size = new System.Drawing.Size(0, 17);
            this.mainUpdateNetIp.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BorderStyleColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(560, 320);
            this.Controls.Add(this.mainUpdateNetIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panControl);
            this.IsShowCloseBtn = true;
            this.Name = "MainForm";
            this.ShowInTaskbar = true;
            this.Title = "哗啦啦-数拓网络检测";
            this.Controls.SetChildIndex(this.panControl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.mainUpdateNetIp, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }







        #endregion

        private System.Windows.Forms.Panel panControl;
        private Label label1;
        private Label label2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 显示窗体ToolStripMenuItem;
        private ToolStripMenuItem 隐藏窗体ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem 自动开机ToolStripMenuItem;
        private Label mainUpdateNetIp;
    }
}

