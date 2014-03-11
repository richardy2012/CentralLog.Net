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

    // This code belongs in the process generating the events.  They are samples 
    [EventSource(Name = GlobalDefines.EVENT_SOURCE_NAME)]     // This is the name of my eventSource outside my program.  
    sealed class CentralLogEventSource : EventSource, ICentralLogEventSource, ICentralLogEventSource
    {
        // Typically you only create one EventSource and use it throughout your program.  Thus a static field makes sense.  
        public static CentralLogEventSource Log = new CentralLogEventSource();

        [NonEvent]
        public void LogData(object data, Guid? jobId = null)
        {
            this.LogData("todo");
        }

        [NonEvent]
        public void LogError(Exception ex, string message = null, Guid? jobId = null)
        {
            this.LogError("todo");
        }

        [Event(1)]        
        public void LogInfo(string message, Guid? jobId = null)
        {
            WriteEvent(1, message);
        }

        [Event(2)]
        public void LogWarning(string message, Guid? jobId = null)
        {
            throw new NotImplementedException();
        }

        [Event(3)]
        public void LogError(string ex, string message = null, Guid? jobId = null)
        {
            throw new NotImplementedException();
        }

        [Event(4)]
        public void LogData(string json, Guid? jobId = null)
        {
            throw new NotImplementedException();
        }

        [Event(5)]
        public void LogJobStart(Guid jobId, string message)
        {
            
        }

        [Event(6)]
        public void LogJobEnd(Guid jobId, string message)
        {
            
        }

      
    }


}
