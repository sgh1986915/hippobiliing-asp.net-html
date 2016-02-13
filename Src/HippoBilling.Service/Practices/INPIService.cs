using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Patients;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Service.Practices
{
    public interface INPIService
    {
        NPIRecord Lookup(string npi);

        List<FavoritePhysician> Lookup(string keyword, string state, int start, int pageSize);
    }
}