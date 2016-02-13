using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HippoBilling.Processor.Commands.Authorizations;
using HippoBilling.Domain.Authorizations;
using HippoBilling.Domain.Practices;
using HippoBilling.Domain.Patients;

namespace HippoBilling.Processor.Handlers.Authorizations
{
    public class SaveAuthorizationCommandHandler : CommandHandlerBase<SaveAuthorizationCommand>
    {
        public override void Handle(SaveAuthorizationCommand command)
        {
            var authorization = command.IsNew
                ? new Authorization()
                {
                    Id = command.Id,
                    CreatedDate = DateTime.Now,
                }
                : Repository.Get<Authorization>(command.Id);

            var provider = Repository.Get<Provider>(command.ProviderId);
            var location = Repository.Get<Location>(command.LocationId);
            var patient = Repository.Get<Patient>(command.PatientId);

            authorization.Provider = provider;
            authorization.Location = location;
            authorization.Patient = patient;
            authorization.DateOfBirth = command.DateOfBirth;
            authorization.CPT = command.CPT;
            authorization.DX = command.DX;

            if (command.IsNew)
            {
                Repository.Create(authorization);
            }
            else
            {
                Repository.Update(authorization);
            }
        }
    }
}
