using ProgrammeerOpdracht.Exceptions;
using ProgrammeerOpdracht.Models;
using ProgrammeerOpdracht.Repositories;

namespace ProgrammeerOpdracht.Services
{
    public class DocumentService: IDocumentService
    {
        private readonly IDocumentRepository _repository;
        private readonly IPatientService _patientService;
        public DocumentService(IDocumentRepository repository, IPatientService patientService)
        {
            _repository = repository;
            _patientService = patientService;
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            return _repository.GetAll();
        }

        public void AddDocument(Document doc)
        {
            if (doc.PatientId.ToString() == "")
            {
                throw new PatientIdRequiredException("Patient Id is required!");
            }
            if (!_patientService.ExistsById(doc.PatientId))
            {
                throw new PatientNotFoundException($"Couldn't find patient with Id: {doc.PatientId}");
            }

            if (string.IsNullOrWhiteSpace(doc.Type.ToString()))
            {
                throw new InvalidDocumentTypeException($"Invalid document type!");

            }
            _repository.Add(doc);
        }

        public IEnumerable<Document> GetDocument(Guid patientId, string? type, string? receiver)
            => _repository.GetDocument(patientId, type, receiver);

        public Document? GetDocumentById(Guid id)
            => _repository.GetById(id);
    }
}
