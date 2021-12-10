using Microsoft.Win32;
using System.Windows.Forms;

namespace ChaBaiDaoDataServer.core
{
    public class BootOnOff
    {
        private static string TAG = "BootOnOff";
        public static void BootOn()
        {
            if (BootOnOff.BootIsSet()) return;
            // 获得应用程序路径
            string strAssName = Application.StartupPath + @"\" + "Shutuo_HuaLaLaTool" + @".exe";
            // 获得应用程序名称
            string strShortFileName = Application.ProductName;
            
              // 打开注册表基项"HKEY_LOCAL_MACHINE"
              RegistryKey rgkRun = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
              if (rgkRun == null)
              {   
                  // 若不存在，创建注册表基项"HKEY_LOCAL_MACHINE"
                  rgkRun = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                  Logcat.d(TAG, "BootOn() 添加开机启动成功");
              }
            
             // 设置指定的注册表项的指定名称/值对。如果指定的项不存在，则创建该项。
             rgkRun.SetValue(strShortFileName, strAssName);
             Logcat.d(TAG, "BootOn() 添加开机启动成功");
        }


        public static bool BootIsSet()
        {
            // 获得应用程序路径
            string strAssName = Application.StartupPath + @"\" + "Shutuo_HuaLaLaTool" + @".exe";
            // 获得应用程序名称
            string strShortFileName = Application.ProductName;

            // 打开注册表基项"HKEY_LOCAL_MACHINE"
            RegistryKey rgkRun = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rgkRun == null)
            {
                // 若不存在，创建注册表基项"HKEY_LOCAL_MACHINE"
                rgkRun = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                
            }

            object name = rgkRun.GetValue(strShortFileName, null);
            Logcat.d(TAG, "BootIsSet() 应用当前设置的name = "+name);
            if (name == null)
            {
                return false;
            }
            return true;
        }

        public static void BootOff()
        {
            if (!BootIsSet()) return;
            // 获得应用程序名称
            string strShortFileName = Application.ProductName;
            
              // 打开注册表基项"HKEY_LOCAL_MACHINE"
              RegistryKey rgkRun = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
              if (rgkRun == null)
              {   // 若不存在，创建注册表基项"HKEY_LOCAL_MACHINE"
                  rgkRun = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                Logcat.d(TAG, "BootOff() 已关闭开机启动");
              }
            
             // 删除指定的注册表项的指定名称/值对。
             rgkRun.DeleteValue(strShortFileName, false);
            Logcat.d(TAG, "BootOff() 已关闭开机启动");
        }
    }
}
