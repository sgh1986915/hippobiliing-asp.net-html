using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using HippoBilling.Core.Authorization;
using HippoBilling.Core.Enum;
using HippoBilling.Domain.Insurances;
using HippoBilling.Domain.Patients;
using HippoBilling.Processor.Commands.Insurances;
using HippoBilling.Processor.Commands.Patients;
using HippoBilling.Service.Addresses;
using HippoBilling.Service.Insurances;
using HippoBilling.Service.Patients;
using HippoBilling.Service.Practices;
using HippoBilling.Web.Models.Patients;
using HippoBilling.Web.Mvc.Controllers;
using HippoBilling.Web.Mvc.Models;
using Microsoft.Ajax.Utilities;

namespace HippoBilling.Web.Controllers
{
    [RoutePrefix("patients")]
    public class PatientsController : HippoControllerBase, IPermissionModule
    {
        private const int PageSize = 25;
        private readonly IPatientService _patientService;
        private readonly IStateService _stateService;
        private readonly IPracticeService _practiceService;
        private readonly INPIService _npiService;
        private readonly IPayerService _payerService;
        private readonly IInsuranceService _insuranceService;

        public PatientsController(IPatientService patientService, IStateService stateService,
            IPracticeService practiceService, INPIService npiService, IPayerService payerService,
            IInsuranceService insuranceService)
        {
            _patientService = patientService;
            _stateService = stateService;
            _practiceService = practiceService;
            _npiService = npiService;
            _payerService = payerService;
            _insuranceService = insuranceService;
        }

        //
        // GET: /Patients/
        public ActionResult Index()
        {
            var model = new PatientOptionsViewModel()
            {
                StateOptions = _stateService.GetAllStates().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Code
                }),
                ProviderOptions =
                    _practiceService.GetAvailableProviders(GetPracticeId()).Select(x => new SelectListItem()
                    {
                        Text = x.FullName,
                        Value = x.Id.ToString()
                    }),
                PatientStatusOptions =
                    EnumExtension.GetValues(typeof (PatientStatus))
                        .Where(x => x.Key > 0)
                        .Select(x => new SelectListItem()
                        {
                            Text = x.Value,
                            Value = x.Key.ToString()
                        }),
                PolicyTypeOptions = _insuranceService.GetPolicyTypes().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(model);
        }

        public string ModuleName
        {
            get { return "Patients"; }
        }

