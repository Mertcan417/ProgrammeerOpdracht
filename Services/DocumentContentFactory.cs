using ProgrammeerOpdracht.Models;
using System.Text.Json;

namespace ProgrammeerOpdracht.Services
{
    public class DocumentContentFactory : IDocumentContentFactory
    {
        public DocumentContent Create(DocumentType type, JsonElement content)
        {
            return type switch
            {
                DocumentType.ReferralLetter => content.Deserialize<ReferralLetterContent>()!,
                DocumentType.AllergyOverview => content.Deserialize<AllergyContent>()!,
                DocumentType.MedicationOverview => content.Deserialize<MedicationContent>()!,
                _ => throw new ArgumentException("Unknown document type")
            };
        }
    }

}
