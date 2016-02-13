using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HippoBilling.Core.Authorization;
using HippoBilling.Web.Mvc.Controllers;

namespace HippoBilling.Web.Controllers
{
    public class CollectionsController : HippoControllerBase, IPermissionModule
    {
        //
        // GET: /Collections/
        public ActionResult Index()
        {
            return View();
        }

        public string ModuleName
        {
            get { return "Collections"; }
        }


        public int Order
        {
            get { return 6; }
        }
    }
}