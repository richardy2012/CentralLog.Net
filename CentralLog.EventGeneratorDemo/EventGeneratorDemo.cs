﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CentralLog.EventGeneratorDemo
{
  static class EventGeneratorDemo
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );
      Application.Run( new frm_EventGeneratorDemo() );
    }
  }
}
