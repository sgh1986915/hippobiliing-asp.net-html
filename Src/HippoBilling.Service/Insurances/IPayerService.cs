using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Insurances;

namespace HippoBilling.Service.Insurances
{
    public interface IPayerService
    {
        List<Payer> SearchPayers(string keyword, int start, int pageSize);
        List<Payer> SearchFavoritePayers(Guid practiceId, string keyword, int start, int pageSize);
        Payer GetPayer(Guid id);
    }
}