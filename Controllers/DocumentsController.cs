using Microsoft.AspNetCore.Mvc;
using ProgrammeerOpdracht.Controllers.DTO_s;
using ProgrammeerOpdracht.Exceptions;
using ProgrammeerOpdracht.Models;
using ProgrammeerOpdracht.Services;

namespace ProgrammeerOpdracht.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _service;
        private readonly IDocumentContentFactory _factory;
        private readonly ILogger<DocumentsController> _logger;

        public DocumentsController(IDocumentService service, IDocumentContentFactory factory, ILogger<DocumentsController> logger)
        {
            _service = service;
            _factory = factory;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetDocuments(
            [FromQuery] Guid? patientId,
            [FromQuery] string? type,
            [FromQuery] string? receiver
            )
        {
            try
            {

            if (patientId != null)
            {

                var docs = _service.GetDocument(patientId!.Value, type, receiver);

                if (docs == null)
                {
                    return NotFound($"Can't find any documents for patient with id:{patientId}");
                }

                return Ok(docs);
            }

            return Ok(_service.GetAllDocuments());
            }
            catch (PatientNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpGet("{documentId}")]
        public IActionResult GetDocumentById(Guid documentId)
        {
            var doc = _service.GetDocumentById(documentId);

            if (doc == null)
            {
                return NotFound($"Can't find document with id:{documentId}");
            }

            return Ok(doc);
        }

        [HttpPost]
        public IActionResult UploadDocument([FromBody] CreateDocumentRequestDTO request)
        {
            try
            {
                var content = _factory.Create(request.Type, request.Content);

                var document = new Document
                {
                    PatientId = request.PatientId,
                    Sender = request.Sender,
                    Receiver = request.Receiver,
                    Type = request.Type,
                    Content = content
                };

                _service.AddDocument(document);

                _logger.LogInformation(
                "Document exchange: {Type} between {Sender} and {Receiver} for patiënt {PatientId}. Content: {ContentJson}",
                document.Type,
                document.Sender,
                document.Receiver,
                document.PatientId,
                System.Text.Json.JsonSerializer.Serialize(document.Content)
                );
                return CreatedAtAction(nameof(GetDocumentById), new { documentId = document.Id }, document);
            }
            catch (PatientNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception) when
            (exception is InvalidDocumentTypeException || exception is PatientIdRequiredException)
            {
                return BadRequest(exception.Message);
            }
        }


       
    }
}