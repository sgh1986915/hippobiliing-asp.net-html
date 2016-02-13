using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Practices;
using HippoBilling.Service.Accounts;
using HippoBilling.Service.Practices;
using HippoBilling.Web.Models.Practices;
using HippoBilling.Web.Mvc.Controllers;
using HippoBilling.Web.Mvc.Models;

namespace HippoBilling.Web.Controllers
{
    [RoutePrefix("practices")]
    public class PracticesController : HippoControllerBase
    {
        private readonly IPracticeService _practiceService;
        private readonly INPIService _npiService;
        private readonly IUserService _userService;
        private readonly ISpecialityService _specialityService;

        private const int MaxTabCount = 10;

        public PracticesController(IPracticeService practiceService, INPIService npiService, IUserService userService,
            ISpecialityService specialityService)
        {
            _practiceService = practiceService;
            _npiService = npiService;
            _userService = userService;
            _specialityService = specialityService;
        }

        [HttpPost]
        [Route("save-practice")]
        public JsonResult SavePractice(SavePracticeCommand command)
        {
            command.UserId = UserId;
            CommandService.Execute(command);
            var model = new CommandResult { Success = true };
            if (command.IsNew)
            {
                model.Redirect = Url.Action("index", "settings", new { @practice = command.Id });
            }
            return Json(model);
        }

