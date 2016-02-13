using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Patients;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Patients;

namespace HippoBilling.Processor.Handlers.Patients
{
    public class SavePatientCommandHandler : CommandHandlerBase<SavePatientCommand>
    {
        public override void Handle(SavePatientCommand command)
        {
            var existed =
                Repository.Query<Patient>()
                    .Any(
                        x =>
                            x.PrimaryProvider.Practice.Id == command.PracticeId && x.Id != command.Id &&
                            x.Name.Equals(command.Name, StringComparison.CurrentCultureIgnoreCase) &&
                            x.DateOfBirth.Year == command.DateOfBirth.Year &&
                            x.DateOfBirth.Month == command.DateOfBirth.Month &&
                            x.DateOfBirth.Day == command.DateOfBirth.Day);
            if (existed)
                throw new ErrorException(
                    string.Format("The patient with the name '{0}' and the birth day '{1}' already exsited.",
                        command.Name, command.DateOfBirth.ToString("MM/dd/yyyy")));
            var patient = command.IsNew
                ? new Patient()
                {
                    Id = command.Id,
                    LastViewDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    LastVisitDate = DateTime.Now
                }
                : Repository.Get<Patient>(command.Id);
            if (patient == null) throw new ErrorException("The patient does not exist.");

            var provider = Repository.Get<Provider>(command.PrimaryProvider);
            if (provider == null || provider.Practice.Id != command.PracticeId)
                throw new ErrorException("The provider is invalid.");

            patient.PrimaryProvider = provider;
            patient.PatientBalance = command.PatientBalance;
            patient.InsuranceBalance = command.InsuranceBalance;
            patient.Name = command.Name;
            patient.DateOfBirth = command.DateOfBirth;
            patient.Sex = command.Sex;
            patient.SSN = command.SSN;
            patient.PrimaryPhone = command.PrimaryPhone;
            patient.SecondaryPhone = command.SecondaryPhone;
            patient.ReferringPhysicanNPI = command.ReferringPhysicanNPI;
            patient.ReferringPhysicanName = command.ReferringPhysicanName;
            patient.Status = command.Status;
            patient.StatementMethod = command.StatementMethod;
            patient.StatementHold = command.StatementHold;
            patient.Active = command.Active;

            var state =
                Repository.Query<State>()
                    .FirstOrDefault(x => x.Code.Equals(command.State, StringComparison.CurrentCultureIgnoreCase));
            if (state == null) throw new ErrorException("The State does not exist.");

            patient.Address = command.IsNew ? new Address() {Id = Guid.NewGuid()} : patient.Address;
            patient.Address.Address1 = command.Address1;
            patient.Address.Address2 = command.Address2;
            patient.Address.City = command.City;
            patient.Address.State = state;
            patient.Address.ZipCode = command.ZipCode;

            if (command.IsNew)
            {
                Repository.Create(patient);
            }
            else
            {
                Repository.Update(patient);
            }
        }
    }
}