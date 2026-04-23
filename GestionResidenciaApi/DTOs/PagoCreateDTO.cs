namespace GestionResidenciaApi.DTOs
{
    public class PagoCreateDTO
    {
        public int UsuarioId { get; set; }
        public int MetodoPagoId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal ValorTotal { get; set; }
        public string Referencia { get; set; }
        public string PagoObservacionId { get; set; }
    }
}
