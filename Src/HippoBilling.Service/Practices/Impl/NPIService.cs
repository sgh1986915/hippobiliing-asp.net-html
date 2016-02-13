using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Data;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Patients;
using HippoBilling.Domain.Practices;
using Microsoft.Practices.ServiceLocation;

namespace HippoBilling.Service.Practices.Impl
{
    public class NPIService : ServiceBase, INPIService
    {
        private IRepository _npiRepository;

        public NPIService()
        {
            _npiRepository = ServiceLocator.Current.GetInstance<IRepository>("NPIRecordRepository");
        }

        public NPIRecord Lookup(string npi)
        {
            return _npiRepository.Query<NPIRecord>().FirstOrDefault(x => x.NPI == npi);
        }


        public List<FavoritePhysician> Lookup(string keyword, string state, int start, int pageSize)
        {
            var query =
                _npiRepository.Query<NPIRecord>().Where(x => x.Provider_Business_Mailing_Address_State_Name == state);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Provider_First_Name.Contains(keyword) ||
                                         x.Provider_Middle_Name.Contains(keyword) ||
                                         x.Provider_Last_Name__Legal_Name_.Contains(keyword) ||
                                         x.Provider_First_Line_Business_Mailing_Address.Contains(keyword) ||
                                         x.Provider_Second_Line_Business_Mailing_Address.Contains(keyword) ||
                                         x.Provider_Business_Mailing_Address_City_Name.Contains(keyword)
                    );
            }
            var records = query.Take(pageSize).ToList();
            var stateCodes = records.Select(x => x.Provider_Business_Mailing_Address_State_Name).Distinct().ToList();
            var specialityCodes = records.Select(x => x.GetSpecialityCode()).Distinct().ToList();

            var states = Repository.Query<State>().Where(x => stateCodes.Contains(x.Code)).ToList();
            var specialities =
                Repository.Query<Speciality>()
                    .Where(x => specialityCodes.Contains(x.Code))
                    .GroupBy(x => x.Code)
                    .Select(g => g.FirstOrDefault());

            var physicians = records.ConvertAll(r => new FavoritePhysician()
            {
                NPI = r.NPI,
                Name =
                    r.IsOrganization()
                        ? r.Provider_Organization_Name__Legal_Business_Name_
                        : string.Format("{0} {1}",
                            r.Provider_First_Name,
                            string.IsNullOrEmpty(r.Provider_Middle_Name)
                                ? r.Provider_Last_Name__Legal_Name_
                                : string.Format("{0} {1}", r.Provider_Middle_Name, r.Provider_Last_Name__Legal_Name_)),
                Speciality = new Speciality() {Code = r.GetSpecialityCode()},
                Address = new Address()
                {
                    Address1 = r.Provider_First_Line_Business_Mailing_Address,
                    Address2 = r.Provider_Second_Line_Business_Mailing_Address,
                    City = r.Provider_Business_Mailing_Address_City_Name,
                    State = states.FirstOrDefault(x => x.Code == r.Provider_Business_Mailing_Address_State_Name),
                    ZipCode = r.Provider_Business_Mailing_Address_Postal_Code
                },
                Organization = r.IsOrganization(),
                Phone = r.Provider_Business_Mailing_Address_Telephone_Number,
                Fax = r.Provider_Business_Mailing_Address_Fax_Number
            });
            physicians.ForEach(x =>
            {
                if (specialities.Any(s => s.Code.Equals(x.Speciality.Code, StringComparison.CurrentCultureIgnoreCase)))
                {
                    x.Speciality.Id =
                        specialities.First(
                            s => s.Code.Equals(x.Speciality.Code, StringComparison.CurrentCultureIgnoreCase)).Id;
                }
            });
            return physicians;
        }
    }
}