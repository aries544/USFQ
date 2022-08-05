using Dapper;
using Microsoft.Data.SqlClient;
using USFQ_Backend.Models;

namespace USFQ_Backend.Servicios
{
    public interface IRepositorioContacto
    {
        Task Actualizar(Contacto contacto);
        Task Crear(Contacto contacto);
        Task<IEnumerable<Contacto>> Obtener();
        Task<Contacto> ObtenerPorId(int id);
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
        
        public async Task<IEnumerable<Contacto>> Obtener()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Contacto>($@"select id,Nombre,Telefono,Correo from Contacto;");

        }

        public async Task Actualizar(Contacto contacto)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync($@"UPDATE Contacto set 
	            Nombre = @Nombre,
	            Telefono = @Telefono,
	            Correo = @Correo
	            where Id = @Id",contacto);
        }

        public async Task<Contacto> ObtenerPorId(int id)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Contacto>($@"
                Select id, Nombre, Telefono, Correo 
                from Contacto 
                where id = @id", new { id });
        }
    }
}