        [Route("get-practice")]
        public JsonResult GetPractice(Guid? id)
        {
            var practice = id.HasValue ? _practiceService.GetPractice(id.Value) : null;

            var model = new PracticeJsonModel();
            if (practice != null)
            {
                model.Name = practice.Name;
                model.TaxId = practice.TaxId;
                model.NPI = practice.NPI;
                model.PhoneNo = practice.PhoneNo;
                model.FaxNo = practice.FaxNo;
                model.Speciality = practice.Speciality.Code;
                model.Active = practice.Active;

                model.MailingAddress1 = practice.MailingLocation.Address1;
                model.MailingAddress2 = practice.MailingLocation.Address2;
                model.MailingCity = practice.MailingLocation.City;
                model.MailingZipCode = practice.MailingLocation.ZipCode;
                model.MailingState = practice.MailingLocation.State.Code;

                model.BillingAddrSameAsMailingAddr = practice.MailingLocation.Id == practice.BillingLocation.Id;

                model.BillingAddress1 = model.BillingAddrSameAsMailingAddr
                    ? model.MailingAddress1
                    : practice.BillingLocation.Address1;
                model.BillingAddress2 = model.BillingAddrSameAsMailingAddr
                    ? model.MailingAddress2
                    : practice.BillingLocation.Address2;
                model.BillingCity = model.BillingAddrSameAsMailingAddr
                    ? model.MailingCity
                    : practice.BillingLocation.City;
                model.BillingZipCode = model.BillingAddrSameAsMailingAddr
                    ? model.MailingZipCode
                    : practice.BillingLocation.ZipCode;
                model.BillingState = model.BillingAddrSameAsMailingAddr
                    ? model.MailingState
                    : practice.BillingLocation.State.Code;

                model.PaymentAddrSameAsMailingAddr = practice.MailingLocation.Id == practice.PayToLocation.Id;

                model.PaymentAddress1 = model.PaymentAddrSameAsMailingAddr
                    ? model.MailingAddress1
                    : practice.PayToLocation.Address1;
                model.PaymentAddress2 = model.PaymentAddrSameAsMailingAddr
                    ? model.MailingAddress2
                    : practice.PayToLocation.Address2;
                model.PaymentCity = model.PaymentAddrSameAsMailingAddr
                    ? model.MailingCity
                    : practice.PayToLocation.City;

                model.PaymentZipCode = model.PaymentAddrSameAsMailingAddr
                    ? model.MailingZipCode
                    : practice.PayToLocation.ZipCode;

                model.PaymentState = model.PaymentAddrSameAsMailingAddr
                    ? model.MailingState
                    : practice.PayToLocation.State.Code;
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("get-user-practices")]
        public JsonResult GetUserPractices(string keyword)
        {
            var user = _userService.GetUser(UserId);

            var model = _practiceService.GetUserPractices(UserId, keyword).Select(x => new UserPracticeJsonModel()
            {
                Id = x.Id,
                Name = x.Name,
                Address1 = x.MailingLocation.Address1,
                Address2 = x.MailingLocation.Address2,
                City = x.MailingLocation.City,
                State = x.MailingLocation.State.Name,
                ZipCode = x.MailingLocation.ZipCode,
                Active = x.Active,
                ClickAble = x.Active || (user.Role == Role.Admin)
            });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("select-practice")]
        public JsonResult SelectPractice(AddPracticeTabCommand command)
        {
            #region Check condition

            var user = _userService.GetUser(UserId);
            if (!(_practiceService.GetPractice(command.PracticeId).Active)
                && user.Role != Role.Admin)
            {
                return Json(new CommandResult
                {
                    Success = false,
                    Errors = new List<ErrorResult>
                    {
                        new ErrorResult {Error = "You not are admin user.", Name = "AuthorityError"}
                    }
                });
            }

            #endregion

            command.UserId = UserId;
            CommandService.Execute(command);
            return Json(new CommandResult()
            {
                Success = true,
                Redirect = Url.Action("index", "patients", new { @practice = command.PracticeId })
            });
        }

        [HttpPost]
        [Route("unselect-practice")]
        public JsonResult UnselectPractice(RemovePracticeTabCommand command)
        {
            command.UserId = UserId;
            CommandService.Execute(command);
            return Json(new CommandResult()
            {
                Success = true
            });
        }

        [HttpPost]
        [Route("create-practice")]
        public JsonResult CreatePractice()
        {
            var tabCount = _practiceService.GetPracticeTabCount(UserId);
            return Json(new CommandResult()
            {
                Success = tabCount < MaxTabCount,
                Redirect = tabCount < MaxTabCount ? Url.Action("index", "settings") : string.Empty
            });
        }

        [Route("lookup-npi")]
        public JsonResult LookUpNpi(string npi)
        {
            var model = new NPIRecordJsonModel();
            var record = _npiService.Lookup(npi);

            //record = new NPIRecord()
            //{
            //    NPI = 1231231234,
            //    Provider_Organization_Name__Legal_Business_Name_ = "internal name",
            //    Provider_First_Name = "first",
            //    Provider_Middle_Name = "middle",
            //    Provider_Last_Name__Legal_Name_ = "last",
            //    Provider_Credential_Text = "degreee",
            //    Provider_First_Line_Business_Practice_Location_Address = "address1",
            //    Provider_Second_Line_Business_Practice_Location_Address = "address2",
            //    Provider_Business_Practice_Location_Address_City_Name = "city",
            //    Provider_Business_Practice_Location_Address_State_Name = "AL",
            //    Provider_Business_Practice_Location_Address_Postal_Code = "12341234",
            //    Provider_Business_Practice_Location_Address_Telephone_Number = "1231231231",
            //    Provider_Business_Practice_Location_Address_Fax_Number = "1231231231",
            //    Provider_Gender_Code = "F",
            //    Healthcare_Provider_Primary_Taxonomy_Switch_1 = "n",
            //    Healthcare_Provider_Taxonomy_Code_1 = "235500000X",
            //    Provider_License_Number_1 = "license 1",
            //    Healthcare_Provider_Primary_Taxonomy_Switch_2 = "y",
            //    Healthcare_Provider_Taxonomy_Code_2 = "163WU0100X",
            //    Provider_License_Number_2 = "license 2"
            //};

            if (record == null) throw new ErrorException("The NPI Number does not exist.");

            model.NPI = record.NPI;
            model.InternalName = record.Provider_Organization_Name__Legal_Business_Name_;
            model.FullName = string.Format("{0} {1}", record.Provider_First_Name,
                string.IsNullOrEmpty(record.Provider_Middle_Name)
                    ? record.Provider_Last_Name__Legal_Name_
                    : string.Format("{0} {1}", record.Provider_Middle_Name, record.Provider_Last_Name__Legal_Name_));
            model.Degree = record.Provider_Credential_Text;
            model.Address1 = record.Provider_First_Line_Business_Practice_Location_Address;
            model.Address2 = record.Provider_Second_Line_Business_Practice_Location_Address;
            model.City = record.Provider_Business_Practice_Location_Address_City_Name;
            model.StateCode = record.Provider_Business_Practice_Location_Address_State_Name;
            model.ZipCode = record.Provider_Business_Practice_Location_Address_Postal_Code;
            model.PhoneNumber = record.Provider_Business_Practice_Location_Address_Telephone_Number;
            model.FaxNumber = record.Provider_Business_Practice_Location_Address_Fax_Number;
            model.Gender = "F".Equals(record.Provider_Gender_Code, StringComparison.CurrentCultureIgnoreCase)
                ? Gender.Famle
                : Gender.Male;

            model.LicenseNumber = record.GetLicenseNumber();
            var specialityCode = record.GetSpecialityCode();

            if (specialityCode != string.Empty)
            {
                var special = _specialityService.GetSpeciality(specialityCode);

                model.SpecialityId = special != null ? special.Id.ToString() : Guid.Empty.ToString();
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}