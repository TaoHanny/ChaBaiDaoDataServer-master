
namespace DataServer.view
{
    partial class InitStepView
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
            this.ucStep1 = new HZH_Controls.Controls.UCStep();
            this.SuspendLayout();
            // 
            // ucStep1
            // 
            this.ucStep1.BackColor = System.Drawing.Color.Transparent;
            this.ucStep1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucStep1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucStep1.ImgCompleted = null;
            this.ucStep1.LineWidth = 2;
            this.ucStep1.Location = new System.Drawing.Point(0, 0);
            this.ucStep1.Margin = new System.Windows.Forms.Padding(0);
            this.ucStep1.Name = "ucStep1";
            this.ucStep1.Size = new System.Drawing.Size(524, 200);
            this.ucStep1.StepBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucStep1.StepFontColor = System.Drawing.Color.White;
            this.ucStep1.StepForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucStep1.StepIndex = 0;
            this.ucStep1.Steps = new string[] {
        "正在检查数据库",
        "",
        ""};
            this.ucStep1.StepWidth = 35;
            this.ucStep1.TabIndex = 0;
            // 
            // InitStepView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucStep1);
            this.Name = "InitStepView";
            this.Size = new System.Drawing.Size(524, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCStep ucStep1;
    }
}
