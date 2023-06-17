using MySql.Data.MySqlClient;
using storeAPI.conexion;
using storeAPI.Models;
using System.Data;

namespace storeAPI.Data
{
    public class usuarioData
    {
        conexionBD conexion = new conexionBD();
        public async Task autentication(Usuarios parametros)
        {
            using (MySqlConnection sql = new MySqlConnection(conexion.conexionSQL()))
            {
                using (var cmd = new MySqlCommand("SELECT * FROM usuarios WHERE usuarios.username = " +
                    "username AND usuarios.password = password;", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("username", parametros.username);
                    cmd.Parameters.AddWithValue("contraseña", parametros.contraseña);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
