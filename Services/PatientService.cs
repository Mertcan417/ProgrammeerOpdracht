using ProgrammeerOpdracht.Models;
using ProgrammeerOpdracht.Repositories;

namespace ProgrammeerOpdracht.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        
        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _repository.GetAll();
        }

        public Patient? GetDetailsById(Guid patientId)
        {
            return _repository.GetDetailsById(patientId);
        }

        public bool ExistsById(Guid patientId)
        {
            return _repository.ExistsById(patientId);
        }
    }
}
