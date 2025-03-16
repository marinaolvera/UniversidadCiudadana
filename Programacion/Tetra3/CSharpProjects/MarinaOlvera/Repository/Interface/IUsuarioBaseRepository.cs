using MarinaOlvera.Models;

namespace MarinaOlvera.Repository.Interface
{
    //Implementamos Clase Generica
    public interface IUsuarioBaseRepository<TipoDeClase>
    {
        public void Crear(TipoDeClase obj);
        public TipoDeClase BuscarByEmail(string email);

        //Funcion para guardar la informacion en un archivo .json
        public void GuardarEnJson();
    }
}