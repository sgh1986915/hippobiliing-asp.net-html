using System;
using System.Linq;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Insurances;
using HippoBilling.Processor.Commands.Insurances;

namespace HippoBilling.Processor.Handlers.Insurances
{
    public class SavePayerCommandHandler : CommandHandlerBase<SavePayerCommand>
    {
        public override void Handle(SavePayerCommand command)
        {
            var user = Repository.Get<User>(command.UserId);
            if (user == null) throw new ErrorException("The user does not exist.");
            var payer = command.IsNew
                ? new Payer() {Id = command.Id, CreatedBy = user, CreatedDate = DateTime.Now}
                : Repository.Get<Payer>(command.Id);
            if (payer == null) throw new ErrorException("The payer does not exist.");


            payer.Name = command.Name;
            payer.Phone = command.Phone;
            payer.Fax = command.Fax;
            payer.PayerId = command.PayerId;

            var state =
                Repository.Query<State>()
                    .FirstOrDefault(x => x.Code.Equals(command.State, StringComparison.CurrentCultureIgnoreCase));
            if (state == null) throw new ErrorException("The State does not exist.");

            payer.Address = command.IsNew ? new Address() {Id = Guid.NewGuid()} : payer.Address;
            payer.Address.Address1 = command.Address1;
            payer.Address.Address2 = command.Address2;
            payer.Address.City = command.City;
            payer.Address.State = state;
            payer.Address.ZipCode = command.ZipCode;

            if (command.IsNew)
            {
                Repository.Create(payer);
            }
            else
            {
                Repository.Update(payer);
            }
        }
    }
}