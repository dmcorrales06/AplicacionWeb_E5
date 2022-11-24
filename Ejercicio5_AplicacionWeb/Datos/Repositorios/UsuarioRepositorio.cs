using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;

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

        public async Task<Usuario> GetPorCodigo(string Codigo)
        {
            Usuario user = new Usuario();
            try
            {

                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM usuario WHERE Codigo = @Codigo;";
                user = await conexion.QueryFirstAsync<Usuario>(sql, new { Codigo});
            }
            catch (Exception ex)
            {
            }
            return user;
        }

        public async Task<IEnumerable<Usuario>> GetLista()
        {
            IEnumerable < Usuario > lista = new List<Usuario>();
            try
            {
              
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM usuario;";
            
                lista = await conexion.QueryAsync<Usuario>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;

        }
    }
}
