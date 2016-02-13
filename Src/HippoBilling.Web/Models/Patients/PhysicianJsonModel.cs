using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HippoBilling.Domain.Addresses;

namespace HippoBilling.Web.Models.Patients
{
    public class PhysicianJsonModel
    {
        public string NPI { get; set; }
        public string Name { get; set; }
        public bool Organization { get; set; }
        public string OrganizationString { get; set; }
        public string Speciality { get; set; }
        public string SpecialityString { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateString { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}