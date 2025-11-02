using ProgrammeerOpdracht.Models;

namespace ProgrammeerOpdracht.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient? GetDetailsById(Guid patientId);
        bool ExistsById(Guid patientId);
    }
}