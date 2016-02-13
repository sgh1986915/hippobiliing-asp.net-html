using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Service.Practices.Impl
{
    public class ServicePlaceService:ServiceBase, IServicePlaceService
    {
        public Domain.Practices.ServicePlace GetServicePlace(string code)
        {
            return Repository.Query<ServicePlace>().FirstOrDefault(x => x.Code == code);
        }

        public List<Domain.Practices.ServicePlace> GetAllServicePlaces()
        {
            return Repository.Query<ServicePlace>().ToList();
        }
    }
}
