using MarinaOlvera.Models;
using MarinaOlvera.Repository.Interface;
using System.Text.Json;

namespace MarinaOlvera.Repository
{
    public class EstudianteRepository : IEstudiantesRepository
    {
        /***************
         * Generamos una Lista de Objetos Estudiantes para cargar el archivo JSON
         **************/
        private List<Estudiante> estudiantes = new List<Estudiante>();
        /***************
         * Generamos una variable que tendra la ubicacion y nombre del archivo JSON
         **************/
        private const string _filePath = "estudiantes.json";

        /********************************************************
        ***Constructor, se ejecuta cada vez que se inicializa****
        *********************************************************/
        public EstudianteRepository()
        {
            //Verificamos que exista, en caso de que no , creamos el archivo JSON
            if (!File.Exists(_filePath))
            {
                var contenidoJson = JsonSerializer.Serialize(new List<Estudiante>());
                // Crear un archivo vacío con una lista vacía de estudiantes
                File.WriteAllText(_filePath, contenidoJson);
            }
            //Despues de validar el archivo, cargamos la lista de estudiantes en la variable    
            estudiantes = ObtenerEstudiantes();
        }
        /********************************************************
         ***************Logica del codigo************************
         ********************************************************/
        public void Crear(Estudiante obj)
        {
            estudiantes.Add(obj);
            GuardarEnJson();
        }
        public Estudiante BuscarByEmail(string email)
        {
            return estudiantes.FirstOrDefault(obj => obj.Email == email);
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Estudiante>>(json);
        }

        //Guardamos cambios en el archivo
        public void GuardarEnJson()
        {
            var json = JsonSerializer.Serialize(estudiantes);
            File.WriteAllText(_filePath, json);
        }
    }
}
