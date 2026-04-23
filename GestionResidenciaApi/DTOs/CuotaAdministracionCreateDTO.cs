namespace GestionResidenciaApi.DTOs
{
    public class CuotaCreateDTO
    {
        public int UnidadId { get; set; }
        public int EstadoId { get; set; }
        public DateOnly Periodo { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaLimite { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string Observacion { get; set; }

    }
}
