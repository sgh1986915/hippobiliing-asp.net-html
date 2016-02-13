using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Processor.Commands.Practices
{
    public class SaveProviderCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid PracticeId { get; set; }

        public string FullName { get; set; }

        public Guid UserId { get; set; }

        public string IndividualNPI { get; set; }

        public string LicenseNumber { get; set; }

        public Guid Speciality { get; set; }

        public string Degree { get; set; }

        public Gender Gender { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public bool SignatureonFile { get; set; }

        public bool Active { get; set; }

        public bool IsNew { get; set; }
    }
}