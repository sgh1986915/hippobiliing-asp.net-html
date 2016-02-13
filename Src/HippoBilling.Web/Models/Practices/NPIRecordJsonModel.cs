using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Web.Models.Practices
{
    public class NPIRecordJsonModel
    {
        public string NPI { get; set; }

        public string FullName { get; set; }

        public string InternalName { get; set; }

        public string Degree { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string StateCode { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public Gender Gender { get; set; }

        public string LicenseNumber { get; set; }

        public string SpecialityId { get; set; }
    }
}