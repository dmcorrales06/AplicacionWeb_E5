using Entidades;

namespace Ejercicio5_AplicacionWeb.Interfaces
{
    public interface IUsuarioServicio
    {

        Task<Usuario> GetPorCodigo(string CodUsuario);
        Task<IEnumerable<Usuario>> GetLista();


    }
}
