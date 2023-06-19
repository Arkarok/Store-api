using MySql.Data.MySqlClient;
using storeAPI.conexion;
using storeAPI.Models;
using System.ComponentModel;
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
                            productos.nombre = item.GetString("nombre");
                            productos.precio = item.GetDecimal("precio");
                            productos.cantidad = item.GetInt32("cantidad");
                            productos.categoria = item.GetString("categoria");
                            lista.Add(productos);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task insertProductos(Productos parametros)
        {
            using (MySqlConnection sql = new MySqlConnection(conexion.conexionSQL()))
            {
                using (var cmd = new MySqlCommand("insertarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("nombre", parametros.nombre);
                    cmd.Parameters.AddWithValue("precio", parametros.precio);
                    cmd.Parameters.AddWithValue("cantidad", parametros.cantidad);
                    cmd.Parameters.AddWithValue("categoria", parametros.categoria);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task editProductos(Productos parametros)
        {
            using (MySqlConnection sql = new MySqlConnection(conexion.conexionSQL()))
            {
                using (var cmd = new MySqlCommand("actualizarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", parametros.id);
                    cmd.Parameters.AddWithValue("precio", parametros.precio);
                    cmd.Parameters.AddWithValue("cantidad", parametros.cantidad);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task removeProductos(Productos parametros)
        {
            using (MySqlConnection sql = new MySqlConnection(conexion.conexionSQL()))
            {
                using (var cmd = new MySqlCommand("eliminarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", parametros.id);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Productos>> showCategoria(Productos parametros)
        {
            var lista = new List<Productos>();

            using (MySqlConnection sql = new MySqlConnection(conexion.conexionSQL()))
            {
                using (var cmd = new MySqlCommand("obtenerProductosPorCategoria", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("categoria", parametros.categoria);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var productos = new Productos();
                            productos.id = item.GetInt32("id");
                            productos.nombre = item.GetString("nombre");
                            productos.precio = item.GetDecimal("precio");
                            productos.cantidad = item.GetInt32("cantidad");
                            productos.categoria = item.GetString("categoria");
                            lista.Add(productos);
                        }
                    }
                }
                return lista;
            }
        }
    }
}
