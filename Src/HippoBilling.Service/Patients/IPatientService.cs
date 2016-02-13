using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Patients;

namespace HippoBilling.Service.Patients
{
    public interface IPatientService
    {
        Patient GetPatient(Guid id);

        List<Patient> GetPatients(Guid practiceId, string keyword);

        List<Patient> GetRecentlyViewedPatients(Guid practiceId, int top = 5);

        List<Patient> GetRecentlyCreatedPatients(Guid practiceId, int top = 5);

        List<PatientNote> GetViewNotes(Guid patientId, string keyword, NoteLevel? level);

        PatientNote GetViewNote(Guid noteId);

        List<Patient> LookupPatients(Guid practiceId, string name, DateTime dateOfBirth);

        List<FavoritePhysician> SearchFavoritedPhysician(Guid practiceId, string keyword, string state, int start,
            int pageSize);
    }
}