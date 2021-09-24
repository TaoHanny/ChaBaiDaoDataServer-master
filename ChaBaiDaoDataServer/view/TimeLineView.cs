using HZH_Controls.Controls;
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
    public partial class TimeLineView : UserControl
    {
        public TimeLineView()
        {
            InitializeComponent();
          
        }
        
        public void addDataLog(LinkedList<TimeLineItem> lineItems)
        {
            if (lineItems != null)
            {
                this.Controls.Clear();
                this.ucTimeLine1.Items = lineItems.ToArray();
                this.Controls.Add(ucTimeLine1);
            }
            
        }

        private LinkedList<TimeLineItem> GetTimeLineItems()
        {

            LinkedList<TimeLineItem> lineItems = new LinkedList<TimeLineItem>();
            for(int i = 0; i < 20; i++)
            {
                HZH_Controls.Controls.TimeLineItem timeLineItem = new HZH_Controls.Controls.TimeLineItem();
                timeLineItem.Details = i+" 2019年10月发生了一件大事，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷" +
    "，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，咔嚓一声打了一个炸雷，然后王二麻子他爹王咔嚓出生了。";
                timeLineItem.Title = "2019年10月"+i;
                lineItems.AddFirst(timeLineItem);
            }
            return lineItems;
        }

    }
}
