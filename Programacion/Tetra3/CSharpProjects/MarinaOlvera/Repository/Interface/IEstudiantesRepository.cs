using MarinaOlvera.Models;

namespace MarinaOlvera.Repository.Interface
{
    public interface IEstudiantesRepository:IUsuarioBaseRepository<Estudiante>
    {
        public List<Estudiante> ObtenerEstudiantes();
    }
}
