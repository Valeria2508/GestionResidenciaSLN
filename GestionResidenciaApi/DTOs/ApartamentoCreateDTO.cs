namespace GestionResidenciaApi.DTOs
{
    public class ApartamentoCreateDTO
    {
        public int UnidadId { get; set; }
        public int TorreId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int Area { get; set; }
    }
}
