﻿using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private string CadenaConexion;

        public LoginRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }
        public async Task<bool> ValidarUsuario(Login login)
        {
            bool valido = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT 1 FROM usuario WHERE CodUsuario = @CodUsuario AND Clave = @Clave;";
                valido = await conexion.ExecuteScalarAsync<bool>(sql, new { login.Codigo, login.Clave });
            }
            catch (Exception ex)
            {
            }
            return valido;
        }
    }
}
