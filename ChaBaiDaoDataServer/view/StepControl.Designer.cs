namespace ChaBaiDaoDataServer.view
{
    partial class StepControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.setpText1 = new System.Windows.Forms.Label();
            this.setpText3 = new System.Windows.Forms.Label();
            this.stepPic1 = new System.Windows.Forms.PictureBox();
            this.setpPic3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.stepPic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setpPic3)).BeginInit();
            this.SuspendLayout();
            // 
            // setpText1
            // 
            this.setpText1.AutoSize = true;
            this.setpText1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setpText1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setpText1.Location = new System.Drawing.Point(73, 27);
            this.setpText1.Name = "setpText1";
            this.setpText1.Size = new System.Drawing.Size(112, 14);
            this.setpText1.TabIndex = 4;
            this.setpText1.Text = "检查POS基础功能";
            this.setpText1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setpText3
            // 
            this.setpText3.AutoSize = true;
            this.setpText3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setpText3.Location = new System.Drawing.Point(73, 80);
            this.setpText3.Name = "setpText3";
            this.setpText3.Size = new System.Drawing.Size(161, 14);
            this.setpText3.TabIndex = 6;
            this.setpText3.Text = "检查与数拓设备连接状态";
            this.setpText3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stepPic1
            // 
            this.stepPic1.Image = global::ChaBaiDaoDataServer.Properties.Resources.loading;
            this.stepPic1.Location = new System.Drawing.Point(28, 27);
            this.stepPic1.Name = "stepPic1";
            this.stepPic1.Size = new System.Drawing.Size(24, 24);
            this.stepPic1.TabIndex = 3;
            this.stepPic1.TabStop = false;
            // 
            // setpPic3
            // 
            this.setpPic3.Image = global::ChaBaiDaoDataServer.Properties.Resources.loading;
            this.setpPic3.Location = new System.Drawing.Point(28, 80);
            this.setpPic3.Name = "setpPic3";
            this.setpPic3.Size = new System.Drawing.Size(24, 24);
            this.setpPic3.TabIndex = 2;
            this.setpPic3.TabStop = false;
            // 
            // StepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.setpText3);
            this.Controls.Add(this.setpText1);
            this.Controls.Add(this.stepPic1);
            this.Controls.Add(this.setpPic3);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "StepControl";
            this.Size = new System.Drawing.Size(480, 150);
            ((System.ComponentModel.ISupportInitialize)(this.stepPic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setpPic3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox setpPic3;
        private System.Windows.Forms.PictureBox stepPic1;
        private System.Windows.Forms.Label setpText1;
        private System.Windows.Forms.Label setpText3;
    }
}
