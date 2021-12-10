using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChaBaiDaoDataServer.Databean
{
    public class DataMsg
    {
        //{"DBPassword":"0161F75BA38C89EA420002187CFE2F077EF103","ShopID":"76132297","DeviceBound":1,"DBServerPort":3306,"HttpServerPort":8060,
        //"DBUserName":"root","ShopName":"Lana（专用勿动）","Database":"db_mendian","HttpServerIP":"192.168.20.234","DBServerIP":"192.168.20.234",
        //"ComputerName":"DESKTOP-MUN1TE6"}
        /// <summary>
        /// 
        /// </summary>
        public string DBPassword { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DeviceBound { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DBServerPort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int HttpServerPort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DBUserName { get; set; }
        /// <summary>
        /// Lana（专用勿动）
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HttpServerIP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DBServerIP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ComputerName { get; set; }
    }
}
