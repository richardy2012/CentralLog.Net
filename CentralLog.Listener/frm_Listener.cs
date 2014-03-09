using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CentralLog.Core;
using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Session;

namespace CentralLog.Listener
{
  public partial class frm_Listener : Form
  {
    public TraceEventSession _session;

    public frm_Listener()
    {
      InitializeComponent();
      Task backgroundTask = new Task( StartListening, TaskCreationOptions.LongRunning );
      backgroundTask.Start();
    }

    private void StartListening()
    {
      Console.WriteLine( "Starting Listening for events" );

      _session = new TraceEventSession( "MyRealTimeSession" );         // Create a session to listen for events

      _session.Source.Dynamic.All += delegate(TraceEvent data)              // Set Source (stream of events) from session.  
      {                                                                    // Get dynamic parser (knows about EventSources) 
        // Subscribe to all EventSource events
        Console.WriteLine( "GOT Event " + data );                          // Print each message as it comes in 
        OutputEvent( data.Dump());
      };

      _session.StopOnDispose = true;

      var eventSourceGuid = TraceEventProviders.GetEventSourceGuidFromName( GlobalDefines.EVENT_SOURCE_NAME ); // Get the unique ID for the eventSouce. 
      _session.EnableProvider( eventSourceGuid );                                               // Enable MyEventSource.
      _session.Source.Process();                                                              // Wait for incoming events (forever).  

    }

    

    private void OutputEvent(string message)
    {
      Action<string> callback = (string msg) => { this.tbx_output.Text += msg; };
      if (this.tbx_output.InvokeRequired)
      {
        this.Invoke( callback,message );
      }
      else
      {
        callback(message);
      }
    }
  }
}
