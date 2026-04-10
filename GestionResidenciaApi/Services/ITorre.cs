using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface ITorre
    {
        Task<List<GestionResidenciaApi.Models.Torre>> GetTorreAsync();
        Task<GestionResidenciaApi.Models.Torre> GetTorreByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Torre> CreateTorreAsync(GestionResidenciaApi.Models.Torre torre);
        Task<GestionResidenciaApi.Models.Torre> UpdateTorreAsync(int id, GestionResidenciaApi.Models.Torre torre);
        Task<bool> DeleteTorreAsync(int id);
    }
}
