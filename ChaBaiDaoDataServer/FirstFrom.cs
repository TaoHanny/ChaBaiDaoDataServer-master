using ChaBaiDaoDataServer;
using HZH_Controls.Forms;
using System;
using System.Windows.Threading;

namespace DataServer
{
    public partial class FirstFrom : FrmBase
    {
        public FirstFrom()
        {
            InitializeComponent();

            
                //DispatcherTimer

                DispatcherTimer timer = new DispatcherTimer();

                timer.Interval = TimeSpan.FromSeconds(2);

                timer.Start();

                timer.Tick += delegate
                {
                    new MainForm().ShowDialog();
                    this.Close();
                    timer.Stop();
                    
                };
 
            
        }
    }
}
