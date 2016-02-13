using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Domain.Patients
{
    public class Patient : Entity
    {
        public int PatientNo { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public Gender Sex { get; set; }
        public decimal PatientBalance { get; set; }
        public decimal InsuranceBalance { get; set; }
        public virtual Address Address { get; set; }
        public PatientStatus Status { get; set; }
        public virtual Provider PrimaryProvider { get; set; }
        public StatementMethod StatementMethod { get; set; }
        public long ReferringPhysicanNPI { get; set; }
        public string ReferringPhysicanName { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastViewDate { get; set; }
        public DateTime LastVisitDate { get; set; }

        public bool StatementHold { get; set; }
        public bool Active { get; set; }
    }
}