using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface ITipoMantenimiento
    {
        Task<List<GestionResidenciaApi.Models.TipoMantenimiento>> GetTipoMantenimientoAsync();
        Task<GestionResidenciaApi.Models.TipoMantenimiento> GetTipoMantenimientoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.TipoMantenimiento> CreateTipoMantenimientoAsync(GestionResidenciaApi.Models.TipoMantenimiento tipoMantenimiento);
        Task<GestionResidenciaApi.Models.TipoMantenimiento> UpdateTipoMantenimientoAsync(int id, GestionResidenciaApi.Models.TipoMantenimiento tipoMantenimiento);
        Task<bool> DeleteTipoMantenimientoAsync(int id);
    }
}
