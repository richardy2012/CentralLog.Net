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
    }

    private void btn_LogEvent_Click(object sender, EventArgs e)
    {
      CentralLogProxy.Log.LogMessage( "Hans", "Paul", this.tbx_EventMessage.Text );
    }
  }

  
}
