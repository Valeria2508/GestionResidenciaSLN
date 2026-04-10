using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IParqueadero
    {
        Task<List<GestionResidenciaApi.Models.Parqueadero>> GetParqueaderoAsync();
        Task<GestionResidenciaApi.Models.Parqueadero> GetParqueaderoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Parqueadero> CreateParqueaderoAsync(GestionResidenciaApi.Models.Parqueadero parqueadero);
        Task<GestionResidenciaApi.Models.Parqueadero> UpdateParqueaderoAsync(int id, GestionResidenciaApi.Models.Parqueadero parqueadero);
        Task<bool> DeleteParqueaderoAsync(int id);
    }
}
