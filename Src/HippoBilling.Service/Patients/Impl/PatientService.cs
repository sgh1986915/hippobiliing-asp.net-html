using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Patients;

namespace HippoBilling.Service.Patients.Impl
{
    public class PatientService : ServiceBase, IPatientService
    {
        public Patient GetPatient(Guid id)
        {
            return Repository.Get<Patient>(id);
        }

        public List<Domain.Patients.Patient> GetPatients(Guid practiceId, string keyword)
        {
            return
                Repository.Query<Patient>()
                    .Where(
                        x =>
                            x.PrimaryProvider.Practice.Id == practiceId &&
                            (string.IsNullOrEmpty(keyword) || x.Name.Contains(keyword))).ToList();
        }


        public List<Patient> GetRecentlyViewedPatients(Guid practiceId, int top = 5)
        {
            return
                Repository.Query<Patient>()
                    .Where(x => x.PrimaryProvider.Practice.Id == practiceId)
                    .OrderByDescending(x => x.LastViewDate)
                    .Take(top)
                    .ToList();
        }

        public List<Patient> GetRecentlyCreatedPatients(Guid practiceId, int top = 5)
        {
            return
                Repository.Query<Patient>()
                    .Where(x => x.PrimaryProvider.Practice.Id == practiceId)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(top)
                    .ToList();
        }


        public List<PatientNote> GetViewNotes(Guid patientId, string keyword, NoteLevel? level)
        {
            var notes =
                Repository.Query<PatientNote>()
                    .Where(x => x.Patient.Id == patientId && (string.IsNullOrEmpty(keyword) ||
                                                              x.CreatedBy.Name.Contains(keyword) ||
                                                              x.Detail.Contains(keyword)
                        ));
            if (level.HasValue)
            {
                notes = notes.Where(x => x.Level == level.Value);
            }
            return notes.ToList();
        }

        public PatientNote GetViewNote(Guid noteId)
        {
            return Repository.Get<PatientNote>(noteId);
        }


        public List<Patient> LookupPatients(Guid practiceId, string name, DateTime dateOfBirth)
        {
            return Repository.Query<Patient>()
                .Where(
                    x =>
                        x.PrimaryProvider.Practice.Id == practiceId && x.Name.Contains(name) &&
                        dateOfBirth.Year == x.DateOfBirth.Year && dateOfBirth.Month == x.DateOfBirth.Month &&
                        dateOfBirth.Day == x.DateOfBirth.Day)
                .ToList();
        }


        public List<FavoritePhysician> SearchFavoritedPhysician(Guid practiceId, string keyword, string state, int start,
            int pageSize)
        {
            return Repository.Query<FavoritePhysician>()
                .Where(
                    x =>
                        x.PracticeId == practiceId &&
                        x.Address.State.Code.Equals(state, StringComparison.CurrentCultureIgnoreCase) &&
                        (string.IsNullOrEmpty(keyword) ||
                         x.Name.Contains(keyword) ||
                         x.Address.Address1.Contains(keyword) ||
                         x.Address.Address2.Contains(keyword) ||
                         x.Address.City.Contains(keyword) ||
                         x.Address.State.Name.Contains(keyword)))
                .OrderBy(x => x.NPI)
                .Skip(start)
                .Take(pageSize)
                .ToList();
        }
    }
}