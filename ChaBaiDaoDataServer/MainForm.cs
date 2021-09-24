
using System;

using System.Windows.Forms;
using System.Net.NetworkInformation;
using HZH_Controls.Forms;
using DataServer.view;
using DataServer.core;
using System.Drawing;
using DataServer;
using System.Collections.Generic;
using HZH_Controls.Controls;
using static DataServer.core.UDPTools;

namespace ChaBaiDaoDataServer
{
    public partial class MainForm : FrmWithTitle , WebSServer.OnWebSockerListener, UDPInterface, MySQLInterface
    {
        private static string TAG = "MainForm";
        private UDPTools udpTools = new UDPTools();
        private MySQLManager mySQLManager = new MySQLManager();
        private InitStepView initStepView = new InitStepView();
        private SignalLampView SignalLampView = new SignalLampView();
        private static WebSServer webSServer = new WebSServer();
        public MainForm()
        {
            InitializeComponent();
            HZH_Controls.FontIcons icon = (HZH_Controls.FontIcons)Enum.Parse(typeof(HZH_Controls.FontIcons), "A_fa_list");
            this.label1.Image = HZH_Controls.FontImages.GetImage(icon, 32, Color.Green);
            this.label1.Click += Label1_Click;
            this.FormClosing += MainForm_FormClosing;
            startCore();

            AddView(ADD_INIT_VIEW);
            webSServer.AddOnWebSockerListener(this);
        }

        private void startCore()
        {
            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
            udpTools.setUDPInterface(this);
            mySQLManager.setMySQLIntetface(this);
            mySQLManager.startMysqlOpen();
            udpTools.start();
    }

        

      
        public void OpenMysqlStatus(bool openStatus)
        {
            Logcat.w(TAG, " OpenMysqlStatus() openStatus = " + openStatus);
            if (openStatus)
            {
                setInitStepView(InitStepView.INDEX_ONE, InitStepView.STEP_OK);
            }
            else
            {
                setInitStepView(InitStepView.INDEX_ONE, InitStepView.STEP_NO);
            }
        }
       

        
      
        private bool cacheConnectStatus = false;
            
        public void DevConnectStatas(bool connectStatus)
        {
            Logcat.w(TAG, "MainDevConnectStatas() connectStatus = " + connectStatus);
            if (connectStatus && !cacheConnectStatus)
            {
                AddView(ADD_INIT_VIEW);
                setInitStepView(InitStepView.INDEX_TWO, InitStepView.STEP_OK);
                webSServer.Start();
               cacheConnectStatus = connectStatus;
            }
            if (!connectStatus)
            {
                AddView(ADD_INIT_VIEW);
                setInitStepView(InitStepView.INDEX_TWO, InitStepView.STEP_NO);
                webSServer.Stop();
                cacheConnectStatus = connectStatus;

            }
        }
      
       // ipml WebSServer
        public void OnDataList(LinkedList<TimeLineItem> timeLineItems)
        {
            
        }
        // ipml WebSServer
        public void OnDevStatus(int statusType, Dictionary<string, string> nameList)
        {
            Logcat.e(TAG, "OnDevStatus() = statusType = " + statusType);
            if(statusType == WebSServer.STATUS_TYPE_ADD)
            {
                setInitStepView(InitStepView.INDEX_THERE, InitStepView.STEP_OK);
                AddView(ADD_SINGAL_VIEW);
            }
            if(statusType == WebSServer.STATUS_TYPE_REMOVE)
            {
                
            }
            if(statusType == WebSServer.STATUS_TYPE_ERROR)

            {
                setInitStepView(InitStepView.INDEX_THERE, InitStepView.STEP_NO);
                webSServer.Start();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            new DataLogForm().ShowDialog(this);
        }

        private void startShowDataLog()
        {
            this.label1.Show();
        }

        private void stopShowDataLog()
        {
            this.label1.Hide();
        }

        private void AddControl(Control c)
        {
            this.panControl.Controls.Clear();
            this.panControl.Controls.Add(c);
        }

        void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            Logcat.e(TAG, "NetworkAvailabilityEventArgs() "+ e.IsAvailable);

        }

        private void setInitStepViewUi(int index, int statusInt)
        {
            this.initStepView.ChangedStatus(index, statusInt);
        }

        private void setInitStepView(int index, int statusInt)
        {
            if (initStepView.InvokeRequired)
            {
                while (!this.initStepView.IsHandleCreated)
                {
                    if (this.initStepView.Disposing || this.initStepView.IsDisposed)
                    {
                        return;
                    }

                }
                SetInitViewCallback d = new SetInitViewCallback(setInitStepViewUi);
                this.initStepView.Invoke(d, new object[] { index,statusInt });
            }
            else
            {
                this.initStepView.ChangedStatus(index, statusInt);
            }
        }

        private int ADD_INIT_VIEW = 100;
        private int ADD_SINGAL_VIEW = 200;
        private int cacheAddViewFlag = 300;
        private void AddViewUi(int type)
        {
            if(type == ADD_INIT_VIEW && cacheAddViewFlag != type)
            {
                AddControl(this.initStepView);
                cacheAddViewFlag = type;
                stopShowDataLog();
            }else if(type == ADD_SINGAL_VIEW && cacheAddViewFlag != type )
            {
                AddControl(this.SignalLampView);
                cacheAddViewFlag = type;
                startShowDataLog();
            }
        }

        private void AddView(int type)
        {
            if (this.panControl.InvokeRequired)
            {
                while (!this.panControl.IsHandleCreated)
                {
                    if (this.panControl.Disposing || this.panControl.IsDisposed)
                    {
                        return;
                    }

                }
                AddViewCallback d = new AddViewCallback(AddViewUi);
                this.panControl.Invoke(d, new object[] { type });
            }
            else
            {
                AddViewUi(type);
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logcat.d(TAG, "MainForm() closing");
            if (FrmDialog.ShowDialog(this, "请问你确认要退出吗？可能会导致数拓屏幕数据不显示", "提示", true) == System.Windows.Forms.DialogResult.OK)
            {
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
                this.Close();
                Application.Exit();
            }
        }


        delegate void SetInitViewCallback(int index,int statusInt);
        delegate void AddViewCallback(int type);

    }
}


