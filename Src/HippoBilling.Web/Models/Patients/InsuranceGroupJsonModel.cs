using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using HippoBilling.Domain.Insurances;

namespace HippoBilling.Web.Models.Patients
{
    public class InsuranceGroupJsonModel
    {
        //group by policy type
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public List<InsuranceJsonModel> Insurances { get; set; }
    }

    public class InsuranceJsonModel
    {
        public Guid Id { get; set; }
        public Guid PolicyType { get; set; }
        public string PolicyTypeString { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string MemberNumber { get; set; }
        public Guid PayerId { get; set; }
        public Guid PatientId { get; set; }
        public PayerJsonModel Payer { get; set; }
        public string GroupName { get; set; }
        public string GroupNumber { get; set; }
        public string EffectiveFrom { get; set; }
        public string EffectiveTo { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public Relationship Relationship { get; set; }
        public string RelationshipString { get; set; }
    }
}