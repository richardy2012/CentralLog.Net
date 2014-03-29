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
            Action jobMethod = () =>
            {
                string jobId = Guid.NewGuid().ToString();
                Thread.Sleep(4000);

                CentralLogProxy.Log.JobStart(jobId);

                for (int j = 0; j < 10; j++)
                {
                    Thread.Sleep(2000);
                    CentralLogProxy.Log.Step("this is test message #" + i++, jobId);
                }

                // throw a demo exception on every 2cnd run
                if (i % 2 == 1)
                {
                    var exception = new ApplicationException("Demo Exception");
                    CentralLogProxy.Log.Step("Throw it if you can", jobId);
                }

                CentralLogProxy.Log.JobEnd(jobId);
                i++;
            };

            for (int j = 0; j < 10; j++)
            {
                Task jobRun = new Task(jobMethod);
                jobRun.Start();
                jobRun.Wait();
            }

        }


        private void btn_LogEvent_Click(object sender, EventArgs e)
        {
            CentralLogProxy.Log.Step(this.tbx_EventMessage.Text);



        }
    }


}
