using Datos.Interfaces;
using Datos.Repositorios;
using Ejercicio5_AplicacionWeb.Interfaces;
using Entidades;

namespace Ejercicio5_AplicacionWeb.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly Config _configuracion;


        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio(Config config)
        {
            _configuracion = config;
            usuarioRepositorio = new UsuarioRepositorio(config.CadenaConexion);
        }

        public async Task<IEnumerable<Usuario>> GetLista()
        {
            return await usuarioRepositorio.GetLista();

        }

        public async Task<Usuario> GetPorCodigo(string CodUsuario)
        {
            return await usuarioRepositorio.GetPorCodigo(CodUsuario);
        }
    }
}
