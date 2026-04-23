namespace GestionResidenciaApi.DTOs
{
    public class PagoDetalleDTO
    {
        public int PagoId { get; set; }
        public int CuotaId { get; set; }
        public decimal ValorAbonado { get; set; }
    }
}
