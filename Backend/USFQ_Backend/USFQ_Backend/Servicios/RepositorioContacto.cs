using Dapper;
using Microsoft.Data.SqlClient;
using USFQ_Backend.Models;

namespace USFQ_Backend.Servicios
{
    public interface IRepositorioContacto
    {
        Task Crear(Contacto contacto);
    }
    public class RepositorioContacto:IRepositorioContacto
    {
        private readonly string connectionString;
        public RepositorioContacto(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task Crear(Contacto contacto)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(
                $@"insert into CONTACTO(Nombre,Telefono,Correo) values (@Nombre,@Telefono,@Correo);
                                                select SCOPE_IDENTITY();"
                                                ,contacto);

            contacto.Id = id;
        }        
    }
}
