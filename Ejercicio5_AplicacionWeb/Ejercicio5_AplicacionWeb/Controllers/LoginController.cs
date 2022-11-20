using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                    Usuario user = await usuarioRepositorio.GetPorCodigo(login.Codigo);

                    if (user.EstaActivo)
                    {
                        Rol = user.Rol;

                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, user.Codigo),
                            new Claim(ClaimTypes.Role,Rol)
                        };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,new AuthenticationProperties { IsPersistent=true, ExpiresUtc=DateTime.UtcNow.AddMinutes(5)});

                    }
                    else
                    {
                        return LocalRedirect("/login/Usuario Inactivo");
                    }
                }
                else
                {
                    return LocalRedirect("/login/Datos de usuario incorrectos");
                }

            }
            catch (Exception)
            {

            }
            return LocalRedirect("/");
        }

        [HttpGet("/account/logout")]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/login");
        }

    }
}
