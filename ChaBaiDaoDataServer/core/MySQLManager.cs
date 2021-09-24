using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ChaBaiDaoDataServer
{
    public class MySQLManager
    {
        private static string TAG = "MySQLManager";
        private static string connStr = "server=127.0.0.1;port=3306;database=db_mendian;user=q_user;password=q_user;SslMode=none;";
        private void mysqlConnectBool()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open(); 
                if(conn.State == System.Data.ConnectionState.Open)
                {
                    sendMysqlOpenStatus(true);
                }
            }
            catch (Exception ex) {
                Logcat.e(TAG, "mysqlConnectBool() = " + ex.ToString());
                sendMysqlOpenStatus(false);
            }
        }

        private void sendMysqlOpenStatus(bool statusBool)
        {
            if (mySQLInterface != null)
            {
                mySQLInterface.OpenMysqlStatus(statusBool);
            }
        }
        public void startMysqlOpen()
        {
            Thread thread = new Thread(new ThreadStart(mysqlConnectBool));
            thread.Start();
        }

        private MySQLInterface mySQLInterface;
        public void setMySQLIntetface(MySQLInterface mySQLInterfaceImpl)
        {
            this.mySQLInterface = mySQLInterfaceImpl;
        }
    }


    

    public interface MySQLInterface
    {
        void OpenMysqlStatus(bool openStatus);
    }


}
