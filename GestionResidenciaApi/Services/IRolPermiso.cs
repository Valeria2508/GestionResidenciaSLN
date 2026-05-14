using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IRolPermiso
    {
        Task<List<GestionResidenciaApi.Models.RolPermiso>> GetRolPermisoAsync();
        Task<GestionResidenciaApi.Models.RolPermiso> GetRolPermisoByIdAsync(int rolId, int permisoId);
        Task<GestionResidenciaApi.Models.RolPermiso> CreateRolPermisoAsync(GestionResidenciaApi.Models.RolPermiso rolPermiso);
        Task<GestionResidenciaApi.Models.RolPermiso?> UpdateRolPermisoAsync(int rolId, int permisoId, RolPermisoDTO dto);
        Task<bool> DeleteRolPermisoAsync(int rolId, int permisoId);
    }
}
