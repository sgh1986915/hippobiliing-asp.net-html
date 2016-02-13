using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HippoBilling.Core.Authorization;
using HippoBilling.Web.Mvc.Controllers;

namespace HippoBilling.Web.Controllers
{
    [RoutePrefix("superbills")]
    public class SuperbillsController : HippoControllerBase,IPermissionModule
    {
        //
        // GET: /Superbills/
        public ActionResult Index()
        {
           
            
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public string ModuleName
        {
            get { return "Superbills"; }
        }


        public int Order
        {
            get { return 3; }
        }
    }
}