using ProgrammeerOpdracht.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ProgrammeerOpdracht.Controllers.DTO_s
{
    public class CreateDocumentRequestDTO
    {
        [Required(ErrorMessage = "PatientId is required.")]
        public Guid PatientId { get; set; }

        [Required(ErrorMessage = "Sender is required.")]
        public string? Sender { get; set; }

        [Required(ErrorMessage = "Receiver is required.")]
        public string? Receiver { get; set; }

        [Required(ErrorMessage = "Documenttype is required.")]
        [EnumDataType(typeof(DocumentType))]
        public DocumentType Type { get; set; }

        [Required(ErrorMessage = "Content may not be empty.")]
        public JsonElement Content { get; set; }
    }
}