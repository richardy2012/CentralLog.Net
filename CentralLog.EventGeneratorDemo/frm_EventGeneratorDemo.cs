using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CentralLog.Core;

namespace CentralLog.EventGeneratorDemo
{
    public partial class frm_EventGeneratorDemo : Form
    {
        public frm_EventGeneratorDemo()
        {
            InitializeComponent();
            StartDemoLogging();
        }

        private void StartDemoLogging()
        {
            Timer timer = new Timer();
            timer.Interval = 200;

            int i = 1;
            timer.Tick += (me, args) => CentralLogProxy.Log.LogInfo("this is test message #" + i++);
            timer.Start();
        }


        private void btn_LogEvent_Click(object sender, EventArgs e)
        {
            CentralLogProxy.Log.LogInfo(this.tbx_EventMessage.Text);

            

        }
    }


}
