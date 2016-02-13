using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Service.Practices
{
    public interface IPracticeService
    {
        List<Practice> GetAllPractices();

        Practice GetPractice(Guid id);

        Provider GetProvider(Guid id);

        List<Provider> GetAvailableProviders(Guid practiceId);
        
        List<Provider> GetProviders(Guid practiceId, string keyword);

        List<Location> GetLocations(Guid practiceId, string keyword);

        List<User> GetAvaiablePracticeUsers(Guid practiceId, Guid? userId);

        List<Practice> GetUserPractices(Guid userId, string keyword);

        List<Practice> GetPracticeTabs(Guid userId);

        int GetPracticeTabCount(Guid userId);
    }
}