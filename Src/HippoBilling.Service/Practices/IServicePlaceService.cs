using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Service.Practices
{
    public interface IServicePlaceService
    {
        ServicePlace GetServicePlace(string code);

        List<ServicePlace> GetAllServicePlaces();
    }
}
