using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Models.Providers
{
    public class ProviderJsonModel
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public Guid UserId { get; set; }

        public string IndividualNPI { get; set; }

        public string LicenseNumber { get; set; }

        public string SSN { get; set; }

        public Guid Speciality { get; set; }

        public string SpecialityString { get; set; }

        public string Degree { get; set; }

        public int Gender { get; set; }

        public string GenderString { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string StateString { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public bool SignatureOnFile { get; set; }

        public bool Active { get; set; }
        public string ActiveString { get; set; }
    }
}