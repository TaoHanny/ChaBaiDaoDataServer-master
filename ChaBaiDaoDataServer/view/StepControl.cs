using ChaBaiDaoDataServer.Properties;
using ChaBaiDaoDataServer.utils;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChaBaiDaoDataServer.view
{
    public partial class StepControl : UserControl
    {
        private string TAG = "InitStepView";

        private static string STATUS_INIT_ONE = "正在检查POS基础功能\n\n若长时间处于此状态，则代表此POS的版本低，请联系哗啦啦工作人员升级！";
        private static string STATUS_INIT_TWO = "正在检查POS接口功能";
        private static string STATUS_INIT_THREE = "正在等待数拓设备连接\n\n如果长时间处于此状态请先检查:1. 第一步的检测结果是否正常；\n\n 2. 若检测结果提示正常，请检查POS和显示屏是否在同一路由器；\n\n3. 若在同一路由器下，则联系数拓客服确认显示屏版本和配置信息";

        private static string STATUS_OK_ONE = "POS基础功能正常";
        private static string STATUS_OK_TWO = "POS售罄和订单接口运行正常";
        private static string STATUS_OK_THREE = "与数拓设备连接正常";

        private static string STATUS_NO_ONE = "未检测到哗啦啦POS的广播通信功能,请确认POS是否为2.5及以上版本！";
        private static string STATUS_NO_TWO = "哗啦啦POS数据接口无法访问，请联系哗啦啦工作人员！";
        private static string STATUS_NO_THREE = "若长时间处于此步骤，可尝试重新启动应用！";

        public static int ONE = 0x10;
        public static int TWO = 0x11;
        public static int THREE = 0x12;

        public static int OK = 0x200;
        public static int ERROR = 0x400;
        public static int INIT = 0x100;

        private Dictionary<int, string> statusItems = new Dictionary<int, string>();
        private PictureRotateUtil pictureRotateUtil = new PictureRotateUtil();
        public StepControl()
        {
            InitializeComponent();
            setpText1.Text = STATUS_INIT_ONE;
            setpText3.Text = STATUS_INIT_THREE;
            statusItems[INIT + ONE] = STATUS_INIT_ONE;
            statusItems[OK + ONE] = STATUS_OK_ONE;
            statusItems[ERROR + ONE] = STATUS_NO_ONE;

            statusItems[INIT + TWO] = STATUS_INIT_TWO;
            statusItems[OK + TWO] = STATUS_OK_TWO;
            statusItems[ERROR + TWO] = STATUS_NO_TWO;

            statusItems[INIT + THREE] = STATUS_INIT_THREE;
            statusItems[OK + THREE] = STATUS_OK_THREE;
            statusItems[ERROR + THREE] = STATUS_NO_THREE;
            pictureRotateUtil.StartRotate(ONE, stepPic1);
            pictureRotateUtil.StartRotate(THREE, setpPic3);
            
        }



        public void ChangeStatus(int index,int status)
        {
            switch (index)
            {
                case 0x10:
                    changedStep(stepPic1, setpText1, status,index);
                    break;
                case 0x12:
                    changedStep(setpPic3, setpText3, status,index);
                    break;

            }
        }

        private void changedStep(PictureBox pictureBox,Label text,  int status,int index)
        {
            if(status == OK)
            {
                pictureBox.Image = Resources.ok;
                pictureRotateUtil.StopRotate(index);
                pictureBox.Image = Resources.ok;
                text.Text = statusItems[status+index];
                text.ForeColor = System.Drawing.Color.Green;
            }
            else if(status == ERROR)
            {
                pictureBox.Image = Resources.error;
                pictureRotateUtil.StopRotate(index);
                pictureBox.Image = Resources.error;
                text.Text = statusItems[status + index];
                text.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                pictureBox.Image = Resources.loading;
                pictureRotateUtil.StartRotate(index, pictureBox);
                pictureBox.Image = Resources.loading;
                text.Text = statusItems[status + index];
                text.ForeColor = System.Drawing.Color.Gray;
            }
        }
     
    }
}
