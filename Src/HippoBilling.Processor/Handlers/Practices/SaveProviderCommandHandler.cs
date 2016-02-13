using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Practices;

namespace HippoBilling.Processor.Handlers.Practices
{
    public class SaveProviderCommandHandler : CommandHandlerBase<SaveProviderCommand>
    {
        public override void Handle(SaveProviderCommand command)
        {
            var practice = Repository.Get<Practice>(command.PracticeId);
            if (practice == null) throw new ErrorException("The practice does not exist.");

            var user = command.UserId == Guid.Empty ? null : Repository.Get<User>(command.UserId);
            var provider = command.IsNew ? new Provider() {Id = command.Id} : Repository.Get<Provider>(command.Id);
            if (provider == null) throw new ErrorException("The provider does not exist.");

            provider.User = user;
            provider.Practice = practice;
            provider.FullName = command.FullName;
            provider.IndividualNPI = command.IndividualNPI;
            provider.LicenseNumber = command.LicenseNumber;
            provider.Degree = command.Degree;
            provider.Active = command.Active;
            provider.SignatureOnFile = command.SignatureonFile;
            provider.Gender = command.Gender;
            provider.Phone = command.Phone;

            var speciality = Repository.Query<Speciality>()
                .FirstOrDefault(x => x.Id == command.Speciality);
            if (speciality == null) throw new ErrorException("The Speciality does not exist.");

            provider.Speciality = speciality;

            var state = Repository.Query<State>()
                .FirstOrDefault(x => x.Code.Equals(command.State, StringComparison.CurrentCultureIgnoreCase));
            if (state == null) throw new ErrorException("The State does not exist.");

            provider.Address = command.IsNew ? new Address() {Id = Guid.NewGuid()} : provider.Address;
            provider.Address.Address1 = command.Address1;
            provider.Address.Address2 = command.Address2;
            provider.Address.City = command.City;
            provider.Address.State = state;
            provider.Address.ZipCode = command.ZipCode;

            if (command.IsNew)
            {
                Repository.Create(provider);
            }
            else
            {
                Repository.Update(provider);
            }
        }
    }
}