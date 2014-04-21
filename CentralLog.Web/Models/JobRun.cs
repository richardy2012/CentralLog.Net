using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CentralLog.Web.Models
{
  class JobRun
  {
    [BsonId]
    public string JobRunId { get; set; }

    public string JobId { get; set; }

    public DateTime TimeStamp { get; set; }

    public DateTime EndTimeStamp { get; set; }
  }
}
