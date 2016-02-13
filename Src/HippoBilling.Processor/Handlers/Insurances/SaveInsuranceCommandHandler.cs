using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Insurances;
using HippoBilling.Domain.Patients;
using HippoBilling.Processor.Commands.Insurances;

namespace HippoBilling.Processor.Handlers.Insurances
{
    public class SaveInsuranceCommandHandler : CommandHandlerBase<SaveInsuranceCommand>
    {
        public override void Handle(SaveInsuranceCommand command)
        {
            var user = Repository.Get<User>(command.UserId);
            if (user == null) throw new ErrorException("The user does not exist.");

            var payer = Repository.Get<Payer>(command.PayerId);
            if (payer == null) throw new ErrorException("The payer does not exist.");

            var policyType = Repository.Get<PolicyType>(command.PolicyType);
            if (policyType == null) throw new ErrorException("The policy type does not exist.");

            var patient = Repository.Get<Patient>(command.PatientId);

            if (patient == null) throw new ErrorException("The patient does not exist.");

            var insurance = command.IsNew
                ? new Insurance() {Id = command.Id, CreatedBy = user, CreatedDate = DateTime.Now}
                : Repository.Get<Insurance>(command.Id);
            if (insurance == null) throw new ErrorException("The insurance does not exist.");


            var originalPolicyId = insurance.PolicyType == null ? Guid.Empty : insurance.PolicyType.Id;
            var policyChanged = originalPolicyId != Guid.Empty && originalPolicyId != command.PolicyType;

            insurance.Payer = payer;
            insurance.Patient = patient;
            insurance.PolicyType = policyType;
            insurance.MemberNumber = command.MemberNumber;
            insurance.GroupName = command.GroupName;
            insurance.GroupNumber = command.GroupName;
            insurance.EffectiveFrom = command.EffectiveFrom;
            insurance.EffectiveTo = command.EffectiveTo;
            insurance.Relationship = command.Relationship;
            insurance.LastUpdatedBy = user;
            insurance.LastUpdatedDate = DateTime.Now;

            if (command.IsNew || policyChanged)
            {
                var maxOrder = Repository.Query<Insurance>()
                    .Where(x => x.Patient.Id == command.PatientId && x.PolicyType.Id == command.PolicyType)
                    .Select(x => (int?) x.Order)
                    .Max();

                insurance.Order = (maxOrder.HasValue
                    ? maxOrder.Value
                    : 0) + 1;
            }

            if (command.IsNew)
            {
                Repository.Create(insurance);
            }
            else
            {
                Repository.Update(insurance);
                if (policyChanged)
                {
                    var pendingReorderInsurances =
                        Repository.Query<Insurance>()
                            .Where(x => x.Patient.Id == command.PatientId && x.PolicyType.Id == originalPolicyId)
                            .OrderBy(x => x.Order).ToList();
                    for (int i = 0; i < pendingReorderInsurances.Count; i++)
                    {
                        pendingReorderInsurances[i].Order = i + 1;
                    }
                    Repository.UpdateRange(pendingReorderInsurances);
                }
            }
        }
    }
}