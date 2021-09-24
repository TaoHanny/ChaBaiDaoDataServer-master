
namespace DataServer.view
{
    partial class TimeLineView
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
            components = new System.ComponentModel.Container();
            this.ucTimeLine1 = new HZH_Controls.Controls.UCTimeLine();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ucTimeLine1.AutoScroll = true;
            this.ucTimeLine1.DetailsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.ucTimeLine1.DetailsForcolor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.ucTimeLine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTimeLine1.Items = new HZH_Controls.Controls.TimeLineItem[] {};
            this.ucTimeLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.ucTimeLine1.Location = new System.Drawing.Point(0, 0);
            this.ucTimeLine1.Name = "ucTimeLine1";
            this.ucTimeLine1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.ucTimeLine1.Size = new System.Drawing.Size(768, 542);
            this.ucTimeLine1.TabIndex = 0;
            this.ucTimeLine1.TitleFont = new System.Drawing.Font("微软雅黑", 14F);
            this.ucTimeLine1.TitleForcolor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.ucTimeLine1);
        }

        #endregion
        private HZH_Controls.Controls.UCTimeLine ucTimeLine1;
    }
}
