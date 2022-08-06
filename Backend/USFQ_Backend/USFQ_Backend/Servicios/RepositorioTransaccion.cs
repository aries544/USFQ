using Dapper;
using Microsoft.Data.SqlClient;
using USFQ_Backend.Models;

namespace USFQ_Backend.Servicios
{
    public interface IRepositorioTransaccion
    {
        Task Actualizar(Transaccion transaccion);
        Task Crear(Transaccion transaccion);
        Task<IEnumerable<Transaccion>> Obtener();        
        Task<Transaccion> ObtenerPorId(int id);
    }
    public class RepositorioTransaccion:IRepositorioTransaccion
    {
        private readonly string connectionString;
        public RepositorioTransaccion(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task Crear(Transaccion transaccion)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(
                $@"Insert into Transacciones(FechaTransaccion,Monto,Nota)
	            values (@FechaTransaccion,@Monto,@Nota);
                select SCOPE_IDENTITY();"
                                                , transaccion);

            transaccion.Id = id;
        }

        public async Task<IEnumerable<Transaccion>> Obtener()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Transaccion>($@"Select Id,                                                            
                                                            FechaTransaccion,
                                                            Monto,                                                            
                                                            Nota
	                                                        from Transacciones;");

        }

        public async Task Actualizar(Transaccion transaccion)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync($@"UPDATE Transacciones set 
	                                        FechaTransaccion = @FechaTransaccion,
	                                        Monto = @Monto,	                                        
	                                        Nota = @Nota
	                                        where Id = @Id", transaccion);
        }

        public async Task<Transaccion> ObtenerPorId(int id)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Transaccion>($@"
                Select Id,FechaTransaccion,Monto,Nota
	            from Transacciones	
                where id = @id", new { id });
        }
    }
}
