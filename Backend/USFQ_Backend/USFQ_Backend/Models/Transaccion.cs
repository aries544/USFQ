namespace USFQ_Backend.Models
{
    public class Transaccion
    {
        public int Id { get; set; }        
        public DateTime FechaTransaccion { get; set; }
        public decimal Monto { get; set; }        
        public string? Nota { get; set; }
    }
}
