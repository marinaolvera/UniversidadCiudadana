using MarinaOlvera.Models;
using MarinaOlvera.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MarinaOlvera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteRepository _repository;
        public EstudianteController()
        {
            _repository = new EstudianteRepository();
        }

        [HttpGet]
        public ActionResult<List<Estudiante>> Get()
        {
            return _repository.ObtenerEstudiantes();
        }

        [HttpPost("BuscarByEmail")]
        public ActionResult<Estudiante> BuscarByEmail(string email)
        {
            var estudiante = _repository.BuscarByEmail(email);
            if (estudiante == null)
            {
                return NotFound(new { message = "Estudiante no encontrado" });
            }
            return estudiante;
        }
        [HttpPost("Crear")]
        public ActionResult Crear(Estudiante request)
        {
            var existe = _repository.BuscarByEmail(request.Email);
            if (existe != null)
            {
                return BadRequest(new { message = "El Usuario ya existe." });
            }
            _repository.Crear(request);
            return Ok(new { message = "Registro creado." });
        }
    }
}
