using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IVisitante
    {
        Task<List<GestionResidenciaApi.Models.Visitante>> GetVisitanteAsync();
        Task<GestionResidenciaApi.Models.Visitante> GetVisitanteByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Visitante> CreateVisitanteAsync(GestionResidenciaApi.Models.Visitante visitante);
        Task<GestionResidenciaApi.Models.Visitante> UpdateVisitanteAsync(int id, GestionResidenciaApi.Models.Visitante visitante);
        Task<bool> DeleteVisitanteAsync(int id);
    }
}
