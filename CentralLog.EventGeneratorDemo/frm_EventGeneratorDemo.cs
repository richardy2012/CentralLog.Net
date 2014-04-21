using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CentralLog.Core;
using Newtonsoft.Json;
using Timer = System.Windows.Forms.Timer;

namespace CentralLog.EventGeneratorDemo
{
  public partial class frm_EventGeneratorDemo : Form
  {
    public frm_EventGeneratorDemo()
    {
      InitializeComponent();
      var demoLogRun = new Task( StartDemoLogging );
      demoLogRun.Start();
    }

    private void StartDemoLogging()
    {
      Thread.Sleep(4000);
      int i = 1;
      Action jobMethod = () =>
      {
        var stopwatch = new Stopwatch();
        stopwatch.Restart();

        string jobId = Guid.NewGuid().ToString();

        CentralLogProxy.Log.JobStart( i.ToString(), string.Format("This.Is.Job#{0}", jobId) );

        for (int j = 0; j < 20; j++)
        {
          
          var jsonObj = new { text = "this is test message #" + i++ };
          var jsonString = JsonConvert.SerializeObject( jsonObj );

          CentralLogProxy.Log.Step( jsonString, jobId );
        }

        //  throw a demo exception on every 2cnd run
        if (i % 2 == 1)
        {
          var exception = new ApplicationException( "Demo Exception" );

          var serializedException = JsonConvert.SerializeObject( exception );

          CentralLogProxy.Log.Step( serializedException, jobId );
        }

        CentralLogProxy.Log.JobEnd( jobId );
        i++;

        stopwatch.Stop();
        Console.WriteLine("sending messages took {0}ms",stopwatch.ElapsedMilliseconds);
      };

      for (int j = 0; j < 8; j++)
      {
        Task jobRun = new Task( jobMethod );
        jobRun.Start();
        jobRun.Wait();
      }

    }


    private void btn_LogEvent_Click(object sender, EventArgs e)
    {
      CentralLogProxy.Log.Step( this.tbx_EventMessage.Text );
    }
  }


}
