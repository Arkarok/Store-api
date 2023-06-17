using MySql.Data.MySqlClient;
using storeAPI.conexion;
using storeAPI.Models;
using System.Data;

namespace storeAPI.Data
{
    public class usuarioData
    {
        conexionBD conexion = new conexionBD();
        public async Task<bool> autentication(Usuarios parametros)
        {
            using (MySqlConnection sql = new MySqlConnection(conexion.conexionSQL()))
            {
                await sql.OpenAsync();

                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM usuarios WHERE usuarios.username = " +
                    "username AND usuarios.contraseña = contraseña;", sql))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("username", parametros.username);
                    cmd.Parameters.AddWithValue("contraseña", parametros.contraseña);

                    int count = Convert.ToInt32(await cmd.ExecuteNonQueryAsync());

                    return count > 0;
                }
            }
        }
    }
}
