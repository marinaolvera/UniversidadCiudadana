using MarinaOlvera.Models;

namespace MarinaOlvera.Repository.Interface
{
    public interface IProfesoresRepository:IUsuarioBaseRepository<Profesor>
    {
        public List<Profesor> ObtenerProfesores();
    }
}
