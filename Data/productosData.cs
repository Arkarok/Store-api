using storeAPI.conexion;
using storeAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace storeAPI.Data
{
    public class productosData
    {
        conexionBD conexion = new conexionBD();
        public async Task <List<Productos>> showProductos()
        {
            var lista = new List<Productos>();

            using (var sql = new SqlConnection(conexion.conexionSQL()))
            {
                using (var cmd = new SqlCommand("insertarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var productos = new Productos();
                            productos.id = (int)item["id"];
                            productos.descripcion = (string)item["descripcion"];
                            productos.precio = (decimal)item["precio"];
                            lista.Add(productos);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
