using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Patients;

namespace HippoBilling.Domain.Insurances
{
    public class Insurance : Entity
    {
        public virtual PolicyType PolicyType { get; set; }
        public string MemberNumber { get; set; }
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Payer Payer { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Order { get; set; }
        public virtual User CreatedBy { get; set; }
        public Relationship Relationship { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public virtual User LastUpdatedBy { get; set; }
    }
}