namespace GestionResidenciaApi.DTOs
{
    public class ApartamentoCreateDTO
    {
        public int TorreId { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int Area { get; set; }
    }
}
