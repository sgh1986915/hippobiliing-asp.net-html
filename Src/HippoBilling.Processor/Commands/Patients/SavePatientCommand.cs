using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;
using HippoBilling.Domain.Patients;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Processor.Commands.Patients
{
    public class SavePatientCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Sex { get; set; }
        public Guid PracticeId { get; set; }
        public decimal PatientBalance { get; set; }
        public decimal InsuranceBalance { get; set; }
        public string SSN { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public Guid PrimaryProvider { get; set; }
        public long ReferringPhysicanNPI { get; set; }
        public string ReferringPhysicanName { get; set; }
        public PatientStatus Status { get; set; }
        public StatementMethod StatementMethod { get; set; }
        public bool StatementHold { get; set; }
        public bool Active { get; set; }
        public bool IsNew { get; set; }
    }
}