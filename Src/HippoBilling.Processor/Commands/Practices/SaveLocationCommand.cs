using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;

namespace HippoBilling.Processor.Commands.Practices
{
    public class SaveLocationCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid PracticeId { get; set; }

        public string InternalName { get; set; }

        public string InternalCode { get; set; }

        public string NPI { get; set; }

        public string PlaceOfService { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public string FDA { get; set; }

        public string CLIA { get; set; }

        public bool Active { get; set; }

        public bool IsNew { get; set; }
    }
}