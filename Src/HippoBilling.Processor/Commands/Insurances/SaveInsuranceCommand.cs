using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;
using HippoBilling.Domain.Insurances;

namespace HippoBilling.Processor.Commands.Insurances
{
    public class SaveInsuranceCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid PolicyType { get; set; }
        public string MemberNumber { get; set; }
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public Guid PatientId { get; set; }
        public Guid PayerId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public Guid UserId { get; set; }
        public Relationship Relationship { get; set; }
        public bool IsNew { get; set; }
    }
}