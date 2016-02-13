using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Patients;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Patients;

namespace HippoBilling.Processor.Handlers.Patients
{
    public class FavoritePhysicianCommandHandler : CommandHandlerBase<FavoritePhysicianCommand>
    {
        public override void Handle(FavoritePhysicianCommand command)
        {
            var physician =
                Repository.Query<FavoritePhysician>()
                    .FirstOrDefault(x => x.NPI == command.NPI && x.PracticeId == command.PracticeId);
            if (physician != null) return;
            var practice = Repository.Get<Practice>(command.PracticeId);
            if (practice == null) throw new ErrorException("The practice does not exist.");
            var state = Repository.Query<State>().FirstOrDefault(x => x.Code == command.State);
            if (state == null) throw new ErrorException("The state does not exist.");
            physician = new FavoritePhysician()
            {
                NPI = command.NPI,
                Practice = practice,
                Name = command.Name,
                Organization = command.Organization,
                Address =
                    new Address()
                    {
                        Id = Guid.NewGuid(),
                        Address1 = command.Address1,
                        Address2 = command.Address1,
                        City = command.City,
                        State = state,
                        ZipCode = command.ZipCode
                    },
                Phone = command.Phone,
                Fax = command.Fax
            };
            Repository.Create(physician);
        }
    }
}