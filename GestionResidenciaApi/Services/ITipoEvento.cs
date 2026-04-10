using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface ITipoEvento
    {
        Task<List<GestionResidenciaApi.Models.TipoEvento>> GetTipoEventoAsync();
        Task<GestionResidenciaApi.Models.TipoEvento> GetTipoEventoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.TipoEvento> CreateTipoEventoAsync(GestionResidenciaApi.Models.TipoEvento tipoEvento);
        Task<GestionResidenciaApi.Models.TipoEvento> UpdateTipoEventoAsync(int id, GestionResidenciaApi.Models.TipoEvento tipoEvento);
        Task<bool> DeleteTipoEventoAsync(int id);
    }
}
