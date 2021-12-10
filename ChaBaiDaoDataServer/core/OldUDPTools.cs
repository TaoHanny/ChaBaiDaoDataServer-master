using ChaBaiDaoDataServer;
using ChaBaiDaoDataServer.utils;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace DataServer.core
{
    public class OldUDPTools
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
            while (startBool)
            {
                string ip = IPAddressUtil.getIPv4();
                if (ip != null && !"127.0.0.1".Equals(ip))
                {
                    Logcat.d(TAG, "Send() IP = " + ip);
                    byte[] ipBuffer = Encoding.Default.GetBytes(ip);
                    UDPsend.Send(ipBuffer, ipBuffer.Length, endpoint);
                }
                Thread.Sleep(10000);
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
                if(msg==null || !IPAddressUtil.IsIpAddress(msg))
                {
                    continue;
                }
                Logcat.d(TAG, "RecvThread() "+msg);
               
               if (!msg.Equals(currentIP))
               {
                   currentIP = msg;
               }
            }
        }

        public static string currentIP = "127.0.0.1";

        public void stop()
        {
            startBool = false;
        }






        
    }
}
