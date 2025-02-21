using MarinaOlvera.Models;

namespace MarinaOlvera.Repository.Interface
{
    public interface IEstudianteRepository
    {
        public void Crear(Estudiante estudiante);
        public List<Estudiante> ObtenerEstudiantes();
        public Estudiante BuscarByEmail(string email);
        //Funcion para guardar la informacion en un archivo .json
        public void GuardarEnJson();
    }
}
