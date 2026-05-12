using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IMantenimiento
    {
        Task<List<GestionResidenciaApi.Models.Mantenimiento>> GetMantenimientoAsync();
        Task<GestionResidenciaApi.Models.Mantenimiento> GetMantenimientoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Mantenimiento> CreateMantenimientoAsync(GestionResidenciaApi.Models.Mantenimiento mantenimiento);
        Task<GestionResidenciaApi.Models.Mantenimiento> UpdateMantenimientoAsync(int id, GestionResidenciaApi.Models.Mantenimiento mantenimiento);
        Task<bool> DeleteMantenimientoAsync(int id);
    }
}
