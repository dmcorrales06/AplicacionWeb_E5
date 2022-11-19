using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private string CadenaConexion;

        public LoginRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection EstablecerConexion()
        {
            return new MySqlConnection(CadenaConexion);
        }
        public async Task<bool> ValidarUsuario(Login login)
        {
            bool valido = false;
            try
            {
                using MySqlConnection conexion = EstablecerConexion();
                await conexion.OpenAsync();
                string sql = "SELECT 1 FROM login WHERE CodUsuario = @CodUsuario AND Clave = @Clave;";
                valido = await conexion.ExecuteScalarAsync<bool>(sql, new { login.CodUsuario, login.Clave });
            }
            catch (Exception ex)
            {
            }
            return valido;
        }
    }
}
