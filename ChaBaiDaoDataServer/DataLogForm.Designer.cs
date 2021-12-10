
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
            this.TextStatus1 = new System.Windows.Forms.Label();
            this.TextStatus2 = new System.Windows.Forms.Label();
            this.TextStatus3 = new System.Windows.Forms.Label();
            this.TextStatus4 = new System.Windows.Forms.Label();
            this.TextStatusTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextStatus1
            // 
            this.TextStatus1.AutoSize = true;
            this.TextStatus1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextStatus1.ForeColor = System.Drawing.Color.Gray;
            this.TextStatus1.Image = global::ChaBaiDaoDataServer.Properties.Resources.loading;
            this.TextStatus1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextStatus1.Location = new System.Drawing.Point(85, 121);
            this.TextStatus1.Name = "TextStatus1";
            this.TextStatus1.Size = new System.Drawing.Size(77, 22);
            this.TextStatus1.TabIndex = 3;
            this.TextStatus1.Text = "      菜单 ";
            this.TextStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextStatus2
            // 
            this.TextStatus2.AutoSize = true;
            this.TextStatus2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextStatus2.ForeColor = System.Drawing.Color.Gray;
            this.TextStatus2.Image = global::ChaBaiDaoDataServer.Properties.Resources.loading;
            this.TextStatus2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextStatus2.Location = new System.Drawing.Point(85, 175);
            this.TextStatus2.Name = "TextStatus2";
            this.TextStatus2.Size = new System.Drawing.Size(77, 22);
            this.TextStatus2.TabIndex = 4;
            this.TextStatus2.Text = "      售罄 ";
            this.TextStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextStatus3
            // 
            this.TextStatus3.AutoSize = true;
            this.TextStatus3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextStatus3.ForeColor = System.Drawing.Color.Gray;
            this.TextStatus3.Image = global::ChaBaiDaoDataServer.Properties.Resources.loading;
            this.TextStatus3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextStatus3.Location = new System.Drawing.Point(85, 226);
            this.TextStatus3.Name = "TextStatus3";
            this.TextStatus3.Size = new System.Drawing.Size(77, 22);
            this.TextStatus3.TabIndex = 5;
            this.TextStatus3.Text = "      订单 ";
            this.TextStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextStatus4
            // 
            this.TextStatus4.AutoSize = true;
            this.TextStatus4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextStatus4.ForeColor = System.Drawing.Color.Gray;
            this.TextStatus4.Image = global::ChaBaiDaoDataServer.Properties.Resources.loading;
            this.TextStatus4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextStatus4.Location = new System.Drawing.Point(85, 275);
            this.TextStatus4.Name = "TextStatus4";
            this.TextStatus4.Size = new System.Drawing.Size(77, 22);
            this.TextStatus4.TabIndex = 6;
            this.TextStatus4.Text = "      叫号 ";
            this.TextStatus4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextStatusTitle
            // 
            this.TextStatusTitle.AutoSize = true;
            this.TextStatusTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextStatusTitle.ForeColor = System.Drawing.Color.Green;
            this.TextStatusTitle.Location = new System.Drawing.Point(612, 410);
            this.TextStatusTitle.Name = "TextStatusTitle";
            this.TextStatusTitle.Size = new System.Drawing.Size(115, 22);
            this.TextStatusTitle.TabIndex = 7;
            this.TextStatusTitle.Text = "正在检测中. . .";
            // 
            // DataLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyleColor = System.Drawing.Color.Maroon;
            this.BorderStyleSize = 10;
            this.BorderStyleType = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TextStatusTitle);
            this.Controls.Add(this.TextStatus4);
            this.Controls.Add(this.TextStatus3);
            this.Controls.Add(this.TextStatus2);
            this.Controls.Add(this.TextStatus1);
            this.FrmTitle = "点击返回(退出)";
            this.IsFullSize = false;
            this.Name = "DataLogForm";
            this.Text = "DataLogForm";
            this.BtnHelpClick += new System.EventHandler(this.DataLogForm_BtnHelpClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataLogForm_FormClosing);
            this.Controls.SetChildIndex(this.TextStatus1, 0);
            this.Controls.SetChildIndex(this.TextStatus2, 0);
            this.Controls.SetChildIndex(this.TextStatus3, 0);
            this.Controls.SetChildIndex(this.TextStatus4, 0);
            this.Controls.SetChildIndex(this.TextStatusTitle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label TextStatus1;
        private System.Windows.Forms.Label TextStatus2;
        private System.Windows.Forms.Label TextStatus3;
        private System.Windows.Forms.Label TextStatus4;
        private System.Windows.Forms.Label TextStatusTitle;
    }
}