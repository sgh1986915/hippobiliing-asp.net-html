using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;

namespace HippoBilling.Processor.Commands.Authorizations
{
    public class SaveAuthorizationCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid ProviderId { get; set; }
        public Guid LocationId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Insurance1 { get; set; }
        public string Insurance2 { get; set; }
        public string DX { get; set; }
        public string CPT { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid PracticeId { get; set; }
        public bool IsNew { get; set; }
    }
}
