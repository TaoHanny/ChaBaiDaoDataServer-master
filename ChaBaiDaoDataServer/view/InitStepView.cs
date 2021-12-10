using ChaBaiDaoDataServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataServer.view
{
    public partial class InitStepView : UserControl
    {

        private string TAG = "InitStepView";
        private static string STATUS_OK_ONE = "数据库连接正常！";
        private static string STATUS_OK_TWO = " 正在等待数拓设备加入\n(若长时间等待建议检\n查POS和设备是否在\n同一路由器下;或检查\n设备版本或配置)";
        private static string STATUS_OK_THRER = "一切已准备就绪！";
        private static string STATUS_INIT_ONE = "检查数据库";
        private static string STATUS_INIT_TWO = "等待数拓设备加入";
        private static string STATUS_INIT_THRER = "检查数据保活";
        private static string STATUS_NO_ONE = "数据库连接失败\n可能是用户名\n或者密码错误，\n请联系哗啦啦";
        private static string STATUS_NO_TWO = "POS网络存在问题，请检查PC网络适配器\n是否可用或者是否已连接网络\n";
        private static string STATUS_NO_THRER = "若此步骤失败，可尝试关闭重启启动应用！";
        private  string[] StepsInit = new string[] {
        STATUS_INIT_ONE,
        STATUS_INIT_TWO,
        STATUS_INIT_THRER};
        private string[] StepsOK = new string[] {
        STATUS_OK_ONE,
        STATUS_OK_TWO,
        STATUS_OK_THRER};
        private string[] StepsNO = new string[] {
        STATUS_NO_ONE,
        STATUS_NO_TWO,
        STATUS_NO_THRER};
        public InitStepView()
        {
            InitializeComponent();
            statusItems[1] = STEP_INIT;
            statusItems[2] = STEP_INIT;
            statusItems[3] = STEP_INIT;
        }

        public static int INDEX_ONE = 1;
        public static int INDEX_TWO = 2;
        public static int INDEX_THERE = 3;
        public static int STEP_INIT = 0x12;
        public static int STEP_NO = 0x13;
        public static int STEP_OK = 0x14;

        private Dictionary<int, int> statusItems = new Dictionary<int, int>();

        private string[] Steps = new string[] {
        "数据库连接",
        "数拓设备检测",
        "数据通讯检测"};
        public void ChangedStatus(int index , int statusInt)
        {
            statusItems[index] = statusInt;
            int indexInt = 1;
            foreach(int key in statusItems.Keys)
            {  
                int status = statusItems[key];
                
                if (status == STEP_OK)
                {
                    Steps[indexInt-1] = StepsOK[indexInt-1];
                }
                else if(status == STEP_NO)
                {
                    Steps[indexInt-1] = StepsNO[indexInt-1];
                }
                else
                {
                    Steps[indexInt - 1] = StepsInit[indexInt - 1];
                }
                indexInt++;
            }
            if(statusInt == STEP_NO)
            {
                cacheIndex = index;
                cacheIndex--;
            }
            else
            {
                if(cacheIndex< index)
                {
                    cacheIndex = index;
                }
            }
            this.Controls.Clear();
            this.ucStep1.Steps = Steps;
            this.ucStep1.StepIndex = cacheIndex;
            Logcat.w(TAG, Steps.ToString());
            this.Controls.Add(this.ucStep1);

        }

        private int cacheIndex = 0;
    }
}
