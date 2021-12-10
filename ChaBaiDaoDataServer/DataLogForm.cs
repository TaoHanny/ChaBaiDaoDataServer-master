using ChaBaiDaoDataServer;
using ChaBaiDaoDataServer.Databean;
using ChaBaiDaoDataServer.Properties;
using ChaBaiDaoDataServer.utils;
using DataServer.core;
using HZH_Controls.Controls;
using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DataServer
{
    public partial class DataLogForm : FrmBack , WebSServer.OnWebSockerListener
    {

        private string TITLE_ERROR = "此POS版本不支持菜品售罄功能";

        private string HTTP_MENU_OK = "     价目接口运行正常";
        private string HTTP_MENU_ERROR = "     价目接口访问失败，可能是POS版本过低";
        private string HTTP_SOLD_OUT_OK = "     售罄接口运行正常";
        private string HTTP_SOLD_OUT_ERROR = "     售罄接口访问失败，可能是POS版本过低";
        private string HTTP_ORDER_OK = "     实时订单接口运行正常";
        private string HTTP_ORDER_ERROR = "     实时订单接口访问失败(如果不需要显示实时订单，可忽略此错误)";
        private string HTTP_KDS_OK = "     叫号接口运行正常";
        private string HTTP_KDS_ERROR = "     叫号接口访问失败，可能是KDS运行异常或者是KDS未打开";
        private System.Windows.Forms.Label[] LabelArr;
        public DataLogForm()
        {
            InitializeComponent();
             LabelArr =new System.Windows.Forms.Label[] { TextStatus1,TextStatus2,TextStatus3,TextStatus4};
            this.BtnHelpClick += DataLogForm_BtnHelpClick;
            this.Load += new System.EventHandler(this.DataLogForm_FormLoad);
        }

        private void DataLogForm_BtnHelpClick(object sender, System.EventArgs e)
        {
            FrmDialog.ShowDialog(this, message, "提示");

        }

        private DataMsg dataMsg;
        public void setDataMsg(DataMsg datamsg)
        {
            if (datamsg != null)
            {
                this.dataMsg = datamsg;
            }
            else
            {
                this.dataMsg = new DataMsg();
                this.dataMsg.HttpServerIP = "127.0.0.1";
                this.dataMsg.HttpServerPort = 8060;
            }
        }

        private void DataLogForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            list.Clear();
        }

        private void DataLogForm_FormLoad(object sender, System.EventArgs e)
        {
            if (dataMsg == null) TextStatusTitle.Text = TITLE_ERROR;
            Thread menuThread = new Thread(new ThreadStart(onStartCheckMenu));
            Thread soldOutThread = new Thread(new ThreadStart(onStartCheckSoldOut));
            Thread orderThread = new Thread(new ThreadStart(onStartCheckOrder));
            Thread callThread = new Thread(new ThreadStart(onStartCheckCall));
            menuThread.Start();
            soldOutThread.Start();
            orderThread.Start();
            callThread.Start();
        }

        private List<DataStatus> list = new List<DataStatus>();

        private void onStartCheckMenu()
        {
            DataStatus dataStatus;
            try
            {
                if (HttpPost.HttpMenu(dataMsg.HttpServerIP, dataMsg.HttpServerPort))
                {
                    dataStatus = new DataStatus(HTTP_MENU_OK, true);
                }
                else
                {
                    dataStatus = new DataStatus(HTTP_MENU_ERROR, false);
                }
            }
            catch (Exception e)
            {
                Logcat.e("DataLogForm", "onStartCheckMenu()" + e.ToString());
                dataStatus = new DataStatus(HTTP_MENU_ERROR, false);
            }
            LockUpateData(dataStatus);
        }

        private object lockObject = new object();
        private void LockUpateData(DataStatus dataStatus)
        {
            lock (lockObject)
            {
                list.Add(dataStatus);
                UpdateStatus(list);
            }
            
        }

        private void onStartCheckSoldOut()
        {
            DataStatus dataStatus;
            try { 
                if (HttpPost.HttpSoldOut(dataMsg.HttpServerIP, dataMsg.HttpServerPort))
                {
                    dataStatus = new DataStatus(HTTP_SOLD_OUT_OK, true);
                }
                else
                {
                    dataStatus = new DataStatus(HTTP_SOLD_OUT_ERROR, false);
                }
               
            }
            catch (Exception e)
            {
                Logcat.e("DataLogForm", "onStartCheckSoldOut()" + e.ToString());
                dataStatus = new DataStatus(HTTP_SOLD_OUT_ERROR, false);
            }
            LockUpateData(dataStatus);
        }
        private void onStartCheckOrder()
        {
            DataStatus dataStatus;
            try
            {
                if (HttpPost.HttpOrder(dataMsg.HttpServerIP,dataMsg.HttpServerPort))
                {
                    dataStatus = new DataStatus(HTTP_ORDER_OK, true);
                }
                else
                {
                    dataStatus = new DataStatus(HTTP_ORDER_ERROR, false);
                }
            }
            catch (Exception e)
            {
                Logcat.e("DataLogForm", "onStartCheckOrder() " + e.ToString());
                dataStatus = new DataStatus(HTTP_ORDER_ERROR, false);
            }
            LockUpateData(dataStatus);
        }
        private void onStartCheckCall()
        {
            DataStatus dataStatus;
            try
            {
                if (HttpPost.HttpKdsV2(dataMsg.HttpServerIP,8090) || HttpPost.HttpKdsV2(dataMsg.HttpServerIP, 9080))
                {
                   dataStatus = new DataStatus(HTTP_KDS_OK, true);
                }
                else
                {
                   dataStatus = new DataStatus(HTTP_KDS_ERROR, false);
                }
            }
            catch(Exception e)
            {
                Logcat.e("DataLogForm", "onStartCheckCall()  " + e.ToString());
                dataStatus = new DataStatus(HTTP_KDS_ERROR, false);
            }
            LockUpateData(dataStatus);
        }

        private void UpdateStatus(List<DataStatus> list)
        {
            if (this.TextStatus1.InvokeRequired)
            {
                while (!this.TextStatus1.IsHandleCreated)
                {
                    if (this.TextStatus1.Disposing || this.TextStatus1.IsDisposed)
                    {
                        return;
                    }
                }
                SetStatusCallback setStatusCallback = new SetStatusCallback(UpdateStatusUI);
                this.TextStatus1.Invoke(setStatusCallback, new object[] { list });
            }
            else
            {
                UpdateStatusUI(list);
            }
        }

        private void UpdateStatusUI(List<DataStatus> list)
        {
            int index = 0;
            if (list.Count == 4) { TextStatusTitle.Text = "检测完成！"; }
            foreach(DataStatus dataStatus in list)
            {
                if (dataStatus.statusBool)
                {
                    LabelArr[index].Text = dataStatus.textStr;
                    LabelArr[index].Image = global::ChaBaiDaoDataServer.Properties.Resources.ok;
                }
                else
                {
                    LabelArr[index].Text = dataStatus.textStr;
                    LabelArr[index].Image = global::ChaBaiDaoDataServer.Properties.Resources.error;
                }
                LabelArr[index].Refresh();
                this.Controls.Remove(LabelArr[index]);
                this.Controls.Add(LabelArr[index]);
                index++;
            }
        }


        // impl WebSocket
        public void OnDataList(LinkedList<TimeLineItem> timeLineItems)
        {
            setTimeLineItem(timeLineItems);
        }

        public void OnDevStatus(int statusType, Dictionary<string, string> nameList)
        {
            
        }

        private void setTimeLineItem(LinkedList<TimeLineItem> timeLineItems)
        {
        }

        private void setTimeLineItemUi(LinkedList<TimeLineItem> timeLineItems)
        {
          
        }

        private string message = "此界面主要是检测哗啦啦POS的数据接口是否运行正常，如果检测结果报异常错误，" +
            "请联系哗啦啦官方；如果检测结果正常，但叫号或者菜单屏数据显示错误，请联系数拓官方";

        delegate void SetTimeLineItemCallback(LinkedList<TimeLineItem> timeLineItems);

        delegate void SetStatusCallback(List<DataStatus> list);

        private class DataStatus
        {
            public string textStr { set; get; }
            public bool statusBool { set; get; }

            public DataStatus(string text, bool status)
            {
                this.textStr = text;
                this.statusBool = status;
            }
        }
    }
}
