using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Service.Practices.Impl
{
    public class SpecialityService : ServiceBase, ISpecialityService
    {
        public List<Domain.Practices.Speciality> GetAllSpecialities()
        {
            return Repository.Query<Speciality>().OrderBy(x => x.Name).ToList();
        }

        public Speciality GetSpeciality(string code)
        {
            return
                Repository.Query<Speciality>()
                    .FirstOrDefault(x => x.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));
        }

        public Speciality GetSpeciality(Guid id)
        {
            return Repository.Query<Speciality>().FirstOrDefault(x => x.Id == id);
        }
    }
}