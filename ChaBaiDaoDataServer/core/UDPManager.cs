using ChaBaiDaoDataServer.Databean;
using ChaBaiDaoDataServer.utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChaBaiDaoDataServer.core
{
    class UDPManager
    {
        private static bool startBool = true;

        private string TAG = "UDPManager";
        private int RCV_IP_AND_PORT = 999;

        private UDPManager() {}

        private static UDPManager uDPManager;
        private string ip;

        public static UDPManager getInstance()
        {
            if (uDPManager != null) return uDPManager;
            if (uDPManager == null)
            {
                uDPManager = new UDPManager();
            }
            return uDPManager;
        }

        public void startUdp()
        {
            ip = IPAddressUtil.getIPv4();
            MultiRecvThread();
            Thread sendThread = new Thread(new ThreadStart(MultiSendThread));
            sendThread.Start();
        }

        private void MultiRecvThread()
        {
            int port = 11069;
            Thread receThread = new Thread(new ParameterizedThreadStart(RecvThread));
            receThread.Start(port);
        }

        private object syncstate = new object();
        private void RecvThread(object port)
        {
            int portInt = (int)port;
            UdpClient UDPrece = new UdpClient(new IPEndPoint(IPAddress.Any, portInt));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
            Logcat.i(TAG, "RecvThread() portInt = "+portInt);
            while (startBool)
            {
                byte[] buf = UDPrece.Receive(ref endpoint);
                string msg = Encoding.Default.GetString(buf);
                if (msg == null )
                {
                    continue;
                }
                BytesOrStrParse.Data data = BytesOrStrParse.getBytesToStr(buf);
                lock (syncstate)
                {
                    if (!String.Equals(ip, data.ctlMsg) && data.firstInt == RCV_IP_AND_PORT && data.dataMsg.Length > 20)
                    {
                        Logcat.d(TAG, "RecvThread() " + data.dataMsg);
                        DataMsg dataMsg = JsonConvert.DeserializeObject<DataMsg>(data.dataMsg);
                        if (startBool)
                        {
                            sendDevConnectStatas(true, dataMsg);
                        }
                        startBool = false;
                        startSendUDPBool = false;
                }
                }
                
            }
            if (!startBool)
            {
                UDPrece.Close();
                startSendUDPBool = false;
            }
        }

        private bool startSendUDPBool = true;
        private void MultiSendThread()
        {
            int port = 11060;
            int count = 0;
            while (startSendUDPBool)
            {
                if (port > 11070)
                {
                    port = 11060;
                    if (count > 2)
                    {
                        sendDevConnectStatas(false, null);
                    }
                    count++;
                }
                SendThread(port);
                Thread.Sleep(1000);
                port++;
            }
        }


        private void SendThread(int port)
        {
            UdpClient UDPsend = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Broadcast, port);
            byte[] udpMsgBytes = BytesOrStrParse.getStrToBytes(ip);
            //Logcat.d(TAG, "SendThread() " + BytesOrStrParse.getBytesToStr(udpMsgBytes).toString());
            UDPsend.Send(udpMsgBytes, udpMsgBytes.Length, endpoint);
            UDPsend.Close();
        }

        private void stopUdp()
        {
            startSendUDPBool = false;
            startBool = false;
        }


        private void sendDevConnectStatas(bool connectBool, DataMsg dataMsg)
        {
            //Logcat.d(TAG, "sendDevConnectStatas() connectBool = " + connectBool);
            if (mdnsInterface != null)
            {
                mdnsInterface.DevConnectStatas(connectBool, dataMsg);
            }
        }

        private UDPInterface mdnsInterface;

        public void setUDPInterface(UDPInterface interfaceImp)
        {
            mdnsInterface = interfaceImp;
        }

        public interface UDPInterface
        {
            void DevConnectStatas(bool connectStatus, DataMsg dataMsg);
        }


    }
}
