using System.Collections.Generic;
using System.Threading.Tasks;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Services
{
    public interface IConjunto
    {
        Task<List<GestionResidenciaApi.Models.Conjunto>> GetConjuntoAsync();
        Task<GestionResidenciaApi.Models.Conjunto> GetConjuntoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Conjunto> CreateConjuntoAsync(GestionResidenciaApi.Models.Conjunto conjunto);
        Task<GestionResidenciaApi.Models.Conjunto?> UpdateConjuntoAsync(int id, ConjuntoCreateDTO dto);
        Task<bool> DeleteConjuntoAsync(int id);

    }
}
