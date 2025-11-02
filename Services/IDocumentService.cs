using ProgrammeerOpdracht.Models;

namespace ProgrammeerOpdracht.Services
{
    public interface IDocumentService
    {
        void AddDocument(Document doc);
        IEnumerable<Document> GetDocument(Guid patientId, string? type, string? receiver);
        IEnumerable<Document> GetAllDocuments();
        Document? GetDocumentById(Guid id);
    }
}
