using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IRolPermiso
    {
        Task<List<GestionResidenciaApi.Models.RolPermiso>> GetRolPermisoAsync();
        Task<GestionResidenciaApi.Models.RolPermiso> GetRolPermisoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.RolPermiso> CreateRolPermisoAsync(GestionResidenciaApi.Models.RolPermiso rolPermiso);
        Task<GestionResidenciaApi.Models.RolPermiso> UpdateRolPermisoAsync(int id, GestionResidenciaApi.Models.RolPermiso rolPermiso);
        Task<bool> DeleteRolPermisoAsync(int id);
    }
}
