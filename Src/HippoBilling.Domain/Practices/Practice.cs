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
    public class Practice:Entity
    {
        public string Name { get; set; }

        public string TaxId { get; set; }

        public string NPI { get; set; }

        public string PhoneNo { get; set; }

        public string FaxNo { get; set; }

        public virtual Speciality Speciality { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public virtual Address MailingLocation { get; set; }

        public virtual Address BillingLocation { get; set; }

        public virtual Address PayToLocation { get; set; }

        public virtual List<PracticeUser> PracticeUsers { get; set; } 

    }
}
