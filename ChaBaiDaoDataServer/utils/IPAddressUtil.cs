using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace ChaBaiDaoDataServer.utils
{
    public class IPAddressUtil
    {

        public static bool IsIpAddress(string ip)
        {
            Regex rx = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");

            if (rx.IsMatch(ip)) return true;

            else return false;
        }


        public static string getIPv4()
        {
            string HostName = Dns.GetHostName();
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
            for (int i = 0; i < IpEntry.AddressList.Length; i++)
            {
                if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    string ip = IpEntry.AddressList[i].ToString();
                    //Logcat.d(TAG, "getIPv4() " + ip);
                    return IpEntry.AddressList[i].ToString();
                }
            }
            return null;
        }
    }
}
