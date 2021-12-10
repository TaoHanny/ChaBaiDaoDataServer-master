
using ChaBaiDaoDataServer;
using HZH_Controls.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace DataServer.core
{
    public class WebSServer
    {
        private static string TAG = "WebSServer";
        WebSocketServer wssv;

        public void Start()
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(init));
                thread.Start();
                Logcat.d(TAG, "Start()  开启WebSokcet");
            }
            catch(Exception e)
            {
                Logcat.e(TAG, "Start()  "+e.ToString());
            }

           
        }
        private void init()
        {
             Stop();
             wssv = new WebSocketServer(21321);
             wssv.AddWebSocketService<Chat>("/Chat");
             wssv.Start();
             Logcat.w(TAG, "init()  WebSocketServer.isListening = " + wssv.IsListening);
           
        }

        public void Stop()
        {
            try
            {
                if (wssv != null)
                {
                    wssv.RemoveWebSocketService("/Chat");
                    wssv.Stop();
                    wssv = null;
                    Logcat.d(TAG, "Stop()  关闭WebSokcet");
                }
            }
            catch(Exception e)
            {
                Logcat.e(TAG, "Stop() " + e.ToString());
            }
        }
        private static Dictionary<string, string> nameList = new Dictionary<string, string>();
        public class Chat : WebSocketBehavior
        {

            
            protected override void OnMessage(MessageEventArgs e)
            {

                Logcat.d(TAG, e.Data);
                //StreamReader reader = new StreamReader(e.Data);
                string text = e.Data;
                Logcat.d(TAG, text);
                try
                {
                    var obj = JsonConvert.DeserializeObject<JsonDto>(text);
                    Logcat.d(TAG, "OnMessage()  收到消息：" + obj.content + " 类型：" + obj.type + " id:" + ID);

                    switch (obj.type)
                    {
                        //正常聊天
                        case "1":
                            obj.name = nameList[ID];
                            TimeLineItem timeLineItem = JsonConvert.DeserializeObject<TimeLineItem>(obj.content);
                            if (timeLineItem != null)
                            {
                                WebSServer.AddTimeLineItem(timeLineItem);
                            }
                        break;
                        //修改名称
                        case "2":
                            Logcat.d(TAG, nameList[ID] +"修改名称" + obj.content);
                            Broadcast(string.Format("{0}修改名称{1}", nameList[ID], obj.content), "3");
                            nameList[ID] = obj.content;
                            WebSServer.NotifiyDevStatus(STATUS_TYPE_BEAT, nameList);
                            break;
                        default:
                            Sessions.Broadcast(text);
                            break;

                    }
                }catch (Exception exception)
                {
                    Logcat.e(TAG, exception.Message);
                }

                //await Send(text);
            }
            protected override void OnClose(CloseEventArgs e)
            {
                Logcat.d(TAG, " OnClose() 连接关闭" + ID);
                Broadcast(string.Format("{0}下线，共有{1}台在线", nameList[ID], Sessions.Count), "3");
                nameList.Remove(ID);
                WebSServer.NotifiyDevStatus(STATUS_TYPE_REMOVE, nameList);



            }

            protected override void OnError(WebSocketSharp.ErrorEventArgs e)
            {
                Logcat.e(TAG, "OnError()  " + e.Message);
                nameList.Clear();
                WebSServer.NotifiyDevStatus(STATUS_TYPE_ERROR,nameList);
            }

            protected override  void OnOpen()
            {
                Logcat.d(TAG, "OnOpen()  建立连接" + ID);
                nameList.Add(ID, "设备" + Sessions.Count);
                Logcat.d(TAG,"OnOpen() 当前nameList.size = "+nameList.Count);
                Broadcast(string.Format("{0}上线了，共有{1}台在线", nameList[ID], Sessions.Count), "3");
                NotifiyDevStatus(STATUS_TYPE_ADD, nameList);
            }

            private void Broadcast(string msg, string type = "1")
            {
                var data = new JsonDto() { content = msg, type = type, name = nameList[ID] };
                Sessions.Broadcast(JsonConvert.SerializeObject(data));
            }

        }

        private static void AddTimeLineItem(TimeLineItem timeLineItem)
        {
            if (LineItems.Count >= 10)
            {
                LineItems.RemoveLast();
            }
            LineItems.AddFirst(timeLineItem);
            NotifiyDataList(LineItems);
        }

        private static void NotifiyDataList(LinkedList<TimeLineItem> timeLineItems)
        {
            foreach(OnWebSockerListener onWebSockerListener in listeners){
                onWebSockerListener.OnDataList(timeLineItems);
            }
        }

        private static void NotifiyDevStatus(int statusType, Dictionary<string, string> nameList)
        {
            foreach (OnWebSockerListener onWebSockerListener in listeners)
            {
                onWebSockerListener.OnDevStatus(statusType,nameList);
            }
        }


        private static List<OnWebSockerListener> listeners = new List<OnWebSockerListener>();


        public void AddOnWebSockerListener(OnWebSockerListener listener)
        {
            if (listener != null)
            {
                listeners.Add(listener);
            }
        }

        public void RemoveOnWebSockerListener(OnWebSockerListener listener)
        {
            if (listener != null)
            {
                listeners.Remove(listener);
            }
        }

        public static int STATUS_TYPE_ADD = 12;
        public static int STATUS_TYPE_REMOVE = 13;
        public static int STATUS_TYPE_BEAT = 11;
        public static int STATUS_TYPE_ERROR = 14;

        public static LinkedList<TimeLineItem> LineItems = new LinkedList<TimeLineItem>();
        public interface OnWebSockerListener
        {
            void OnDataList(LinkedList<TimeLineItem> timeLineItems);
            void OnDevStatus(int statusType, Dictionary<string, string> nameList);
        }
    }
}
