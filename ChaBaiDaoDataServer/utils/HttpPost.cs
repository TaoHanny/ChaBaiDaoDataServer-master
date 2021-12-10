using ChaBaiDaoDataServer.Databean;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ChaBaiDaoDataServer.utils
{
  
    public class HttpPost
    {
        private static string TAG = "HttpPost";

        public static bool HttpMenu(string HttpServerIP, int HttpServerPort) 
        {
            try
            {
                string url = "http://" + HttpServerIP + ":" + HttpServerPort + "/saas/openapi/getbasicinfo";
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("msgType", "410");
                IRestResponse response = client.Execute(request);
                Logcat.d(" HttpPost", "HttpMenu() " + response.Content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }catch(Exception e)
            {
                Logcat.e(TAG, "HttpMenu() " + e.ToString());
            }
            return false;
        }

        public static bool HttpSoldOut(string HttpServerIP, int HttpServerPort)
        {
            try
            {
                string url = "http://" + HttpServerIP + ":" + HttpServerPort + "/saas/openapi/getsoldoutfoodlst";
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("msgType", "410");
                IRestResponse response = client.Execute(request);
                Logcat.d(" HttpPost", "HttpSoldOut() " + response.Content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                Logcat.e(TAG, "HttpSoldOut() "+e.ToString());
            }
            
            return false;
        }

        public static bool HttpOrder(string HttpServerIP, int HttpServerPort)
        {
            try
            {
                string url = "http://" + HttpServerIP + ":" + HttpServerPort + "/saas/openapi/getcurrentorder";
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                string param = "";
                byte[] bs = Encoding.ASCII.GetBytes(param);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.Timeout = -1;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                }
                using (HttpWebResponse wr = (HttpWebResponse)req.GetResponse())
                {
                    Stream stream = wr.GetResponseStream();
                    StreamReader stringReader = new StreamReader(stream);
                    Logcat.d(" HttpPost", "HttpOrder" + stringReader.ReadToEnd());
                    if (wr.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }catch(Exception e)
            {
                Logcat.e(TAG, "HttpOrder() " + e.ToString());
            }
            return false;
        }

        public static bool HttpKdsV2(string HttpServerIP, int port)
        {
            try
            {
                string url = "http://" + HttpServerIP + ":" + port + "/saas/kds/getKDSUserInfo/v2";
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = @"{""traceID"": ""002""}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Logcat.d(" HttpPost", "HttpKdsV2() " + response.Content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                Logcat.d(" HttpPost", "HttpKdsV2() " + e.ToString());
            }
            return false;
        }
    }
}
