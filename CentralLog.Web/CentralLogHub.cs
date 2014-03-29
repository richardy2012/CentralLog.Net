using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
  public class CentralLogHub : Hub
  {
    public void Step(string jobId, string jobRunId, string json)
    {
      // Call the broadcastMessage method to update clients.
      Clients.All.broadcastMessage( jobId, json );
    }

    public void JobStart(string jobId, string jobRunId)
    {
      Clients.All.broadcastMessage( "jobstart", "JobStarted");
    }

    public void JobEnd(string jobId, string jobRunId)
    {
      Clients.All.broadcastMessage( "JobEnd", "JobEnded" );
    }

  }
}