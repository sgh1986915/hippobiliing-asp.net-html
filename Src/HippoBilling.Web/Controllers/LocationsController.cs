using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Practices;
using HippoBilling.Service.Addresses;
using HippoBilling.Service.Practices;
using HippoBilling.Web.Models.Locations;
using HippoBilling.Web.Mvc.Controllers;

namespace HippoBilling.Web.Controllers
{
    [RoutePrefix("locations")]
    public class LocationsController : HippoControllerBase
    {
        private readonly IPracticeService _practiceService;
        private readonly IStateService _stateService;
        private readonly IServicePlaceService _servicePlaceService;
        public LocationsController(IPracticeService practiceService,IStateService stateService,IServicePlaceService servicePlaceService)
        {
            _practiceService = practiceService;
            _stateService = stateService;
            _servicePlaceService = servicePlaceService;
        }

        //
        // GET: /Location/

        [Route("search-locations")]
        public JsonResult SearchLocations(Guid practiceId, string keyword)
        {
            var model = _practiceService.GetLocations(practiceId, keyword).Select(x => new LocationJsonModel()
            {
                Id=x.Id,
                InternalName = x.InternalName,
                InternalCode = x.InternalCode,
                NPI = x.NPI,
                PlaceOfService = x.PlaceOfService.Code,
                PlaceOfServiceString = x.PlaceOfService.Name,
                Address1 = x.Address.Address1,
                Address2 = x.Address.Address2,
                City = x.Address.City,
                State = x.Address.State.Code,
                StateString = x.Address.State.Name,
                ZipCode = x.Address.ZipCode,
                Phone=x.Phone,
                FDA = x.FDA,
                CLIA = x.CLIA,
                Active = x.Active

            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("save-location")]
        public JsonResult SaveLocation(SaveLocationCommand command)
        {
            command.IsNew = command.Id == Guid.Empty;
            command.Id = command.IsNew ? Guid.NewGuid() : command.Id;
            CommandService.Execute(command);

            var state = _stateService.GetState(command.State);
            var servicePlace = _servicePlaceService.GetServicePlace(command.PlaceOfService);

            var model = new LocationJsonModel()
            {
                Id=command.Id,
                InternalName = command.InternalName,
                InternalCode = command.InternalCode,
                NPI=command.NPI,
                PlaceOfService = command.PlaceOfService,
                PlaceOfServiceString = servicePlace.Name,
                Address1 = command.Address1,
                Address2 = command.Address2,
                City = command.City,
                State = command.State,
                StateString = state.Name,
                ZipCode = command.ZipCode,
                Phone = command.Phone,
                FDA = command.FDA,
                CLIA = command.CLIA,
                Active = command.Active
            };


            return Json(model, JsonRequestBehavior.AllowGet);
        }


    }
}