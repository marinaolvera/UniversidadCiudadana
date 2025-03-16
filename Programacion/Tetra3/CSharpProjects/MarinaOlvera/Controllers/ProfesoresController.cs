using MarinaOlvera.Models;
using MarinaOlvera.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MarinaOlvera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesoresController : Controller
    {
        private readonly ProfesorRepository _repository;
        public ProfesoresController()
        {
            _repository = new ProfesorRepository();
        }
        [HttpGet]
        public ActionResult<List<Profesor>> Get()
        {
            return _repository.ObtenerProfesores();
        }

        [HttpPost("BuscarByEmail")]
        public ActionResult<Profesor> BuscarByEmail(string email)
        {
            var profesor = _repository.BuscarByEmail(email);
            if (profesor == null)
            {
                return NotFound(new { message = "Profesor no encontrado" });
            }
            return profesor;
        }
        [HttpPost("Crear")]
        public ActionResult Crear(Profesor request)
        {
            var existe = _repository.BuscarByEmail(request.Email);
            if (existe != null)
            {
                return BadRequest(new { message = "El Profesor ya existe." });
            }
            _repository.Crear(request);
            return Ok(new { message = "Registro creado." });
        }
    }
}
