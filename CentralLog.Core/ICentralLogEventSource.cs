using System;
using Microsoft.Diagnostics.Tracing;

namespace CentralLog.Core
{
    public interface ICentralLogEventSource
    {
        [NonEvent]
        void LogData(object data, Guid? jobId = null);

        [NonEvent]
        void LogError(Exception ex, string message = null, Guid? jobId = null);

        [Event(1)]
        void LogInfo(string message, Guid? jobId = null);

        [Event(2)]
        void LogWarning(string message, Guid? jobId = null);

        [Event(3)]
        void LogError(string ex, string message = null, Guid? jobId = null);

        [Event(4)]
        void LogData(string json, Guid? jobId = null);

        [Event(5)]
        void LogJobStart(Guid jobId, string message);

        [Event(6)]
        void LogJobEnd(Guid jobId, string message);
    }
}