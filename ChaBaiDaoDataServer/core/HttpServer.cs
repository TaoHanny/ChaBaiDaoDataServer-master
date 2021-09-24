
using System.Collections.Generic;
using System.Net;

namespace ChaBaiDaoDataServer
{
    public class HttpServer
    {
        private HttpListener httpListener = new HttpListener();
        public bool IsSupported()
        {
            if (HttpListener.IsSupported)
            {
                return true;
            }
            return false;
        }

        private  List<string> prefixes = new List<string> { "http://localhost:51515" };


        


    }
}
