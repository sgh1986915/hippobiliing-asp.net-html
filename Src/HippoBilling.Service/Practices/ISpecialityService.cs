using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Service.Practices
{
    public interface ISpecialityService
    {
        List<Speciality> GetAllSpecialities();

        Speciality GetSpeciality(string code);

        Speciality GetSpeciality(Guid id);
    }
}