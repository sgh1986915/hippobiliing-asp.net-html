using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Patients;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Patients;

namespace HippoBilling.Processor.Handlers.Patients
{
    public class SavePatientNoteCommandHandler : CommandHandlerBase<SavePatientNoteCommand>
    {
        public override void Handle(SavePatientNoteCommand command)
        {
            var patient = Repository.Get<Patient>(command.PatientId);
            if (patient == null) throw new ErrorException("The patient does not exist.");
            var user =
                Repository.Query<PracticeUser>()
                    .Where(
                        x => x.UserId == command.UserId && patient.PrimaryProvider.Practice.Id == x.PracticeId)
                    .Select(x => x.User)
                    .FirstOrDefault();
            if (user == null) throw new ErrorException("The operator does not exist.");
            var note = command.IsNew
                ? new PatientNote() {Id = command.Id, CreatedDate = DateTime.Now, CreatedBy = user}
                : Repository.Get<PatientNote>(command.Id);
            if (note == null) throw new ErrorException("The patient note does not exist.");

            note.Level = command.Level;
            note.Patient = patient;
            note.Detail = command.Detail;
            note.LastUpdatedBy = user;
            note.LastUpdatedDate = DateTime.Now;

            if (command.IsNew)
            {
                Repository.Create(note);
            }
            else
            {
                Repository.Update(note);
            }
        }
    }
}