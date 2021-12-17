using ChaBaiDaoDataServer.Databean;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

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
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = response.Content;
                    ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(content);
                    Logcat.d(" HttpPost", "HttpMenu() " + responseData.msg);
                    if (responseData.code == "000")
                    {
                        return true;
                    } 
                }
            }catch(Exception e)
            {
                Logcat.e(TAG, "HttpMenu() " + e.ToString());
            }
            return false;
        }

        public static bool HttpSoldOut(string HttpServerIP, int HttpServerPort)
        {
            string url = "http://" + HttpServerIP + ":" + HttpServerPort + "/saas/openapi/getsoldoutfoodlst";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            try
            {
                
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("msgType", "410");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = response.Content;
                    ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(content);
                    Logcat.d(" HttpPost", "HttpSoldOut() " + responseData.msg);
                    if (responseData.code == "000")
                    {
                        return true;
                    }
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
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = response.Content;
                    ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(content);
                    Logcat.d(" HttpPost", "HttpOrder() " + responseData.msg);
                    if (responseData.code == "000")
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
