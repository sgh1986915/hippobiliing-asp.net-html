using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HippoBilling.Core.Authorization;
using HippoBilling.Service.Addresses;
using HippoBilling.Service.Practices;
using HippoBilling.Web.Models.Settings;
using HippoBilling.Web.Mvc.Controllers;

namespace HippoBilling.Web.Controllers
{
    [RoutePrefix("settings")]
    public class SettingsController : HippoControllerBase, IPermissionModule
    {
        private readonly IStateService _stateService;
        private readonly ISpecialityService _specialityService;
        private readonly IServicePlaceService _servicePlaceService;

        public SettingsController(IStateService stateService, ISpecialityService specialityService,
            IServicePlaceService servicePlaceService)
        {
            _stateService = stateService;
            _specialityService = specialityService;
            _servicePlaceService = servicePlaceService;
        }

        //
        // GET: /Settings/
        public ActionResult Index()
        {
            var model = new SettingOptionsViewModel()
            {
                SpecialityOptions = _specialityService.GetAllSpecialities().Select(x => new SelectListItem()
                {
                    Text = string.Format("{0}({1})", x.Name, x.Code),
                    Value = x.Id.ToString()
                }),
                StateOptions = _stateService.GetAllStates().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Code
                }),
                ServicePlaceOptions = _servicePlaceService.GetAllServicePlaces().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Code
                })
            };
            return View(model);
        }

        public string ModuleName
        {
            get { return "Settings"; }
        }

        public int Order
        {
            get { return 8; }
        }
    }
}