using System.Collections.Generic;
using System.Threading.Tasks;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Services
{
    public interface IConjunto
    {
        Task<List<GestionResidenciaApi.Models.Conjunto>> GetConjuntosAsync();
        Task<GestionResidenciaApi.Models.Conjunto?> GetConjuntoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Conjunto> CreateConjuntoAsync(GestionResidenciaApi.Models.Conjunto conjunto);
        Task<GestionResidenciaApi.Models.Conjunto?> UpdateConjuntoAsync(int id, GestionResidenciaApi.Models.Conjunto conjunto);
        Task<bool> DeleteConjuntoAsync(int id);

    }
}
