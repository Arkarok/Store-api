using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using storeAPI.conexion;
using storeAPI.Models;
using System.Data;

namespace storeAPI.Data
{
    public class pedidoData
    {
        conexionBD conexion = new conexionBD();
        public async Task insertPedidos(Pedidos parametros)
        {
            using (MySqlConnection sql = new MySqlConnection(conexion.conexionSQL()))
            {
                using (var cmd = new MySqlCommand("insertarPedido", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("numeroPedido", parametros.numeroPedido);
                    cmd.Parameters.AddWithValue("precioTotal", parametros.precioTotal);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    int pedidoId = Convert.ToInt32(cmd.LastInsertedId);

                    using (var cmdProductos = new MySqlCommand("insertarProducto", sql))
                    {
                        foreach (var producto in parametros.productos)
                        {
                            cmdProductos.Parameters.Clear();
                            cmdProductos.Parameters.AddWithValue("nombre", producto.nombre);
                            cmdProductos.Parameters.AddWithValue("precio", producto.precio);
                            cmdProductos.Parameters.AddWithValue("cantidad", producto.cantidad);

                            int productoId = Convert.ToInt32(await cmdProductos.ExecuteScalarAsync());
                       
                            using (var cmdPedidosProductos = new MySqlCommand("insertarPedidoProducto", sql))
                            {
                                cmdPedidosProductos.Parameters.AddWithValue("pedidoId", pedidoId);
                                cmdPedidosProductos.Parameters.AddWithValue("productoId", productoId);
                                await cmdPedidosProductos.ExecuteNonQueryAsync();
                            }
                        }
                    }
                }
            }
        }

    }
}
