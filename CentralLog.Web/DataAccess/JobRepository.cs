using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    internal void AddStartJob(string jobId, string jobRunId)
    {
        //var jobCollection = _database.
    }
  }
}