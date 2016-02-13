using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;

namespace HippoBilling.Processor.Commands.Patients
{
    public class FavoritePhysicianCommand : ICommand
    {
        public string NPI { get; set; }
        public Guid PracticeId { get; set; }
        public string Name { get; set; }
        public bool Organization { get; set; }
        public Guid Speciality { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}