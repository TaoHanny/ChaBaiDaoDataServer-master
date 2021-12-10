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
                //��õ�ǰ��¼��Windows�û���ʾ
                System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                //����Windows�û�����
                Application.EnableVisualStyles();

                System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                //�жϵ�ǰ��¼�û��Ƿ�Ϊ����Ա
                if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                {
                    //����ǹ���Ա����ֱ������
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
                else
                {
                    //������������
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    //���������ļ�
                    startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                    //������������
                    //startInfo.Arguments = String.Join(" ", Args);
                    //������������,ȷ���Թ���Ա�������
                    startInfo.Verb = "runas";
                    try
                    {
                        //������ǹ���Ա��������UAC
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
