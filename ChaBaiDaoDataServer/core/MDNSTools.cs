//using Makaretu.Dns;
//using System;
//using System.Linq;
//using Microsoft.Win32;
//using System.Management;
//using System.Net.NetworkInformation;
//using System.Net.Sockets;

//delegate void MDNSConnectStatusDelegate(bool connectStatus); 

//namespace ChaBaiDaoDataServer
//{

//    class MDNSTools
//    {
//        private string TAG = "MDNSTools";
//        private MulticastService mdns = new MulticastService();
//        private ServiceDiscovery sd = new ServiceDiscovery();
//        public void start()
//        {
            
//            foreach (var a in MulticastService.GetLinkLocalAddresses())
//            {
//                Logcat.i(TAG, "IP address Id: " + a);
                
//            }
//            mdns.QueryReceived += (s, e) =>
//            {
//                var names = e.Message.Questions
//                    .Select(q => q.Name + " " + q.Type);
//                    //Logcat.i(TAG,  ($"got a query for {String.Join(", ", names)}"));
//                onMDNSStatus($"{String.Join(", ", names)}");
//            };
//            mdns.AnswerReceived += (s, e) =>
//            {
//                var names = e.Message.Answers
//                    .Select(q => q.Name + " " + q.Type)
//                    .Distinct();
//                    //Logcat.i(TAG, ($"got answer for {String.Join(", ", names)}"));
//                    onMDNSStatus($"{String.Join(", ", names)}");
//            };
//            mdns.NetworkInterfaceDiscovered += (s, e) =>
//            {
//                foreach (var nic in e.NetworkInterfaces)
//                {
//                    Logcat.i(TAG, ($"discovered NIC '{nic.Name}'"));
//                }
//            };
//            Logcat.d(TAG, System.Environment.MachineName + "  " + System.Environment.UserDomainName);
            
//            var p = new ServiceProfile("chabaidao", getDnsName(), 40297);
//            p.AddProperty("connstr", "Server");

//            sd.AnswersContainsAdditionalRecords = true;
//            sd.Advertise(p);
//            Logcat.i(TAG, "开始启动mDNS");
//            mdns.Start();
//            cacheTimeLong = getCurrentTimeLong()+10;
//        }


//        public void stopMdns()
//        {
//            mdns.Stop();
//            sd.Unadvertise();
//        }

//        private void onMDNSStatus(string message)
//        {
//            if (message.Contains(getDnsName()))
//            {
//                cacheTimeLong = getCurrentTimeLong() + 5;
//                sendDevConnectStatas(true);
//            }
//            else
//            {
//                if (getCurrentTimeLong() > cacheTimeLong)
//                {
//                    sendDevConnectStatas(false);
//                }
//            }
//        }

//        private void sendDevConnectStatas(bool connectBool)
//        {
//            //Logcat.d(TAG, "sendDevConnectStatas() connectBool = " + connectBool);
//            if (mdnsInterface!= null)
//            {
//                mdnsInterface.DevConnectStatas(connectBool);
//            }
//        }

//        private MdnsInterface mdnsInterface;

//        public void setMdnsInterface(MdnsInterface interfaceImp)
//        {
//             mdnsInterface = interfaceImp;
//        }


//        private long cacheTimeLong = 0;
//        private long getCurrentTimeLong()
//        {
//            long timetamp= new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
//            //Logcat.w(TAG, "getCurrentTimeLong() timetamp = " + timetamp);
//            return timetamp;
//        }


//        private string getDnsName()
//        {
//            //string dnsName = "_chabaidao-" + getMACName() + "._tcp";
//            string dnsName = "_ChaBaiDao-LAN-Broadcast._tcp";
//            return dnsName;
//        }


//        private string getMACName()
//        {
//            return System.Environment.MachineName;
//        }

//        public string getDomainName()
//        {
//            return System.Environment.UserDomainName;
//        }
//        public void ShowNetworkInterfaceMessage()
//        {
//            NetworkInterface[] fNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
//            foreach (NetworkInterface adapter in fNetworkInterfaces)
//            {
//                #region " 网卡类型 "
//                string fCardType = "未知网卡";
//                string fRegistryKey = "SYSTEM//CurrentControlSet//Control//Network//{4D36E972-E325-11CE-BFC1-08002BE10318}//" + adapter.Id + "//Connection";
//                RegistryKey rk = Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
//                if (rk != null)
//                {
//                    // 区分 PnpInstanceID 
//                    // 如果前面有 PCI 就是本机的真实网卡
//                    // MediaSubType 为 01 则是常见网卡，02为无线网卡。
//                    string fPnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
//                    int fMediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", 0));
//                    if (fPnpInstanceID.Length > 3 &&
//                        fPnpInstanceID.Contains("PCI"))
//                        fCardType = "物理网卡";
//                    else if (fMediaSubType == 1)
//                        fCardType = "虚拟网卡";
//                    else if (fMediaSubType == 2)
//                        fCardType = "无线网卡";
//                }
//                #endregion
//                #region " 网卡信息 "
//                Logcat.i(TAG, ("-- " + fCardType));
//                Logcat.i(TAG, ("Id .................. : "+ adapter.Id)); // 获取网络适配器的标识符
//                Logcat.i(TAG, ("Name ................ : "+ adapter.Name)); // 获取网络适配器的名称
//                Logcat.i(TAG, ("Description ......... : "+ adapter.Description)); // 获取接口的描述
//                Logcat.i(TAG, ("Interface type ...... : "+ adapter.NetworkInterfaceType)); // 获取接口类型
//                Logcat.i(TAG, ("Physical Address .... : "+ adapter.GetPhysicalAddress().ToString())); // MAC 地址
//                IPInterfaceProperties fIPInterfaceProperties = adapter.GetIPProperties();
//                UnicastIPAddressInformationCollection UnicastIPAddressInformationCollection = fIPInterfaceProperties.UnicastAddresses;
//                foreach (UnicastIPAddressInformation UnicastIPAddressInformation in UnicastIPAddressInformationCollection)
//                {
//                    if (UnicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
//                        Logcat.i(TAG, ("Ip Address .......... : "+ UnicastIPAddressInformation.Address)); // Ip 地址
//                }

//                #endregion
//            }

//        }


//    }
//}

