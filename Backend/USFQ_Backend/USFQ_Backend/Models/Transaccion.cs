namespace USFQ_Backend.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public int ContactoId { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public decimal Monto { get; set; }
        public int TipoOperacion { get; set; }
        public string? Nota { get; set; }
    }
}
