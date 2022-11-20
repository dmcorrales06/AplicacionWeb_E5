using Entidades;

namespace Datos.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> GetPorCodigo(string codigo);

        Task<IEnumerable<Usuario>> GetLista();


    }
}
