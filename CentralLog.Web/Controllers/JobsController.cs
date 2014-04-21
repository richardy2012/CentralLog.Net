using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using CentralLog.Web.DataAccess;
using CentralLog.Web.Models;

namespace CentralLog.Web.Controllers
{
    public class JobsController : ApiController
    {
      private JobRepository _repository;
      protected override void Initialize(HttpControllerContext controllerContext)
      {
        base.Initialize(controllerContext);
        _repository = new JobRepository();

      }

      public IEnumerable<Job> GetAllJobs()
      {
        IEnumerable<Job> jobs = _repository.GetJobs();
        return jobs;
      }
    }
}
