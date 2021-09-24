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

            //����δ������쳣
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //����UI�߳��쳣
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //�����UI�߳��쳣
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
            {//ѭ����������Ӧ�ó��򽫻��˳�
                if (glExitApp)
                {//��־Ӧ�ó�������˳�����������˳��󣬽�����Ȼ������
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
        /// ��ʾ��������������ϸ��Ϣ
        /// </summary>
    }   
}
