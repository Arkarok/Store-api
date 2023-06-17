namespace storeAPI.Models
{
    public class Usuarios
    {
        public int id { get; set; }
        public String username { get; set; }
        public String contraseña { get; set; }
        public String correoElectronico { get; set; }
        public int cargo { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public List<Productos> Productos { get; set; }
    }
}
