using ProgrammeerOpdracht.Models;

namespace ProgrammeerOpdracht.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
        Patient? GetDetailsById(Guid patientId);
        bool ExistsById(Guid id);
    }
}
