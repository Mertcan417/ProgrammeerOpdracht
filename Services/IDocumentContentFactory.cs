using ProgrammeerOpdracht.Models;
using System.Text.Json;

namespace ProgrammeerOpdracht.Services
{
    public interface IDocumentContentFactory
    {
        DocumentContent Create(DocumentType type, JsonElement content);
    }
}
