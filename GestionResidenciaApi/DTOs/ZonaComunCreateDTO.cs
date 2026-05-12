namespace GestionResidenciaApi.DTOs
{
    public class ZonaComunDTO
    {
        public int ZonaComunId { get; set; }
        public int ConjuntoId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public bool RequierePago { get; set; }
        public decimal ValorHora { get; set; }
    }
}
