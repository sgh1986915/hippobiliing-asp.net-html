using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Practices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Handlers.Practices
{
    public class SavePracticeCommandHandler : CommandHandlerBase<SavePracticeCommand>
    {
        public override void Handle(SavePracticeCommand command)
        {
            var user = Repository.Get<User>(command.UserId);
            if (user == null) throw new ErrorException("The user account does not exist.");

            var practice = command.IsNew ? new Practice() {Id = command.Id} : Repository.Get<Practice>(command.Id);

            if (practice == null) throw new ErrorException("The practice does not exist.");

            practice.Name = command.Name;
            practice.TaxId = command.TaxId;

            practice.NPI = command.NPI;
            practice.Speciality =
                Repository.Query<Speciality>()
                    .FirstOrDefault(x => x.Id == command.Speciality);

            if (practice.Speciality == null) throw new ErrorException("The speciality does not exist.");
            practice.PhoneNo = command.PhoneNo;
            practice.FaxNo = command.FaxNo;
            practice.Active = command.Active;

            practice.MailingLocation = practice.MailingLocation ?? new Address() {Id = Guid.NewGuid()};

            practice.MailingLocation.Address1 = command.MailingAddress1;
            practice.MailingLocation.Address2 = command.MailingAddress2;
            practice.MailingLocation.City = command.MailingCity;
            practice.MailingLocation.ZipCode = command.MailingZipCode;
            practice.MailingLocation.State =
                Repository.Query<State>()
                    .FirstOrDefault(x => x.Code.Equals(command.MailingState, StringComparison.CurrentCultureIgnoreCase));

            if (practice.MailingLocation.State == null) throw new ErrorException("The state does not exist.");

            //remove unused address
            var pendingIds = new List<Guid>();

            //billing location
            if (command.BillingAddrSameAsMailingAddr)
            {
                if (practice.BillingLocation != null && practice.BillingLocation.Id != practice.MailingLocation.Id)
                {
                    pendingIds.Add(practice.BillingLocation.Id);
                }
                practice.BillingLocation = practice.MailingLocation;
            }
            else
            {
                practice.BillingLocation = practice.BillingLocation ?? new Address() {Id = Guid.NewGuid()};
                practice.BillingLocation.Address1 = command.BillingAddress1;
                practice.BillingLocation.Address2 = command.BillingAddress2;
                practice.BillingLocation.City = command.BillingCity;
                practice.BillingLocation.ZipCode = command.BillingZipCode;
                practice.BillingLocation.State = Repository.Query<State>()
                    .FirstOrDefault(x => x.Code.Equals(command.BillingState, StringComparison.CurrentCultureIgnoreCase));

                if (practice.BillingLocation.State == null) throw new ErrorException("The state does not exist.");
            }

            //pay to location
            if (command.PaymentAddrSameAsMailingAddr)
            {
                if (practice.PayToLocation != null && practice.PayToLocation.Id != practice.MailingLocation.Id)
                {
                    pendingIds.Add(practice.PayToLocation.Id);
                }
                practice.PayToLocation = practice.MailingLocation;
            }
            else
            {
                practice.PayToLocation = practice.PayToLocation ?? new Address() {Id = Guid.NewGuid()};
                practice.PayToLocation.Address1 = command.PaymentAddress1;
                practice.PayToLocation.Address2 = command.PaymentAddress2;
                practice.PayToLocation.City = command.PaymentCity;
                practice.PayToLocation.ZipCode = command.PaymentZipCode;
                practice.PayToLocation.State = Repository.Query<State>()
                    .FirstOrDefault(x => x.Code.Equals(command.PaymentState, StringComparison.CurrentCultureIgnoreCase));
                if (practice.PayToLocation.State == null) throw new ErrorException("The state does not exist.");
            }

            if (command.IsNew)
            {
                var practiceUser = new PracticeUser() {User = user, Practice = practice, ShowInTab = true};

                Repository.Create(practiceUser);
            }
            else
            {
                Repository.Update(practice);
            }

            //remove unused address
            var pendingAddresses = Repository.Query<Address>().Where(x => pendingIds.Contains(x.Id));
            Repository.DeleteRange(pendingAddresses);
        }
    }
}