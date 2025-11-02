namespace ProgrammeerOpdracht.Models
{
    public class Document
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PatientId { get; set; }
        public string? Sender { get; set; } 
        public string? Receiver { get; set; }
        public DocumentType Type { get; set; }
        public DocumentContent? Content { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }

}
