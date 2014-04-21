using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace CentralLog.Web.Models
{
  public class Job
  {
    [BsonId]
    public string JobId { get; set; }

    public DateTime LatestRun { get; set; }
  }
}