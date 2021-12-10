using DataServer;
using System;
using System.Diagnostics;
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
            Process[] processes = Process.GetProcesses();
            Process currentProcess = Process.GetCurrentProcess();
            bool processExist = false;
            foreach (Process p in processes)
            {
                if (p.ProcessName == currentProcess.ProcessName && p.Id != currentProcess.Id)
                {
                    processExist = true;
                }
            }
            if (processExist)
            {
                Application.Exit();
            }
            else
            {
                //获得当前登录的Windows用户标示
                System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                //创建Windows用户主题
                Application.EnableVisualStyles();

                System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                //判断当前登录用户是否为管理员
                if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                {
                    //如果是管理员，则直接运行
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
                else
                {
                    //创建启动对象
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    //设置运行文件
                    startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                    //设置启动参数
                    //startInfo.Arguments = String.Join(" ", Args);
                    //设置启动动作,确保以管理员身份运行
                    startInfo.Verb = "runas";
                    try
                    {
                        //如果不是管理员，则启动UAC
                        System.Diagnostics.Process.Start(startInfo);
                        System.Windows.Forms.Application.Exit();
                    }
                    catch
                    {
                    }
                }
            }
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
