using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HippoBilling.Core.Enum;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Practices;
using HippoBilling.Service.Addresses;
using HippoBilling.Service.Practices;
using HippoBilling.Web.Models.Providers;
using HippoBilling.Web.Models.Users;
using HippoBilling.Web.Mvc.Controllers;

namespace HippoBilling.Web.Controllers
{
    [RoutePrefix("providers")]
    public class ProvidersController : HippoControllerBase
    {
        private readonly IPracticeService _practiceService;
        private readonly IStateService _stateService;
        private readonly ISpecialityService _specialityService;
        public ProvidersController(IPracticeService practiceService,IStateService stateService,ISpecialityService specialityService)
        {
            _practiceService = practiceService;
            _stateService = stateService;
            _specialityService = specialityService;
        }

        [Route("search-providers")]
        public JsonResult SearchProviders(Guid practiceId, string keyword)
        {
            var model = _practiceService.GetProviders(practiceId, keyword).Select(x => new ProviderJsonModel
            {
                Id = x.Id,
                FullName = x.FullName,
                IndividualNPI = x.IndividualNPI,
                LicenseNumber = x.LicenseNumber,
                Gender = (int) x.Gender,
                GenderString = x.Gender.GetText(),
                Speciality = x.Speciality.Id,
                SpecialityString = x.Speciality.Name,
                Degree = x.Degree,
                UserId = x.User == null ? Guid.Empty : x.User.Id,
                Address1 = x.Address.Address1,
                Address2 = x.Address.Address2,
                City = x.Address.City,
                State = x.Address.State.Code,
                StateString = x.Address.State.Name,
                ZipCode = x.Address.ZipCode,
                Phone = x.Phone,
                SignatureOnFile = x.SignatureOnFile,
                Active = x.Active,
                ActiveString = x.Active ? "Yes" : "No"
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("save-provider")]
        [HttpPost]
        public JsonResult SaveProvider(SaveProviderCommand command)
        {
            command.IsNew = command.Id == Guid.Empty;
            command.Id = command.IsNew ? Guid.NewGuid() : command.Id;

            CommandService.Execute(command);

            var state = _stateService.GetState(command.State);
            var speciality = _specialityService.GetSpeciality(command.Speciality);

            var model = new ProviderJsonModel()
            {
                Id = command.Id,
                FullName = command.FullName,
                IndividualNPI = command.IndividualNPI,
                LicenseNumber=command.LicenseNumber,
                Gender = (int)command.Gender,
                GenderString =command.Gender.GetText(),
                Speciality = command.Speciality,
                SpecialityString =state==null?string.Empty:state.Name,
                Degree = command.Degree,
                UserId = command.UserId,
                Address1 = command.Address1,
                Address2 = command.Address2,
                City = command.City,
                State = command.State,
                StateString = speciality==null?string.Empty:speciality.Name,
                ZipCode = command.ZipCode,
                Phone = command.Phone,
                SignatureOnFile = command.SignatureonFile,
                Active = command.Active,
                ActiveString = command.Active ? "Yes" : "No" 
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("get-available-users")]
        public JsonResult GetAvailableUsers(Guid practiceId,Guid? userId)
        {
            var model = _practiceService.GetAvaiablePracticeUsers(practiceId,userId).Select(x => new UserJsonModel()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Active = x.Active
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}