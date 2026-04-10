using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IResidenteUnidad
    {
        Task<List<GestionResidenciaApi.Models.ResidenteUnidad>> GetResidenteUnidadAsync();
        Task<GestionResidenciaApi.Models.ResidenteUnidad> GetResidenteUnidadByIdAsync(int id);
        Task<GestionResidenciaApi.Models.ResidenteUnidad> CreateResidenteUnidadAsync(GestionResidenciaApi.Models.ResidenteUnidad residenteUnidad);
        Task<GestionResidenciaApi.Models.ResidenteUnidad> UpdateResidenteUnidadAsync(int id, GestionResidenciaApi.Models.ResidenteUnidad residenteUnidad);
        Task<bool> DeleteResidenteUnidadAsync(int id);
    }
}
