using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using CentralLog.Web.DataAccess;
using CentralLog.Web.Models;

namespace CentralLog.Web.Controllers {
  public class DurandalController : Controller {
    private JobRepository _repository;
    

    public ActionResult Index() {
      return View();
    }

  

  }
}