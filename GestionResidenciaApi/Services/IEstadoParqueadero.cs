using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Services
{
    public interface IEstadoParqueadero
    {
        Task<List<GestionResidenciaApi.Models.EstadoParqueadero>> GetEstadosParqueaderoAsync();
        Task<GestionResidenciaApi.Models.EstadoParqueadero?> GetEstadoParqueaderoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.EstadoParqueadero> CreateEstadoParqueaderoAsync(GestionResidenciaApi.Models.EstadoParqueadero estadoParqueadero);
        Task<GestionResidenciaApi.Models.EstadoParqueadero?> UpdateEstadoParqueaderoAsync(int id, GestionResidenciaApi.Models.EstadoParqueadero estadoParqueadero);
        Task<bool> DeleteEstadoParqueaderoAsync(int id);
    }
}
