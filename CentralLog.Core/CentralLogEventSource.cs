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
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(Exception ex, string message = null);
        void LogData(object data);
    }

    // This code belongs in the process generating the events.  They are samples 
    [EventSource(Name = GlobalDefines.EVENT_SOURCE_NAME)]     // This is the name of my eventSource outside my program.  
    sealed class CentralLogEventSource : EventSource, ICentralLogEventSource
    {

        // Typically you only create one EventSource and use it throughout your program.  Thus a static field makes sense.  
        public static CentralLogEventSource Log = new CentralLogEventSource();

        [NonEvent]
        public void LogData(object data)
        {
            this.LogData("todo");
        }

        [NonEvent]
        public void LogError(Exception ex, string message = null)
        {
            this.LogError("todo");
        }

        [Event(1)]        
        public void LogInfo(string message)
        {
            WriteEvent(1, message);
        }

        [Event(2)]        
        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }

        [Event(3)]
        public void LogError(string ex, string message = null)
        {
            throw new NotImplementedException();
        }

        [Event(4)]
        public unsafe void LogData(string json)
        {
            throw new NotImplementedException();
        }
    }


}
