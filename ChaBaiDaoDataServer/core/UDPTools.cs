using ChaBaiDaoDataServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DataServer.core
{
    public class UDPTools
    {
        private string TAG = "UDPTools";


        public bool startBool = true;

        public void start()
        {
            Thread thread = new Thread(new ThreadStart(init));
            thread.Start();
            Logcat.d(TAG, "局域网内发现域名服务已开启");
        }
        private void init()
        {
            UdpClient UDPsend = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Broadcast, 40297);
            byte[] buf = Encoding.Default.GetBytes("This is UDP broadcast");
            Thread receThread = new Thread(new ThreadStart(RecvThread));
            receThread.Start();
            sendDevConnectStatas(true);
            while (startBool)
            {
                string ip = getIPv4();
                if (ip != null && !"127.0.0.1".Equals(ip))
                {
                    Logcat.d(TAG, "Send() IP = "+ip);
                    byte[] ipBuffer = Encoding.Default.GetBytes(ip);
                    UDPsend.Send(ipBuffer, ipBuffer.Length, endpoint);
                }
                
                Thread.Sleep(5000);
            }

        }

         private void RecvThread()
        {
            UdpClient UDPrece = new UdpClient(new IPEndPoint(IPAddress.Any, 40297));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
            while (startBool)
            {
                byte[] buf = UDPrece.Receive(ref endpoint);
                string msg = Encoding.Default.GetString(buf);
                if(msg==null || msg.Length <= 2)
                {
                    continue;
                }
                Logcat.d(TAG, "RecvThread() "+msg);

            }
        }


        public void stop()
        {
            startBool = false;
            sendDevConnectStatas(false);
        }


        private void sendDevConnectStatas(bool connectBool)
        {
            //Logcat.d(TAG, "sendDevConnectStatas() connectBool = " + connectBool);
            if (mdnsInterface != null)
            {
                mdnsInterface.DevConnectStatas(connectBool);
            }
        }

        private UDPInterface mdnsInterface;

        public void setUDPInterface(UDPInterface interfaceImp)
        {
            mdnsInterface = interfaceImp;
        }

        public interface UDPInterface
        {
            void DevConnectStatas(bool connectStatus);
        }

        public string getIPv4()
        {
            string HostName = Dns.GetHostName();
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
            for (int i = 0; i < IpEntry.AddressList.Length; i++)
            {
                if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    string ip = IpEntry.AddressList[i].ToString();
                    Logcat.d(TAG, "getIPv4() " + ip);
                    return IpEntry.AddressList[i].ToString();
                }
            }
            return null;
        }
    }
}
