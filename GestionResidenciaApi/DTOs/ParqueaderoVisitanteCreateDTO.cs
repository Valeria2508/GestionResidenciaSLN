namespace GestionResidenciaApi.DTOs
{
    public class ParqueaderoVisitanteDTO
    {
        public int ParqueaderoId { get; set; }
        public int IngresoId { get; set; }
        public string Placa  {get; set; }
        public DateTime? FechaHoraIngreso { get; set; }
        public DateTime? FechaHoraSalida { get; set; }
    }
}
