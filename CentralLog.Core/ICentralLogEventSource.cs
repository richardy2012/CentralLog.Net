using System;
using Microsoft.Diagnostics.Tracing;

namespace CentralLog.Core
{
    public interface ICentralLogEventSource
    {
        [NonEvent]
        void LogData(object data, string jobId = null);

        [NonEvent]
        void LogError(Exception ex, string message = null, string jobId = null);

        [Event(1)]
        void LogInfo(string message, string jobId = null);

        [Event(2)]
        void LogWarning(string message, string jobId = null);

        [Event(3)]  
        void LogError(string ex, string message = null, string jobId = null);

        [Event(4)]
        void LogData(string json, string jobId = null);

        [Event(5)]
        void LogJobStart(string jobId, string message = null);

        [Event(6)]
        void LogJobEnd(string jobId, string message = null);
    }
}