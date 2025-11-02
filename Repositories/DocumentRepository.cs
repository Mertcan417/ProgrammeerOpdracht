using ProgrammeerOpdracht.Models;

namespace ProgrammeerOpdracht.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly List<Document> _documents = new();

        public void Add(Document document)
        {
            _documents.Add(document);
        }

        public IEnumerable<Document> GetAll()
        {
            return _documents;
        }

        public Document? GetById(Guid id)
        {
            return _documents.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Document> GetDocument(Guid patientId, string? type, string? receiver)
        {
            return _documents
                .Where(d => d.PatientId == patientId)
                .Where(d => string.IsNullOrEmpty(type) ||
                         d.Type.ToString().Equals(type, StringComparison.OrdinalIgnoreCase))
                .Where(d => string.IsNullOrEmpty(receiver) ||
                         (d.Receiver != null &&
                          d.Receiver.ToString().Equals(receiver, StringComparison.OrdinalIgnoreCase)))
                .AsEnumerable();
        }
    }
}
