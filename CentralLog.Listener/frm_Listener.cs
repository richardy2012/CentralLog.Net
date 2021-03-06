﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CentralLog.Core;
using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Session;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using ConnectionState = Microsoft.AspNet.SignalR.Client.ConnectionState;

namespace CentralLog.Listener
{
  public partial class frm_Listener : Form
  {
    public TraceEventSession _session;
    private HubConnection _hubConnection;
    private IHubProxy _centralLogHubProxy;

    public frm_Listener()
    {
      InitializeComponent();

      // Form Initialization
      this.tbx_SignalrHost.Text = ConfigurationManager.AppSettings["SignalrHost"];

      
    }

    private void StartListening()
    {
      Console.WriteLine( "Starting Listening for events" );

      _session = new TraceEventSession( "MyRealTimeSession" );         // Create a session to listen for events

      _session.Source.Dynamic.All += delegate(TraceEvent data)              // Set Source (stream of events) from session.  
      {                                                                    // Get dynamic parser (knows about EventSources) 
        // Subscribe to all EventSource events
        //OutputEvent( data.Dump() );


        if (data.EventName != "JobStart" && data.EventName != "JobEnd" && data.EventName != "Step") return;


        if (_hubConnection != null && _hubConnection.State == ConnectionState.Connected)
        {
          string jsonData = data.PayloadByName( "jsonData" ) as string;
          object jobId = data.PayloadByName( "jobId" );
          object jobRunId = data.PayloadByName( "jobRunId" );


          Stopwatch watch = new Stopwatch();

          watch.Restart();
          if (string.IsNullOrEmpty( jsonData ))
          {
            if (data.EventName == "JobStart")
            {
              object jobName = data.PayloadByName( "jobName" ) as string;
              _centralLogHubProxy.Invoke( data.EventName, jobId, jobName, jobRunId ).Wait();
            }
            else
            {
              _centralLogHubProxy.Invoke( data.EventName, jobId, jobRunId ).Wait();
            }
          }
          else
          {
            _centralLogHubProxy.Invoke( data.EventName, jobId, jobRunId, jsonData ).Wait();
          }
          watch.Stop();
          //Console.WriteLine( "sending took {0}ms",watch.ElapsedMilliseconds);

        }
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
        this.Invoke( callback, message );
      }
      else
      {
        callback( message );
      }
    }

    private void btn_ConnectHub_Click(object sender, EventArgs e)
    {
      // Start ETW Listening
      var backgroundTask = new Task( StartListening, TaskCreationOptions.LongRunning );
      backgroundTask.Start();

      // Connect to Signalr Hub
      var hubAddress = this.tbx_SignalrHost.Text;
      _hubConnection = new HubConnection( hubAddress );
      _centralLogHubProxy = _hubConnection.CreateHubProxy( "CentralLogHub" );

      _hubConnection.StateChanged += _hubConnection_StateChanged;
      _hubConnection.Start();
    }

    void _hubConnection_StateChanged(StateChange obj)
    {
      OutputEvent(obj.NewState.ToString());
    }

    private void btn_TestSend_Click(object sender, EventArgs args) 
    {
      _centralLogHubProxy.Invoke( "JobStart", "Manual Job ID", "TestName", "Manual Job Run ID" ).Wait();
    }



  }
}
