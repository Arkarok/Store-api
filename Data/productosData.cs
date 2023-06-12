using MySql.Data.MySqlClient;
using storeAPI.conexion;
using storeAPI.Models;
using System.Data;

namespace storeAPI.Data
{
    public class productosData
    {
        conexionBD conexion = new conexionBD();
        public async Task <List<Productos>> showProductos()
        {
            var lista = new List<Productos>();

            using (MySqlConnection sql = new MySqlConnection(conexion.conexionSQL()))
            {
                using (var cmd = new MySqlCommand("obtenerProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var productos = new Productos();
                            productos.id = item.GetInt32("id");
                            productos.descripcion = item.GetString("description");
                            productos.precio = item.GetDecimal("precio");
                            lista.Add(productos);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
