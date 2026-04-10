using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IRol
    {
        Task<List<GestionResidenciaApi.Models.Rol>> GetRolAsync();
        Task<GestionResidenciaApi.Models.Rol> GetRolByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Rol> CreateRolAsync(GestionResidenciaApi.Models.Rol rol);
        Task<GestionResidenciaApi.Models.Rol> UpdateRolAsync(int id, GestionResidenciaApi.Models.Rol rol);
        Task<bool> DeleteRolAsync(int id);
    }
}
