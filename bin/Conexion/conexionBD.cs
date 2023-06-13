namespace storeAPI.conexion
{
    public class conexionBD
    {
        private String conexion=string.Empty;

        public conexionBD()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build();

            conexion = builder.GetSection("ConnectionStrings:conexion").Value;
        }

        public String conexionSQL()
        {
            return conexion;
        }
    }
}
