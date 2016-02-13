using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Practices;
using HippoBilling.Service;
using HippoBilling.Service.Practices;

namespace HippoBilling.Service.Practices.Impl
{
    public class PracticeService : ServiceBase, IPracticeService
    {
        public List<Domain.Practices.Practice> GetAllPractices()
        {
            return Repository.Query<Practice>().ToList();
        }

        public Practice GetPractice(Guid id)
        {
            return Repository.Get<Practice>(id);
        }

        public Provider GetProvider(Guid id)
        {
            return Repository.Get<Provider>(id);
        }

        public List<Provider> GetAllProviders()
        {
            return
                Repository.Query<Provider>()
                    .ToList();
        }

        public List<Provider> GetProviders(Guid practiceId, string keyword)
        {
            return
                Repository.Query<Provider>()
                    .Where(
                        x =>
                            x.Practice.Id == practiceId &&
                            (string.IsNullOrEmpty(keyword) || x.FullName.Contains(keyword) ||
                             x.IndividualNPI.Contains(keyword) || x.Speciality.Name.Contains(keyword)))
                    .ToList();
        }

        public List<Location> GetLocations(Guid practiceId, string keyword)
        {
            return Repository.Query<Location>().Where(
                x => x.Practice.Id == practiceId &&
                     (string.IsNullOrEmpty(keyword) ||
                      x.InternalName.Contains(keyword) ||
                      x.InternalName.Contains(keyword) ||
                      x.NPI.Contains(keyword) ||
                      x.PlaceOfService.Name.Contains(keyword) ||
                      x.Address.Address1.Contains(keyword) ||
                      x.Address.City.Contains(keyword) ||
                      x.Address.State.Name.Contains(keyword))).ToList();
        }

        public List<Domain.Accounts.User> GetAvaiablePracticeUsers(Guid practiceId, Guid? userId)
        {
            if (practiceId == Guid.Empty) return new List<User>();
            var self = userId.HasValue ? userId.Value : Guid.Empty;
            var providers = Repository.Query<Provider>();
            var practiceUsers = Repository.Query<PracticeUser>();
            var users = (from pu in practiceUsers
                where pu.PracticeId == practiceId &&
                      (self == pu.UserId ||
                       !(from p in providers where p.Practice.Id == practiceId select p.User.Id).Contains(pu.UserId))
                select pu.User).ToList();
            return users;
        }

        public List<Practice> GetUserPractices(Guid userId, string keyword)
        {
            return Repository.Query<PracticeUser>().Where(x => x.UserId == userId &&
                                                               (
                                                                   string.IsNullOrEmpty(keyword) ||
                                                                   x.Practice.Name.Contains(keyword) ||
                                                                   x.Practice.MailingLocation.Address1.Contains(keyword) ||
                                                                   x.Practice.MailingLocation.Address2.Contains(keyword) ||
                                                                   x.Practice.MailingLocation.City.Contains(keyword) ||
                                                                   x.Practice.MailingLocation.State.Name.Contains(
                                                                       keyword) ||
                                                                   x.Practice.MailingLocation.ZipCode.Contains(keyword)
                                                                   )).Select(x => x.Practice).ToList();
        }


        public List<Practice> GetPracticeTabs(Guid userId)
        {
            return
                Repository.Query<PracticeUser>()
                    .Where(x => x.UserId == userId && x.ShowInTab && (x.Practice.Active || x.User.Role == Role.Admin))
                    .Select(x => x.Practice)
                    .ToList();
        }


        public int GetPracticeTabCount(Guid userId)
        {
            return Repository.Query<PracticeUser>().Count(x => x.UserId == userId && x.ShowInTab);
        }


        public List<Provider> GetAvailableProviders(Guid practiceId)
        {
            return Repository.Query<Provider>().Where(x => x.Practice.Id == practiceId && x.Active).ToList();
        }
    }
}