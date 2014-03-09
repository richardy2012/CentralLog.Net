using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Diagnostics.Tracing;

namespace CentralLog.Core
{
  public static class CentralLogProxy
  {
    public static ICentralLogEventSource Log { get { return CentralLogEventSource.Log; } }
  }


  public interface ICentralLogEventSource
  {
    void LogMessage(string sender, string receiver, string data);
  }

  // This code belongs in the process generating the events.  They are samples 
  [EventSource( Name = GlobalDefines.EVENT_SOURCE_NAME )]     // This is the name of my eventSource outside my program.  
  sealed class CentralLogEventSource : EventSource, ICentralLogEventSource
  {
    // Notice that the bodies of the events follow a pattern:  WriteEvent(ID, <args>) where ID is a unique ID 
    // Starting at 1 and giving each different event a unque one, and passing all the payload arguments on to be sent out.
    [Event( 1 )]
    public void LogMessage(string sender, string receiver, string data) { WriteEvent( 1, sender, receiver, data ); }

    // Typically you only create one EventSource and use it throughout your program.  Thus a static field makes sense.  
    public static CentralLogEventSource Log = new CentralLogEventSource();

  }


}
