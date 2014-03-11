using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Diagnostics.Tracing;
using Newtonsoft.Json;

namespace CentralLog.Core
{
    public static class CentralLogProxy
    {
        public static ICentralLogEventSource Log { get { return CentralLogEventSource.Log; } }
    }

    // This code belongs in the process generating the events.  They are samples 
    [EventSource(Name = GlobalDefines.EVENT_SOURCE_NAME)]     // This is the name of my eventSource outside my program.  
    sealed class CentralLogEventSource : EventSource, ICentralLogEventSource
    {
        // Typically you only create one EventSource and use it throughout your program.  Thus a static field makes sense.  
        public static CentralLogEventSource Log = new CentralLogEventSource();

        [NonEvent]
        public void LogData(object data, string jobId = null)
        {
            if (this.IsEnabled())
                this.LogData(JsonConvert.SerializeObject(data), jobId);
        }

        [NonEvent]
        public void LogError(Exception ex, string message = null, string jobId = null)
        {
            this.LogError(ex.ToString(), message, jobId);
        }

        [Event(1)]
        public void LogInfo(string message, string jobId = null)
        {
            WriteEvent(1, message, jobId);
        }

        [Event(2)]
        public void LogWarning(string message, string jobId = null)
        {
            WriteEvent(2, message, jobId);
        }

        [Event(3)]
        public void LogError(string exception, string message = null, string jobId = null)
        {
            WriteEvent(3, exception, message, jobId);
        }

        [Event(4)]
        public void LogData(string jsonData, string jobId = null)
        {
            WriteEvent(4, jsonData, jobId);
        }

        [Event(5)]
        public void LogJobStart(string jobId, string message = null)
        {
            WriteEvent(5, jobId, message);
        }

        [Event(6)]
        public void LogJobEnd(string jobId, string message = null)
        {
            WriteEvent(6, jobId, message);
        }


    }


}
