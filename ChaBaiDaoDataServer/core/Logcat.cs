using System;
using System.Collections.Generic;
using System.Text;

namespace ChaBaiDaoDataServer
{
    public class Logcat
    {
        public static readonly log4net.ILog logInfo = log4net.LogManager.GetLogger("Logging");
        //public static readonly log4net.ILog logError = log4net.LogManager.GetLogger("Error");
        private static bool isOpen = false;
        public static void isOpenLog(bool openBool)
        {
            isOpen = openBool;
        }

        public static void i(string TAG , string str)
        {
            if (isOpen)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(TAG + "\t");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(str);
            }
            string msg = TAG + "\t" + str;
            if (logInfo.IsInfoEnabled)
            {
                logInfo.Info(msg);
            }
        }

        public static void w(string TAG , string str)
        {
            if (isOpen)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(TAG + "\t");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(str);
            }
            string msg = TAG + "\t" + str;
            if (logInfo.IsInfoEnabled)
            {
                logInfo.Warn(msg);
            }
        }
        public static void e(string TAG , string str)
        {
            if (isOpen)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(TAG + "\t");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(str);
            }
            string msg = TAG + "\t" + str;
            logInfo.Warn(msg);
            if (logInfo.IsErrorEnabled)
            {   
                logInfo.Error(msg);
            }
        }
        
        public static void d(string TAG , string str)
        {
            if (isOpen)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(TAG + "\t");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(str);
            }
            string msg = TAG + "\t" + str;
            if (logInfo.IsInfoEnabled)
            {
                logInfo.Debug(msg);
            }
        }
       
    }
}
