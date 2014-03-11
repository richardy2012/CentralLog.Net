using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
    public class CentralLogHub : Hub
    {
        public void Log(string level, string message, string jobId)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(level, message);
        }

        public void LogError(string exception, string message, string jobId)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage("error", message);
        }

        public void LogData(string json, string jobId)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage("data", json);
        }

        public void LogJobStart(string jobId, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage("JobStart", message);
        }

        public void LogJobEnd(string jobId, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage("JobEnd", message);
        }
    }
}