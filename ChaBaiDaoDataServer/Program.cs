using DataServer;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ChaBaiDaoDataServer
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #if DEBUG
                        AllocConsole();
            #endif
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            FreeConsole();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        static bool glExitApp = false;

        private static string TAG = "Application";
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logcat.e(TAG,"CurrentDomain_UnhandledException");
            Logcat.e(TAG,"IsTerminating : " + e.IsTerminating.ToString());
            Logcat.e(TAG,e.ExceptionObject.ToString());

            while (true)
            {//循环处理，否则应用程序将会退出
                if (glExitApp)
                {//标志应用程序可以退出，否则程序退出后，进程仍然在运行
                    Logcat.e(TAG,"ExitApp");
                    return;
                }
                System.Threading.Thread.Sleep(2 * 1000);
            };
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Logcat.e(TAG,"Application_ThreadException:" +
                e.Exception.Message);
            Logcat.e(TAG,e.Exception.ToString());
            //throw new NotImplementedException();
        }



        /// <summary>
        /// 显示本机各网卡的详细信息
        /// </summary>
    }   
}
