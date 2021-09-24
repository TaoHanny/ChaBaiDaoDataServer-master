using ChaBaiDaoDataServer;
using DataServer.core;
using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataServer.view
{
    public partial class SignalLampView : UserControl, WebSServer.OnWebSockerListener
    {
        private string TAG = "SignalLampView";
        private WebSServer webSServer = new WebSServer();
        Color[] GREEN = new Color[] { Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))) };
        Color[] RED = new Color[] { Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59))))) };
        Color[] GREEN_GRAY = new Color[]
        {
            Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
            Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))))
        };
    public SignalLampView()
        {
            InitializeComponent();
            webSServer.AddOnWebSockerListener(this);
        }

        private int STATUS_OFFLINE = 0x23;
        private int STATUS_ONLINE = 0x24;
        private int STATUS_REMOVE = 0x25;

        public void StatusChanged_Offline()
        {
            StatusChanged(STATUS_OFFLINE);
        }

        public void StatusChanged_Online()
        {
            StatusChanged(STATUS_ONLINE);
        }

        private void StatusChanged(int type)
        {
            if (this.ucAlarmLamp1.InvokeRequired)
            {
                while (!this.ucAlarmLamp1.IsHandleCreated)
                {
                    if (this.ucAlarmLamp1.Disposing || this.ucAlarmLamp1.IsDisposed)
                    {
                        return;
                    }
                }
                SetColorCallback d = new SetColorCallback(setAlarmLamp1);
                this.ucAlarmLamp1.Invoke(d, new object[] { type });
            }
            else
            {
                
                this.Controls.Remove(this.ucAlarmLamp1);
                Refresh();
                if (STATUS_OFFLINE == type)
                {
                    this.ucAlarmLamp1.LampColor = RED;
                }
                else if (STATUS_ONLINE == type)
                {
                    this.ucAlarmLamp1.LampColor = GREEN;
                }
                else if (STATUS_REMOVE == type)
                {
                    this.ucAlarmLamp1.LampColor = GREEN;
                }
                this.Controls.Add(this.ucAlarmLamp1);
                Refresh();
            }
        }

        private void setAlarmLamp1(int type)
        {
            this.Controls.Remove(this.ucAlarmLamp1);
            Refresh();
            if (STATUS_OFFLINE == type)
            {
                this.ucAlarmLamp1.LampColor = RED;
                this.ucAlarmLamp1.TwinkleSpeed = 0;
            }else if(STATUS_ONLINE == type)
            {
                this.ucAlarmLamp1.LampColor = GREEN;
                this.ucAlarmLamp1.TwinkleSpeed = 0;
            }
            else if(STATUS_REMOVE == type)
            {
                this.ucAlarmLamp1.LampColor = GREEN;
                this.ucAlarmLamp1.TwinkleSpeed = 200;
            }
            this.Controls.Add(this.ucAlarmLamp1);
            Refresh();
        }

        public void OnDataList(LinkedList<TimeLineItem> timeLineItems)
        {
            
        }

        public void OnDevStatus(int statusType, Dictionary<string, string> nameList)
        {
            Logcat.d(TAG, "statusType = " + statusType);
            Logcat.d(TAG, "nameList = " + nameList.Count);
            switch (statusType)
            {
                case 12: //add
                    string content = null;
                    foreach (string key in nameList.Keys)
                    {
                        string name = nameList[key];
                        content += name + "已上线，正在通信\n";
                    }
                    setLabel(content);
                    StatusChanged(STATUS_ONLINE);
                    break;
                case 11: //beat
                    string contentBeat = null;
                    foreach(string key in nameList.Keys)
                    {
                        string name = nameList[key];
                        contentBeat += name + "\n";
                    }
                    setLabel(contentBeat);
                    StatusChanged(STATUS_ONLINE);
                    break;
                case 13: //remove
                    string contentRemove = null;
                    foreach(string key in nameList.Keys)
                    {
                        string name = nameList[key];
                        contentRemove += name + "，但有设备下线\n";
                    }
                    if (contentRemove == null)
                    {
                        contentRemove = "设备全部离线，请检查数拓设备网络情况！";
                    }
                    setLabel(contentRemove);
                    StatusChanged(STATUS_REMOVE);
                    break;
                case 14:
                    string contentError = "实时通信已中断";
                    setLabel(contentError);
                    StatusChanged(STATUS_OFFLINE);
                    break;
                default:
                    break;

            }
        }

        private void setText(string msg)
        {
            this.lblTitle.Text = msg;
        }

        private void setLabel(string msg)
        {
            if (this.lblTitle.InvokeRequired)
            {
                while (!this.lblTitle.IsHandleCreated)
                {
                    if(this.lblTitle.Disposing || this.lblTitle.IsDisposed)
                    {
                        return;
                    }

                }
                SetTextCallback d = new SetTextCallback(setText);
                this.lblTitle.Invoke(d, new object[] { msg });
            }
            else
            {
                this.lblTitle.Text = msg;
            }
        }

        delegate void SetTextCallback(string text);
        delegate void SetColorCallback(int type);
        
    }

   
}
