using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Practices;

namespace HippoBilling.Processor.Handlers.Practices
{
    public class SaveLocationCommandHandler : CommandHandlerBase<SaveLocationCommand>
    {
        public override void Handle(SaveLocationCommand command)
        {
            var practice = Repository.Get<Practice>(command.PracticeId);
            if (practice == null) throw new ErrorException("The practice does not exist.");

            var location = command.IsNew ? new Location() {Id = command.Id} : Repository.Get<Location>(command.Id);
            if (location == null) throw new ErrorException("The location does not exist.");

            location.Practice = practice;
            location.InternalName = command.InternalName;
            location.InternalCode = command.InternalCode;
            location.NPI = command.NPI;
            location.Active = command.Active;
            location.Phone = command.Phone;
            location.FDA = command.FDA;
            location.CLIA = command.CLIA;

            var servicePlace = Repository.Query<ServicePlace>().FirstOrDefault(x => x.Code == command.PlaceOfService);
            if (servicePlace == null) throw new ErrorException("The Service Place does not exist.");

            location.PlaceOfService = servicePlace;

            var state =
                Repository.Query<State>()
                    .FirstOrDefault(x => x.Code.Equals(command.State, StringComparison.CurrentCultureIgnoreCase));
            if (state == null) throw new ErrorException("The State does not exist.");

            location.Address = command.IsNew ? new Address() {Id = Guid.NewGuid()} : location.Address;
            location.Address.Address1 = command.Address1;
            location.Address.Address2 = command.Address2;
            location.Address.City = command.City;
            location.Address.State = state;
            location.Address.ZipCode = command.ZipCode;

            if (command.IsNew)
            {
                Repository.Create(location);
            }
            else
            {
                Repository.Update(location);
            }
        }
    }
}