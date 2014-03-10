using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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

            var backgroundTask = new Task(StartListening, TaskCreationOptions.LongRunning);
            backgroundTask.Start();
        }

        private void StartListening()
        {
            Console.WriteLine("Starting Listening for events");

            _session = new TraceEventSession("MyRealTimeSession");         // Create a session to listen for events

            _session.Source.Dynamic.All += delegate(TraceEvent data)              // Set Source (stream of events) from session.  
            {                                                                    // Get dynamic parser (knows about EventSources) 
                // Subscribe to all EventSource events
                Console.WriteLine("GOT Event " + data);                          // Print each message as it comes in 
                OutputEvent(data.Dump());

                if (_hubConnection != null && _hubConnection.State == ConnectionState.Connected)
                {
                    _centralLogHubProxy.Invoke("Log", data.PayloadByName("sender") , data.PayloadByName("data"));
                }
            };

            _session.StopOnDispose = true;

            var eventSourceGuid = TraceEventProviders.GetEventSourceGuidFromName(GlobalDefines.EVENT_SOURCE_NAME); // Get the unique ID for the eventSouce. 
            _session.EnableProvider(eventSourceGuid);                                               // Enable MyEventSource.
            _session.Source.Process();                                                              // Wait for incoming events (forever).  

        }



        private void OutputEvent(string message)
        {
            Action<string> callback = (string msg) => { this.tbx_output.Text += msg; };
            if (this.tbx_output.InvokeRequired)
            {
                this.Invoke(callback, message);
            }
            else
            {
                callback(message);
            }
        }

        private void btn_ConnectHub_Click(object sender, EventArgs e)
        {
            var hubAddress = this.tbx_SignalrHost.Text;
            _hubConnection = new HubConnection(hubAddress);

            _centralLogHubProxy = _hubConnection.CreateHubProxy("CentralLogHub");
            //centralLogHubProxy.On<Stock>("UpdateStockPrice", stock => Console.WriteLine("Stock update for {0} new price {1}", stock.Symbol, stock.Price));
            _hubConnection.Start().Wait();
        }



    }
}
