
using MarinaOlvera.Controllers;
using MarinaOlvera.Models;
using MarinaOlvera.Repository;

namespace MarinaOlvera
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        /*
        public static void EjecutarPruebas() 
        {
            var repository = new EstudianteController();

            // Crear estudiantes
            var estudiante1 = new InputEstudiante() 
            {
                es
            };
            var estudiante2 = new InputEstudiante("Ana", "García", "ana.garcia@example.com");

            // Agregar estudiantes
            repository.Add(estudiante1);
            repository.Add(estudiante2);

            // Obtener todos los estudiantes
            var estudiantes = repository.GetAll();
            Console.WriteLine("Lista de estudiantes:");
            foreach (var est in estudiantes)
            {
                Console.WriteLine(est);
            }

            // Actualizar un estudiante
            estudiante1.Nombre = "Juan Carlos";
            repository.Update(estudiante1);

            // Obtener estudiante por ID
            var estudianteActualizado = repository.GetById(estudiante1.Id);
            Console.WriteLine("Estudiante actualizado:");
            Console.WriteLine(estudianteActualizado);

            // Eliminar un estudiante
            repository.Delete(estudiante2.Id);
            Console
        }
        */
    }
}
