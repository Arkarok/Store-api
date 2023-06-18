namespace storeAPI.Models
{
    public class Pedidos
    {
        public int id { get; set; }
        public int numeroPedido { get; set; }
        public Usuarios usuario { get; set; }
        public List<Productos> productos { get; set; }
        public decimal precioTotal { get; set; }
    }
}
