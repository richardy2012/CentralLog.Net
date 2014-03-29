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
  [EventSource( Name = GlobalDefines.EVENT_SOURCE_NAME )]     // This is the name of my eventSource outside my program.  
  sealed class CentralLogEventSource : EventSource, ICentralLogEventSource
  {
    // Typically you only create one EventSource and use it throughout your program.  Thus a static field makes sense.  
    public static CentralLogEventSource Log = new CentralLogEventSource();

    string _localJobRunId = string.Empty;
    string _currentJobId = string.Empty;
    object _locker = new object();

    [NonEvent]
    public void Step(Func<string> jsonProducer, string jobId = null)
    {
      if (this.IsEnabled())
        this.Step( jsonProducer(), jobId );
    }

    [Event( 1 )]
    public void Step(string jsonData, string jobId = null, string jobRunId = null)
    {
      WriteEvent( 1, jsonData, jobId ?? _currentJobId, jobRunId ?? _localJobRunId );
    }

    [Event( 2 )]
    public void JobStart(string jobId, string jobRunId = null)
    {
      OptionalJobRunInit( jobId, jobRunId );
      WriteEvent( 2, jobId, jobRunId ?? _localJobRunId );
    }

    [Event( 3 )]
    public void JobEnd(string jobId, string jobRunId = null)
    {
      lock (_locker)
      {
        WriteEvent( 3, jobId, jobRunId ??_localJobRunId );
        _localJobRunId = null;
      }
    }

    private string OptionalJobRunInit(string jobId, string runId)
    {
      lock (_locker)
      {
        if (string.IsNullOrEmpty( jobId ))
        {
          _currentJobId = Guid.NewGuid().ToString();
        }
        else
        {
          _currentJobId = jobId;
        }

        if (string.IsNullOrEmpty( runId ))
        {
          _localJobRunId = Guid.NewGuid().ToString();
        }
        else
        {
          _localJobRunId = runId;
        }


      }

      return _localJobRunId;
    }

  }


}
