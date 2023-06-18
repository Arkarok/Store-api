namespace storeAPI.Models
{
    public class Usuarios
    {
        public int id { get; set; }
        public int documento { get; set; }
        public String nombre { get; set; }
        public String? apellido { get; set; }
        public int celular { get; set; }
        public List<Pedidos>? Pedidos { get; set; }
    }
}
