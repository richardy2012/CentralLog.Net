﻿using System;
using System.Web;
using CentralLog.Web.DataAccess;
using CentralLog.Web.Models;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
  public class CentralLogHub : Hub
  {
    JobRepository _repository;

    public CentralLogHub()
    {
      _repository = new JobRepository();
    }

    public void Step(string jobId, string jobRunId, string json)
    {
      _repository.AddLog( jobId, jobRunId, json );

      // Call the broadcastMessage method to update clients.
      Clients.All.broadcastMessage( jobId, json );
    }

    public void JobStart(string jobId, string jobName, string jobRunId)
    {
      Job job = _repository.SaveJob( jobId,jobName );

      _repository.AddJobRunStart( jobId, jobRunId );

      Clients.All.broadcastMessage( "jobstart", "JobStarted");
        _repository.AddStartJob(jobId, jobRunId);
    }

    public void JobEnd(string jobId, string jobRunId)
    {
      _repository.AddJobEnd(jobId, jobRunId);

      Clients.All.broadcastMessage( "JobEnd", "JobEnded" );
    }

  }
}