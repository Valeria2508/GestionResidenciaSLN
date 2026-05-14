using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IZonaComun
    {
        Task<List<GestionResidenciaApi.Models.ZonaComun>> GetZonaComunAsync();
        Task<GestionResidenciaApi.Models.ZonaComun> GetZonaComunByIdAsync(int id);
        Task<GestionResidenciaApi.Models.ZonaComun> CreateZonaComunAsync(GestionResidenciaApi.Models.ZonaComun zonaComun);
        Task<GestionResidenciaApi.Models.ZonaComun?> UpdateZonaComunAsync(int id, ZonaComunDTO dto);
        Task<bool> DeleteZonaComunAsync(int id);
    }
}
