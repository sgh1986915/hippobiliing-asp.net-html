using System;
using System.Collections.Generic;
using System.Linq;
using HippoBilling.Domain.Insurances;

namespace HippoBilling.Service.Insurances.Impl
{
    public class InsuranceService : ServiceBase, IInsuranceService
    {
        public List<Domain.Insurances.Insurance> GetInsurances(Guid patientId)
        {
            return Repository.Query<Insurance>().Where(x => x.Patient.Id == patientId).OrderBy(x => x.Order).ToList();
        }

        public Domain.Insurances.Insurance GetInsurance(Guid id)
        {
            return Repository.Get<Insurance>(id);
        }

        public List<PolicyType> GetPolicyTypes()
        {
            return Repository.Query<PolicyType>().ToList();
        }


        public List<IGrouping<PolicyType, Insurance>> GetInsuranceGroups(Guid patientId)
        {
            return
                Repository.Query<Insurance>().Where(x => x.Patient.Id == patientId).GroupBy(x => x.PolicyType).ToList();
        }
    }
}