        [Route("search-patients")]
        public JsonResult SearchPatients(Guid practiceId, string keyword)
        {
            var model = _patientService.GetPatients(practiceId, keyword).Select(ToJsonModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("get-viewed-patients")]
        public JsonResult GetRecentlyViewedPatients(Guid practiceId)
        {
            var model = _patientService.GetRecentlyViewedPatients(practiceId).Select(ToJsonModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("get-created-patients")]
        public JsonResult GetRecentlyCreatedPatients(Guid practiceId)
        {
            var model = _patientService.GetRecentlyCreatedPatients(practiceId).Select(ToJsonModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("view-patient")]
        public JsonResult ViewPatient(ViewPatientCommand command)
        {
            CommandService.Execute(command);
            return Json(new CommandResult()
            {
                Success = true
            });
        }

        [HttpPost]
        [Route("save-patient")]
        public JsonResult SavePatient(SavePatientCommand command)
        {
            command.IsNew = command.Id == Guid.Empty;
            command.Id = command.IsNew ? Guid.NewGuid() : command.Id;
            CommandService.Execute(command);
            var patient = _patientService.GetPatient(command.Id);
            var model = ToJsonModel(patient);
            return Json(model);
        }

        public int Order
        {
            get { return 1; }
        }


        [Route("get-view-notes")]
        public JsonResult GetViewNotes(Guid patientId, string keyword, NoteLevel? level)
        {
            var model = _patientService.GetViewNotes(patientId, keyword, level).Select(ToJsonModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("save-view-note")]
        public JsonResult SaveViewNote(SavePatientNoteCommand command)
        {
            command.IsNew = command.Id == Guid.Empty;
            command.Id = command.IsNew ? Guid.NewGuid() : command.Id;
            command.UserId = UserId;
            CommandService.Execute(command);
            var note = _patientService.GetViewNote(command.Id);
            return Json(ToJsonModel(note));
        }


        [Route("lookup-patients")]
        public JsonResult LookupPatients(Guid practiceId, string name, DateTime dateOfBirth)
        {
            var model = _patientService.LookupPatients(practiceId, name, dateOfBirth).Select(ToJsonModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("search-library-physicians")]
        public JsonResult SearchLibraryPhysicians(string keyword, string state)
        {
            var model = _npiService.Lookup(keyword, state, 0, 25).Select(ToJsonModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("search-favorite-physicians")]
        public JsonResult SearchFavoritePhysicians(Guid practiceId, string keyword, string state)
        {
            var model =
                _patientService.SearchFavoritedPhysician(practiceId, keyword, state, 0, PageSize).Select(ToJsonModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Route("favorite-physician")]
        public JsonResult FavoritePhysician(FavoritePhysicianCommand command)
        {
            CommandService.Execute(command);
            return Json(new CommandResult() {Success = true});
        }

        [Route("search-library-payers")]
        public JsonResult SearchLibraryPayers(string keyword)
        {
            var model = _payerService.SearchPayers(keyword, 0, PageSize).Select(ToJsonModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("search-favorite-payers")]
        public JsonResult SearchFavoritePayers(Guid practiceId, string keyword)
        {
            var model = _payerService.SearchFavoritePayers(practiceId, keyword, 0, PageSize).Select(ToJsonModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("favorite-payer")]
        public JsonResult FavoritePayer(FavoritePayerCommand command)
        {
            CommandService.Execute(command);
            return Json(new CommandResult() {Success = true});
        }

        [HttpPost]
        [Route("save-payer")]
        public JsonResult SavePayer(SavePayerCommand command)
        {
            command.IsNew = command.Id == Guid.Empty;
            command.Id = command.IsNew ? Guid.NewGuid() : command.Id;
            command.UserId = UserId;
            CommandService.Execute(command);
            var payer = _payerService.GetPayer(command.Id);
            return Json(ToJsonModel(payer));
        }

        [Route("get-insurances")]
        public JsonResult GetInsurances(Guid patientId)
        {
            var groups = _insuranceService.GetInsuranceGroups(patientId).Select(ToJsonModel);
            return Json(groups, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("save-insurance")]
        public JsonResult SaveInsurance(SaveInsuranceCommand command)
        {
            command.IsNew = command.Id == Guid.Empty;
            command.Id = command.IsNew ? Guid.NewGuid() : command.Id;
            command.UserId = UserId;
            CommandService.Execute(command);
            var instance = _insuranceService.GetInsurance(command.Id);
            return Json(ToJsonModel(instance));
        }

        [HttpPost]
        [Route("transpose-insurance")]
        public JsonResult TransposeInsurance(TransposeInsuranceCommand command)
        {
            CommandService.Execute(command);
            return Json(new CommandResult() {Success = true});
        }

        private PatientJsonModel ToJsonModel(Patient patient)
        {
            if (patient == null) return null;
            return new PatientJsonModel()
            {
                Id = patient.Id,
                PatientNo = patient.PatientNo,
                Name = patient.Name,
                SSN = patient.SSN,
                PatientBalance = patient.PatientBalance,
                InsuranceBalance = patient.InsuranceBalance,
                DateOfBirth = patient.DateOfBirth.ToString("MM/dd/yyyy"),
                LastVisitDate = patient.LastVisitDate.ToString("MM/dd/yyyy"),
                LastViewedDate = patient.LastViewDate.ToString("MM/dd/yyyy"),
                CreatedDate = patient.CreatedDate.ToString("MM/dd/yyyy"),
                Sex = patient.Sex,
                Address1 = patient.Address.Address1,
                Address2 = patient.Address.Address2,
                City = patient.Address.City,
                State = patient.Address.State.Code,
                StateString = patient.Address.State.Name,
                ZipCode = patient.Address.ZipCode,
                PrimaryPhone = patient.PrimaryPhone,
                SecondaryPhone = patient.SecondaryPhone,
                PrimaryProvider = patient.PrimaryProvider.Id,
                ReferringPhysicanNPI = patient.ReferringPhysicanNPI,
                ReferringPhysicanName = patient.ReferringPhysicanName,
                Status = patient.Status,
                StatementMethod = patient.StatementMethod,
                StatementHold = patient.StatementHold,
                Active = patient.Active
            };
        }

        private PatientNoteJsonModel ToJsonModel(PatientNote note)
        {
            if (note == null) return null;
            return new PatientNoteJsonModel()
            {
                Id = note.Id,
                Detail = note.Detail,
                Level = (int) note.Level,
                LevelString = note.Level.GetText(),
                CreatedBy = note.CreatedBy.Name,
                CreatedDate = note.CreatedDate.ToString("MM/dd/yyyy"),
                LastUpdatedBy = note.LastUpdatedBy.Name,
                LastUpdatedDate = note.LastUpdatedDate.ToString("MM/dd/yyyy")
            };
        }

        private PhysicianJsonModel ToJsonModel(FavoritePhysician physician)
        {
            if (physician == null) return null;
            return new PhysicianJsonModel()
            {
                NPI = physician.NPI,
                Name = physician.Name,
                Phone = physician.Phone,
                Fax = physician.Fax,
                Address1 = physician.Address.Address1,
                Address2 = physician.Address.Address2,
                City = physician.Address.City,
                ZipCode = physician.Address.ZipCode,
                State = physician.Address.State == null ? string.Empty : physician.Address.State.Code,
                StateString = physician.Address.State == null ? string.Empty : physician.Address.State.Name,
                Organization = physician.Organization,
                OrganizationString = physician.Organization ? "Yes" : "No",
                Speciality = physician.Speciality == null ? string.Empty : physician.Speciality.Code,
                SpecialityString = physician.Speciality == null ? string.Empty : physician.Speciality.Name
            };
        }

        private PayerJsonModel ToJsonModel(Payer payer)
        {
            if (payer == null) return null;
            return new PayerJsonModel()
            {
                Id = payer.Id,
                Name = payer.Name,
                Address1 = payer.Address.Address1,
                Address2 = payer.Address.Address2,
                City = payer.Address.City,
                State = payer.Address.State.Code,
                StateString = payer.Address.State.Name,
                ZipCode = payer.Address.ZipCode,
                Phone = payer.Phone,
                Fax = payer.Fax,
                PayerId = payer.PayerId,
                CreatedBy = payer.CreatedBy.Name,
                CreatedDate = payer.CreatedDate.ToString("MM/dd/yyyy")
            };
        }

        private InsuranceJsonModel ToJsonModel(Insurance insurance)
        {
            if (insurance == null) return null;
            return new InsuranceJsonModel()
            {
                Id = insurance.Id,
                PolicyType = insurance.PolicyType.Id,
                PolicyTypeString = insurance.PolicyType.Name,
                PayerId = insurance.Payer.Id,
                PatientId = insurance.Patient.Id,
                Payer = ToJsonModel(insurance.Payer),
                MemberNumber = insurance.MemberNumber,
                GroupName = insurance.GroupName,
                GroupNumber = insurance.GroupNumber,
                EffectiveFrom = insurance.EffectiveFrom.ToString("MM/dd/yyyy"),
                EffectiveTo = insurance.EffectiveTo.ToString("MM/dd/yyyy"),
                LastUpdatedBy = insurance.LastUpdatedBy.Name,
                LastUpdatedDate = insurance.LastUpdatedDate.ToString("MM/dd/yyyy"),
                CreatedBy = insurance.CreatedBy.Name,
                CreatedDate = insurance.CreatedDate.ToString("MM/dd/yyyy"),
                Order = insurance.Order,
                Active = insurance.EffectiveFrom <= DateTime.Now && insurance.EffectiveTo >= DateTime.Now
            };
        }

        private InsuranceGroupJsonModel ToJsonModel(IGrouping<PolicyType, Insurance> group)
        {
            if (group == null) return null;
            return new InsuranceGroupJsonModel()
            {
                GroupId = group.Key.Id,
                GroupName = group.Key.Name,
                Insurances = group.OrderBy(x => x.Order).Select(ToJsonModel).ToList()
            };
        }
    }
}