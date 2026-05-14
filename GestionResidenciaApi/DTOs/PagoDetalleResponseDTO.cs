public class PagoDetalleResponseDTO
{
    public int PagoDetalleId { get; set; }

    public decimal ValorAbonado { get; set; }

    public int PagoId { get; set; }

    public DateTime FechaPago { get; set; }

    public decimal ValorTotalPago { get; set; }

    public int CuotaId { get; set; }

    public decimal ValorCuota { get; set; }

    public DateTime FechaLimite { get; set; }
}
