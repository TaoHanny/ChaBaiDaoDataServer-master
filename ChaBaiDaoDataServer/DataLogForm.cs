using DataServer.core;
using HZH_Controls.Controls;
using HZH_Controls.Forms;
using System.Collections.Generic;

namespace DataServer
{
    public partial class DataLogForm : FrmBack , WebSServer.OnWebSockerListener
    {
        public DataLogForm()
        {
            InitializeComponent();
            timeLineView1.addDataLog(WebSServer.LineItems);
            this.BtnHelpClick += DataLogForm_BtnHelpClick;
        }

        private void DataLogForm_BtnHelpClick(object sender, System.EventArgs e)
        {
            FrmDialog.ShowDialog(this, message, "提示");

        }

        public void OnDataList(LinkedList<TimeLineItem> timeLineItems)
        {
            setTimeLineItem(timeLineItems);
        }

        public void OnDevStatus(int statusType, Dictionary<string, string> nameList)
        {
            
        }

        private void setTimeLineItem(LinkedList<TimeLineItem> timeLineItems)
        {
            if (this.timeLineView1.InvokeRequired)
            {
                while (!this.timeLineView1.IsHandleCreated)
                {
                    if (this.timeLineView1.Disposing || this.timeLineView1.IsDisposed)
                    {
                        return;
                    }

                }
                SetTimeLineItemCallback d = new SetTimeLineItemCallback(setTimeLineItemUi);
                this.timeLineView1.Invoke(d, new object[] { timeLineItems });
            }
            else
            {
                this.timeLineView1.addDataLog(timeLineItems);
            }
        }

        private void setTimeLineItemUi(LinkedList<TimeLineItem> timeLineItems)
        {
            this.timeLineView1.addDataLog(timeLineItems);
        }

        private string message = "此界面为数拓设备实时接收到的数据，如遇" +
            "到数据不同步的问题，可参考此界面最新接收的数据是否与数拓屏幕显示一致！";

        delegate void SetTimeLineItemCallback(LinkedList<TimeLineItem> timeLineItems);
    }
}
