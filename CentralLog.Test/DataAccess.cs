using System;
using CentralLog.Web.DataAccess;
using CentralLog.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralLog.Test
{
  [TestClass]
  public class DataAccessTests
  {
    private JobRepository _repository;
    [TestInitialize]
    public void Setup()
    {
      _repository = new JobRepository();

    }

    [TestMethod]
    public void CreateJobTest()
    {
      var job = new Job()
      {
        JobId = Guid.NewGuid().ToString()
      };

      var jobRunId = Guid.NewGuid().ToString();

      _repository.AddJobRunStart( job.JobId, jobRunId );

      // todo: check wether we created a job and a job run
      

    }
  }
}
