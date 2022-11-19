using Entidades;

namespace Ejercicio5_AplicacionWeb.Interfaces
{
    public interface ILoginServicio
    {
        Task<bool> ValidarUsuario(Login login);
    }
}
