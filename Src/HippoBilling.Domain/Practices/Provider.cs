using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Addresses;

namespace HippoBilling.Domain.Practices
{
    public class Provider:Entity
    {
        public string FullName { get; set; }
        public virtual User User { get; set; }

        public string IndividualNPI { get; set; }

        public string LicenseNumber { get; set; }

        public virtual Speciality Speciality { get; set; }

        public string Degree { get; set; }

        public Gender Gender { get; set; }

        public virtual Address Address { get; set; }

        public string Phone { get; set; }

        public bool SignatureOnFile { get; set; }

        public bool Active { get; set; }

        public virtual Practice Practice { get; set; }

    }
}
