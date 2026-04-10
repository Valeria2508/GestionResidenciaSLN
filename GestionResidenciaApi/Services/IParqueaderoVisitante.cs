using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IParqueaderoVisitante
    {
        Task<List<GestionResidenciaApi.Models.ParqueaderoVisitante>> GetParqueaderoVisitanteAsync();
        Task<GestionResidenciaApi.Models.ParqueaderoVisitante?> GetParqueaderoVisitanteByIdAsync(int id);
        Task<GestionResidenciaApi.Models.ParqueaderoVisitante> CreateParqueaderoVisitanteAsync(GestionResidenciaApi.Models.ParqueaderoVisitante parqueaderoVisitante);
        Task<GestionResidenciaApi.Models.ParqueaderoVisitante?> UpdateParqueaderoVisitanteAsync(int id, GestionResidenciaApi.Models.ParqueaderoVisitante parqueaderoVisitante);
        Task<bool> DeleteParqueaderoVisitanteAsync(int id);
    }
}
