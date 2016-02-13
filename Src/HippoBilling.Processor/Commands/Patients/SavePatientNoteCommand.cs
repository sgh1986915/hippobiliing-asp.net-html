using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;
using HippoBilling.Domain.Patients;

namespace HippoBilling.Processor.Commands.Patients
{
    public class SavePatientNoteCommand : ICommand
    {
        public Guid PatientId { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Detail { get; set; }
        public NoteLevel Level { get; set; }
        public bool IsNew { get; set; }
    }
}