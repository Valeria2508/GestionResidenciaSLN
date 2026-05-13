using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GestionResidenciaApi.Services
{
    public interface ICuotaAdministracion
    {
        Task<List<GestionResidenciaApi.Models.CuotaAdministracion>> GetCuotaAdministracionAsync();
        Task<GestionResidenciaApi.Models.CuotaAdministracion> GetCuotaAdministracionByIdAsync(int id);
        Task<GestionResidenciaApi.Models.CuotaAdministracion> CreateCuotaAdministracionAsync(GestionResidenciaApi.Models.CuotaAdministracion cuota);
        Task<GestionResidenciaApi.Models.CuotaAdministracion?> UpdateCuotaAdministracionAsync(int id, CuotaCreateDTO dto);
        Task<bool> DeleteCuotaAdministracionAsync(int id);
    }
}
