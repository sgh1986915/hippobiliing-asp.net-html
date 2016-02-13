using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HippoBilling.Core.Authorization;
using HippoBilling.Web.Mvc.Controllers;
using HippoBilling.Service.Practices;
using HippoBilling.Service.Authorizations;
using HippoBilling.Web.Models.Authorizations;
using HippoBilling.Processor.Commands.Authorizations;
using HippoBilling.Web.Mvc.Models;

namespace HippoBilling.Web.Controllers
{
    [RoutePrefix("authorizations")]
    public class AuthorizationsController : HippoControllerBase,IPermissionModule
    {
        private readonly IPracticeService _practiceService;
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationsController(IPracticeService practiceService, IAuthorizationService authorizationService)
        {
            _practiceService = practiceService;
            _authorizationService = authorizationService;
        }

        //
        // GET: /Authorizations/
        public ActionResult Index()
        {
            return View(GetPracticeId());
        }

        public ActionResult New()
        {
            var model = new AuthorizationOptionsViewModel()
            {
                ProviderOptions = _practiceService.GetAvailableProviders(GetPracticeId()).Select(x => new SelectListItem()
                {
                    Text = x.FullName,
                    Value = x.Id.ToString()
                }),
                LocationOptions = _practiceService.GetLocations(GetPracticeId(), null).Select(x => new SelectListItem() 
                {
                    Text = x.InternalName,
                    Value = x.Id.ToString()
                }),
                CurrentPractice = _practiceService.GetPractice(GetPracticeId())
            };

            return View(model);
        }

        [HttpPost]
        [Route("save-authorization")]
        public JsonResult SaveAuthorization(SaveAuthorizationCommand command)
        {
            command.IsNew = command.Id == Guid.Empty;
            command.Id = command.IsNew ? Guid.NewGuid() : command.Id;
            CommandService.Execute(command);
            var model = new CommandResult { Success = true };
            if (command.IsNew)
            {
                model.Redirect = Url.Action("index", "authorizations", new { @practice = command.PracticeId });
            }

            return Json(model);
        }

        [Route("get-authorizations")]
        public JsonResult GetAuthorizations(Guid practiceId)
        {
            var model = _authorizationService.GetAuthorizations(practiceId).Select(x => new AuthorizationJsonModel()
            {
                Id = x.Id,
                Patient = x.Patient.Name,
                Insurance = "",
                SubmittedDate = "",
                CompletedDate = x.CreatedDate.ToString("MM/dd/yyyy"),
                Provider = x.Provider.FullName,
                Location = x.Location.InternalName
            });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public string GetProviderNPI(Guid id)
        {
            return _practiceService.GetProvider(id).IndividualNPI;
        }

        public string ModuleName
        {
            get { return "Authorizations"; }
        }

        public int Order
        {
            get { return 2; }
        }
    }
}