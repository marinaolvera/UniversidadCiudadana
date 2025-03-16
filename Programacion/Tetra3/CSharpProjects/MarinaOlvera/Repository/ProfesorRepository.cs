using MarinaOlvera.Models;
using MarinaOlvera.Repository.Interface;
using System.Text.Json;

namespace MarinaOlvera.Repository
{
    public class ProfesorRepository : IProfesoresRepository
    {
        private List<Profesor> profesores = new List<Profesor>();
        private const string _filePath = "profesores.json";

        public ProfesorRepository()
        {
            if (!File.Exists(_filePath))
            {
                var contenidoJson = JsonSerializer.Serialize(new List<Profesor>());
                File.WriteAllText(_filePath, contenidoJson);
            }
            profesores = ObtenerProfesores();
        }
        public Profesor BuscarByEmail(string email)
        {
            return profesores.FirstOrDefault(obj => obj.Email == email);
        }

        public void Crear(Profesor obj)
        {
            profesores.Add(obj);
            GuardarEnJson();
        }

        public void GuardarEnJson()
        {
            var json = JsonSerializer.Serialize(profesores);
            File.WriteAllText(_filePath, json);
        }

        public List<Profesor> ObtenerProfesores()
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Profesor>>(json);
        }
    }
}
