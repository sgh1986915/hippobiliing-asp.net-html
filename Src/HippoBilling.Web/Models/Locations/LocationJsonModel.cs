using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Models.Locations
{
    public class LocationJsonModel
    {
        public Guid Id { get; set; }

        public string InternalName { get; set; }

        public string InternalCode { get; set; }

        public string NPI { get; set; }

        public string PlaceOfService { get; set; }

        public string PlaceOfServiceString { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string StateString { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public string FDA { get; set; }

        public string CLIA { get; set; }

        public bool Active { get; set; }

    }
}