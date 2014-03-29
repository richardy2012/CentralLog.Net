using System;
using Microsoft.Diagnostics.Tracing;

namespace CentralLog.Core
{
    public interface ICentralLogEventSource
    {
   void JobStart(string jobId, string jobRunId = null);
   void JobEnd(string jobId, string jobRunId = null);
   void Step(string jsonData, string jobId = null, string jobRunId = null);
       
    }
}