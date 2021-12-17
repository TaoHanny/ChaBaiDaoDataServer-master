
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
using static DataServer.core.OldUDPTools;
using ChaBaiDaoDataServer.core;
using AutoUpdaterDotNET;
using ChaBaiDaoDataServer.view;
using static ChaBaiDaoDataServer.core.UDPManager;
using ChaBaiDaoDataServer.Databean;
using ChaBaiDaoDataServer.utils;
using System.Threading;

namespace ChaBaiDaoDataServer
{
    public partial class MainForm : FrmWithTitle , WebSServer.OnWebSockerListener, UDPInterface
    {
        private static string TAG = "MainForm";
        private UDPManager UDPManager;
        private OldUDPTools udpTools = new OldUDPTools();
        private StepControl initStepView = new StepControl(); 
        private SignalLampView SignalLampView = new SignalLampView();
        private static WebSServer webSServer = new WebSServer();
        private DataMsg mDataMsg;
        public MainForm()
        {
            InitializeComponent();
            //HZH_Controls.FontIcons icon = (HZH_Controls.FontIcons)Enum.Parse(typeof(HZH_Controls.FontIcons), "A_fa_list");
            //this.label1.Image = ;
          
            this.label1.Click += Label1_Click;
            this.FormClosing += MainForm_FormClosing;
            this.显示窗体ToolStripMenuItem.Click += ToolStripMenuItemShow_Click;
            this.隐藏窗体ToolStripMenuItem.Click += ToolStripMenuItemHide_Click;
            this.退出ToolStripMenuItem.Click += ToolStripMenuItemExit_Click;
            this.自动开机ToolStripMenuItem.Click += ToolStripMenuItemBoot_Click;
            startCore();

            AddView(ADD_INIT_VIEW);
            webSServer.AddOnWebSockerListener(this);
        }

        

        private void startCore()
        {
            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
            AutoUpdater.Start("https://djs.shutuo.tv/yt/update.xml");
            try
            {
                UDPManager = UDPManager.getInstance();
                UDPManager.startUdp();
                UDPManager.setUDPInterface(this);
                webSServer.Start();
                this.自动开机ToolStripMenuItem.Checked = true;
                BootOnOff.BootOn();
            }catch(Exception e)
            {
                Logcat.e(TAG, "startCore() "+e.ToString());
            }
            
            Thread CheckKDSThread = new Thread(new ThreadStart(CheckHttpKDSIs2_0));
            CheckKDSThread.Start();
            
        }


        private void CheckHttpKDSIs2_0()
        {
            if (HttpPost.HttpKdsV2("127.0.0.1", 8090))
            {
                udpTools.start();
            }
        }
      
        private bool cacheConnectStatus = false;
            
        public void DevConnectStatas(bool connectStatus , DataMsg dataMsg)
        {
            Logcat.w(TAG, "MainDevConnectStatas() connectStatus = " + connectStatus);
            if (dataMsg != null)
            {
                this.mDataMsg = dataMsg;
            }
            if (connectStatus && !cacheConnectStatus)
            {
                UpdateNetIp(dataMsg.HttpServerIP);
                if (cacheAddViewFlag != ADD_SINGAL_VIEW)
                {
                    AddView(ADD_INIT_VIEW);
                }
                setInitStepView(StepControl.ONE, StepControl.OK);
                cacheConnectStatus = connectStatus;
            }
            if (!connectStatus)
            {
                if (cacheAddViewFlag != ADD_SINGAL_VIEW)
                {
                    AddView(ADD_INIT_VIEW);
                }
                setInitStepView(StepControl.ONE, StepControl.ERROR);
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
                setInitStepView(StepControl.THREE, StepControl.OK);
                AddView(ADD_SINGAL_VIEW);
            }
            if(statusType == WebSServer.STATUS_TYPE_REMOVE)
            {
                
            }
            if(statusType == WebSServer.STATUS_TYPE_ERROR)

            {
                setInitStepView(StepControl.THREE, StepControl.ERROR);
                webSServer.Start();
            }
        }

        DataLogForm dataLogForm = new DataLogForm();
        private void Label1_Click(object sender, EventArgs e)
        {
            
            dataLogForm.setDataMsg(mDataMsg);
            dataLogForm.ShowDialog(this);
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
            this.initStepView.ChangeStatus(index, statusInt);
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
                this.initStepView.ChangeStatus(index, statusInt);
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

        public void UpdateNetIpUi(string ip)
        {
            this.mainUpdateNetIp.Text = "当前POS网络："+ip;
        }

        public void UpdateNetIp(string ip)
        {
            if (this.mainUpdateNetIp.InvokeRequired)
            {
                while (!this.mainUpdateNetIp.IsHandleCreated)
                {
                    if(this.mainUpdateNetIp.Disposing || this.mainUpdateNetIp.IsDisposed)
                    {
                        return;
                    }
                }
                UpdateNetIpCallback updateNetIpCallback = new UpdateNetIpCallback(UpdateNetIpUi);
                this.panControl.Invoke(updateNetIpCallback, new object[] { ip });
            }else{
                UpdateNetIpUi(ip);
            }
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Logcat.d(TAG, "ToolStripMenuItemExit_Click() closing");
            notifyIcon1.Visible = false;
            System.Environment.Exit(System.Environment.ExitCode);
            this.Close();
            this.Dispose();
            Application.Exit();
        }
       
        private void ToolStripMenuItemBoot_Click(object sender, EventArgs e)
        {
            if (this.自动开机ToolStripMenuItem.Checked)
            {
                BootOnOff.BootOff();
                this.自动开机ToolStripMenuItem.Checked = false;
                Logcat.d(TAG, "ToolStripMenuItemBoot_Click() 取消自动开机");
            }
            else
            {
                BootOnOff.BootOn();
                this.自动开机ToolStripMenuItem.Checked = true;
                Logcat.d(TAG, "ToolStripMenuItemBoot_Click() 打开自动开机");
            }
        }

        private void ToolStripMenuItemHide_Click(object sender, EventArgs e)
        {
            this.Hide();               //隐藏窗体
            this.ShowInTaskbar = false;
        }

        private void ToolStripMenuItemShow_Click(object sender, EventArgs e)
        {
            this.Show();               //显示窗体
            this.ShowInTaskbar = true;
        }

        private void MinClose_Click(object sender, EventArgs e)
        {
            this.Hide();               //隐藏窗体
            this.ShowInTaskbar = false;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logcat.d(TAG, "MainForm() closing");
            e.Cancel = false;
            System.Environment.Exit(System.Environment.ExitCode);
            this.Close();
            this.Dispose();
            Application.Exit();
        }


        delegate void SetInitViewCallback(int index,int statusInt);
        delegate void AddViewCallback(int type);
        delegate void UpdateNetIpCallback(string ip);

        
    }
}


