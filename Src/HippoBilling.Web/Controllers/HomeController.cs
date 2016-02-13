using System.Web.Security;
using HippoBilling.Processor.Commands.Practices;
using HippoBilling.Service.Accounts;
using HippoBilling.Service.Practices;
using HippoBilling.Web.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HippoBilling.Web.Controllers
{

    public class HomeController : HippoControllerBase
    {

        public readonly IPracticeService _PracticeService;

        public HomeController(IPracticeService practiceService)
        {
            _PracticeService = practiceService;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var tabs = _PracticeService.GetUserPractices(UserId, string.Empty);
            if (tabs.Count == 1)
            {
                var tab = tabs[0];
                CommandService.Execute(new AddPracticeTabCommand(){PracticeId = tab.Id,UserId = UserId});
                return RedirectToAction("Index", "Patients", new { @practice = tab.Id});
            }

            return View();
        }

    }
}
