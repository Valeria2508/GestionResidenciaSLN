using System.Collections.Generic;
using System.Threading.Tasks;
using GestionResidenciaApi.Models;


namespace GestionResidenciaApi.Services
{
    public interface ICuotaAdministracion
    {
        Task<List<GestionResidenciaApi.Models.CuotaAdministracion>> GetCuotasAdministracionAsync();
        Task<GestionResidenciaApi.Models.CuotaAdministracion?> GetCuotaAdministracionByIdAsync(int id);
        Task<GestionResidenciaApi.Models.CuotaAdministracion> CreateCuotaAdministracionAsync(GestionResidenciaApi.Models.CuotaAdministracion cuota);
        Task<GestionResidenciaApi.Models.CuotaAdministracion?> UpdateCuotaAdministracionAsync(int id, GestionResidenciaApi.Models.CuotaAdministracion cuota);
        Task<bool> DeleteCuotaAdministracionAsync(int id);
    }
}
