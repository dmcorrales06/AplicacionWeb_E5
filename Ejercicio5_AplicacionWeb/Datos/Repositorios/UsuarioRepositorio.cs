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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private string CadenaConexion;

        public UsuarioRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<Usuario> GetPorCodigo(string codigo)
        {
            Usuario user = new Usuario();
            try
            {

                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM login WHERE CodUsuario = @CodUsuario;";
                user = await conexion.QueryFirstAsync<Usuario>(sql, new { codigo});
            }
            catch (Exception ex)
            {
            }
            return user;
        }
    }
}
