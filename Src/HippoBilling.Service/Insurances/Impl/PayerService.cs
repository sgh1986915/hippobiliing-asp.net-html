using System;
using System.Collections.Generic;
using System.Linq;
using HippoBilling.Domain.Insurances;

namespace HippoBilling.Service.Insurances.Impl
{
    public class PayerService : ServiceBase, IPayerService
    {
        public List<Domain.Insurances.Payer> SearchPayers(string keyword, int start, int pageSize)
        {
            return Repository.Query<Payer>()
                .Where(
                    x =>
                        string.IsNullOrEmpty(keyword) || x.Name.Contains(keyword) ||
                        x.Address.Address1.Contains(keyword) || x.Address.Address2.Contains(keyword) ||
                        x.Address.City.Contains(keyword))
                .OrderBy(x => x.CreatedDate)
                .Skip(start)
                .Take(pageSize)
                .ToList();
        }

        public List<Domain.Insurances.Payer> SearchFavoritePayers(Guid practiceId, string keyword, int start,
            int pageSize)
        {
            return Repository.Query<FavoritePayer>()
                .Where(
                    x =>
                        x.PracticeId == practiceId &&
                        (string.IsNullOrEmpty(keyword) || x.Payer.Name.Contains(keyword) ||
                         x.Payer.Address.Address1.Contains(keyword) || x.Payer.Address.Address2.Contains(keyword) ||
                         x.Payer.Address.City.Contains(keyword)))
                .Select(x => x.Payer)
                .OrderBy(x => x.CreatedDate)
                .Skip(start)
                .Take(pageSize)
                .ToList();
        }


        public Payer GetPayer(Guid id)
        {
            return Repository.Get<Payer>(id);
        }
    }
}