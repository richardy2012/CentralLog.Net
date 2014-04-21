using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentralLog.Web.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace CentralLog.Web.DataAccess
{
  public class JobRepository
  {
    public MongoServer _server;
    public MongoDatabase _database;

    public JobRepository()
    {
      this.Initialize( "mongodb://localhost:27017/centrallogdev" );
    }

    public void Initialize(string connectionString)
    {
      var mongoUrl = new MongoUrl( connectionString );
      var client = new MongoClient( mongoUrl );
      _server = client.GetServer();
      _database = _server.GetDatabase( mongoUrl.DatabaseName );
    }

    public void AddLog(string jobId, string jobRunId, string json)
    {
      var data = JsonConvert.DeserializeObject<Dictionary<string, string>>( json );

      BsonDocument logStep = new BsonDocument();
      logStep.Add( "jobId", jobId );
      logStep.Add( "jobRunId", jobRunId );

      foreach (KeyValuePair<string, string> item in data)
      {
        logStep.Add( item.Key, item.Value );
      }

      var stepCollection = _database.GetCollection( "steps" );
      stepCollection.Insert( logStep );
    }

    internal Models.Job CreateUpdateJob(string jobId)
    {
      var jobCollection = _database.GetCollection<Job>("jobs");

      var job = new Job()
      {
        JobId = jobId,
        LatestRun = DateTime.UtcNow
      };

      jobCollection.Save(job);

      return job;
    }

    internal void AddJobRunStart(string jobId, string jobRunId)
    {
      var jobRunCollection = GetJobRunCollection();

      jobRunCollection.Save(new JobRun()
      {
        JobRunId = jobRunId,
        JobId = jobId,
        TimeStamp = DateTime.UtcNow
      });
    }

    private MongoCollection<JobRun> GetJobRunCollection()
    {
      return _database.GetCollection<JobRun>("jobRuns");
    }

    internal void AddJobEnd(string jobId, string jobRunId)
    {
      var jobRunCollection = this.GetJobRunCollection();

      jobRunCollection.Save(new JobRun()
      {
        JobRunId = jobRunId,
        JobId = jobId,
        EndTimeStamp = DateTime.UtcNow
      });
    }

    internal void AddStartJob(string jobId, string jobRunId)
    {
    }
  }
}