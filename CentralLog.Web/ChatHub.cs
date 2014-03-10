using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
    public class CentralLogHub : Hub
    {
        public void Log(string sender, string data)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(sender, data);
        }
    }
}