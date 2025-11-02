using Microsoft.AspNetCore.Mvc;
using ProgrammeerOpdracht.Models;
using ProgrammeerOpdracht.Services;

namespace ProgrammeerOpdracht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _service.GetAll();
        }
    }
}
