using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CentralLog.Core;
using Timer = System.Windows.Forms.Timer;

namespace CentralLog.EventGeneratorDemo
{
    public partial class frm_EventGeneratorDemo : Form
    {
        public frm_EventGeneratorDemo()
        {
            InitializeComponent();
            var demoLogRun = new Task(StartDemoLogging);
            demoLogRun.Start();
        }

        private void StartDemoLogging()
        {
            int i = 1;
            var jobRun = new Task(() =>
            {
                string jobId = Guid.NewGuid().ToString();
                Thread.Sleep(4000);

                CentralLogProxy.Log.LogJobStart(jobId, string.Format("This is the best job you have ever seen. JobID: {0}", jobId));

                for (int j = 0; j < 10; j++)
                {
                    Thread.Sleep(2000);
                    CentralLogProxy.Log.LogInfo("this is test message #" + i++, jobId);
                }

                // throw a demo exception on every 2cnd run
                if (i % 2 == 1)
                {
                    var exception = new ApplicationException("Demo Exception");
                    CentralLogProxy.Log.LogError(exception, "Throw it if you can", jobId);
                }

                CentralLogProxy.Log.LogJobEnd(jobId, "We have completed a legendary job.");
                i++;
            });

            for (int j = 0; j < 10; j++)
            {
                jobRun.Start();
                jobRun.Wait();
            }

        }


        private void btn_LogEvent_Click(object sender, EventArgs e)
        {
            CentralLogProxy.Log.LogInfo(this.tbx_EventMessage.Text);



        }
    }


}
