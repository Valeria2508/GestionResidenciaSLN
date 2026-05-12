using System.Collections.Generic;
using System.Threading.Tasks;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Services
{
    public interface IEstado
    {
        Task<List<GestionResidenciaApi.Models.Estado>> GetEstadosAsync();
        Task<GestionResidenciaApi.Models.Estado> GetEstadoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Estado> CreateEstadoAsync(GestionResidenciaApi.Models.Estado estado);
        Task<GestionResidenciaApi.Models.Estado> UpdateEstadoAsync(int id, GestionResidenciaApi.Models.Estado estado);
        Task<bool> DeleteEstadoAsync(int id);
    }
}
