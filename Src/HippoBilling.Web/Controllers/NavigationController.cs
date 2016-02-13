using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HippoBilling.Service.Practices;
using HippoBilling.Web.Models.Navigation;
using HippoBilling.Web.Mvc.Controllers;

namespace HippoBilling.Web.Controllers
{
    public class NavigationController : HippoControllerBase
    {
        private readonly IPracticeService _practiceService;
        private const int TabCount = 10;
        public NavigationController(IPracticeService practiceService)
        {
            _practiceService = practiceService;
        }

        //
        // GET: /Navigation/
        [ChildActionOnly]
        public PartialViewResult Menu()
        {

            return PartialView("_Menu", GetMenus());
        }

        [ChildActionOnly]
        public PartialViewResult CollapseMenu()
        {
            return PartialView("_CollapseMenu", GetMenus());
        }

        [ChildActionOnly]
        public PartialViewResult PracticeTab()
        {

            var controller = Request.RequestContext.RouteData.Values.ContainsKey("controller")
                            ? Request.RequestContext.RouteData.Values["controller"].ToString()
                            : string.Empty;
            var action = Request.RequestContext.RouteData.Values.ContainsKey("action")
                            ? Request.RequestContext.RouteData.Values["action"].ToString()
                            : string.Empty;
            var practiceId = GetPracticeId();
            var practices = _practiceService.GetPracticeTabs(UserId);
            var isNew = "settings".Equals(controller, StringComparison.CurrentCultureIgnoreCase) && "index".Equals(action, StringComparison.CurrentCultureIgnoreCase) && (practiceId == Guid.Empty || practices.Count==0);

           var tabs= _practiceService.GetPracticeTabs(UserId).Select(x => new PracticeTabItem()
            {
                Id=x.Id,
                Name = x.Name,
                Active = x.Id==practiceId&&!isNew,
                Url = Url.Action(action,controller,new{practice=x.Id})
            }).ToList();


            if (isNew)
            {
                if (tabs.Count < TabCount)
                {
                    tabs.Add(new PracticeTabItem()
                    {
                        Id = Guid.NewGuid(),
                        Name = string.Empty,
                        Active = true,
                        Url = "#",
                        IsNew = true
                    });
                }
                else
                {
                    var firstTab=tabs.First();
                    firstTab.Active = true;
                }
            }

            return PartialView("_PracticeTab",System.Web.Helpers.Json.Encode(tabs));
        }

        [ChildActionOnly]
        public PartialViewResult SettingLink()
        {
            var practiceId = GetPracticeId();
            return PartialView("_SettingLink",practiceId==Guid.Empty?null:new{practice=practiceId});
        }

        private IList<MenuItem> GetMenus()
        {
            var menus = new List<MenuItem>();

            menus.Add(new FaMenuItem() { Action = "index", Controller = "patients", Title = "Patients", Suffix = "group" });

            menus.Add(new MenuItem() { Action = "index", Controller = "authorizations", Title = "Authorizations" });

            menus.Add(new MenuItem() { Action = "index", Controller = "superbills", Title = "Superbills" });

            menus.Add(new MenuItem() { Action = "index", Controller = "emdeon", Title = "Emdeon" });

            menus.Add(new MenuItem() { Action = "index", Controller = "payments", Title = "Payments" });
            menus.Add(new MenuItem() { Action = "index", Controller = "collections", Title = "Collections" });
            menus.Add(new MenuItem() { Action = "index", Controller = "reports", Title = "Reports" });

            var controller = Request.RequestContext.RouteData.Values.ContainsKey("controller")
                ? Request.RequestContext.RouteData.Values["controller"].ToString()
                : string.Empty;
            var practiceId = GetPracticeId();
            menus.ForEach(x =>
            {
                x.Active = controller.Equals(x.Controller, StringComparison.CurrentCultureIgnoreCase);
                x.RouteValues = practiceId == Guid.Empty ? null : new { practice = practiceId};

            });


            return menus;

        }
    }
}