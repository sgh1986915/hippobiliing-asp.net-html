using HippoBilling.Core.Authorization;
using HippoBilling.Web.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HippoBilling.Web.Controllers
{
    public class EmdeonController : HippoControllerBase, IPermissionModule
    {
        //
        // GET: /Emdeon/
        public ActionResult Index()
        {
            return View();
        }

        public string ModuleName
        {
            get { return "Emdeon"; }
        }


        public int Order
        {
            get { return 4; }
        }
    }
}