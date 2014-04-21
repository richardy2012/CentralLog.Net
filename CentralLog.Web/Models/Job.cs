using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Humanizer;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace CentralLog.Web.Models
{
  public class Job
  {
    [BsonId]
    public string Id { get; set; }

    public string Name { get; set; }

    public DateTime LatestRun { get; set; }

    public string LatestRunText{get { return this.LatestRun.Humanize(); }}
  }
}