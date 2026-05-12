namespace GestionResidenciaApi.DTOs
{
    public class PersonaDTO
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; } = string.Empty;
    }
}
