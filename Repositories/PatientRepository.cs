using ProgrammeerOpdracht.Models;

namespace ProgrammeerOpdracht.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        List<Patient> patients = new List<Patient>
            {
                new Patient { Id = Guid.NewGuid(), Name = "Jan de Vries", Age = 72 },
                new Patient { Id = Guid.NewGuid(), Name = "Maria van Dijk", Age = 81 },
                new Patient { Id = Guid.NewGuid(), Name = "Ahmed El Amrani", Age = 65 },
                new Patient { Id = Guid.NewGuid(), Name = "Lisa Jansen", Age = 54 },
                new Patient { Id = Guid.NewGuid(), Name = "Tom Bakker", Age = 89 },
                new Patient { Id = Guid.NewGuid(), Name = "Sanne Willems", Age = 43 },
                new Patient { Id = Guid.NewGuid(), Name = "Pieter Verhoeven", Age = 77 },
                new Patient { Id = Guid.NewGuid(), Name = "Nora Smits", Age = 69 },
                new Patient { Id = Guid.NewGuid(), Name = "Koen Meijer", Age = 58 },
                new Patient { Id = Guid.NewGuid(), Name = "Fatima Bouali", Age = 62 }
            };

        public IEnumerable<Patient> GetAll() => patients;

        public Patient? GetDetailsById(Guid patientId)
        {
            return patients.FirstOrDefault(p => p.Id == patientId);
        }

        public bool ExistsById(Guid patientId)
        {
            return patients.Exists(p => p.Id == patientId);
        }
    }
}
