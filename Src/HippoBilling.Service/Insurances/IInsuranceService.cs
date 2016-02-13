using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Insurances;

namespace HippoBilling.Service.Insurances
{
    public interface IInsuranceService
    {
        List<PolicyType> GetPolicyTypes();
        List<Insurance> GetInsurances(Guid patientId);
        List<IGrouping<PolicyType, Insurance>> GetInsuranceGroups(Guid patientId);
        Insurance GetInsurance(Guid id);
    }
}