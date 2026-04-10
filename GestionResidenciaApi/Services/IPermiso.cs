using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IPermiso
    {
        Task<List<GestionResidenciaApi.Models.Permiso>> GetPermisoAsync();
        Task<GestionResidenciaApi.Models.Permiso> GetPermisoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Permiso> CreatePermisoAsync(GestionResidenciaApi.Models.Permiso permiso);
        Task<GestionResidenciaApi.Models.Permiso> UpdatePermisoAsync(int id, GestionResidenciaApi.Models.Permiso permiso);
        Task<bool> DeletePermisoAsync(int id);
    }
}
