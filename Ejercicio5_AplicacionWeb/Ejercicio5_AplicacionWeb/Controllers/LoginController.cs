using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio5_AplicacionWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly Config config;

        private ILoginRepositorio loginRepositorio;

        private IUsuarioRepositorio usuarioRepositorio;

        public LoginController(Config _config)
        {
            config = _config;
            loginRepositorio = new LoginRepositorio(_config.CadenaConexion);
            usuarioRepositorio = new UsuarioRepositorio(_config.CadenaConexion);
        }

        [HttpPost("/account/login")]



        public async Task<IActionResult> Login(Login login)
        {
            string Rol = string.Empty;

            try
            {
                bool usuarioValido = await loginRepositorio.ValidarUsuario(login);
                if (usuarioValido)
                {
                    Usuario user = await usuarioRepositorio.GetPorCodigo(login.CodUsuario);
                }

            }
            catch (Exception)
            {

            }

        }

    }
}
