using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Patients;
using HippoBilling.Processor.Commands.Patients;

namespace HippoBilling.Processor.Handlers.Patients
{
    public class ViewPatientCommandHandler : CommandHandlerBase<ViewPatientCommand>
    {
        public override void Handle(ViewPatientCommand command)
        {
            var patient = Repository.Get<Patient>(command.Id);
            if (patient == null) throw new ErrorException("The patient does not exist.");
            patient.LastViewDate = DateTime.Now;
            Repository.Update(patient);
        }
    }
}