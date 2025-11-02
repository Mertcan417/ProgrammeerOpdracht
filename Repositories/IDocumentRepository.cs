using ProgrammeerOpdracht.Models;

namespace ProgrammeerOpdracht.Repositories
{
    public interface IDocumentRepository
    {
        void Add(Document document);
        Document? GetById(Guid id);
        IEnumerable<Document> GetDocument(Guid patientId, string? type, string? receiver);
        IEnumerable<Document> GetAll();
    }
}
