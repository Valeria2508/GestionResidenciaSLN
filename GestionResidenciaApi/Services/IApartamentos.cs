using System.Collections.Generic;
using System.Threading.Tasks;
using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IApartamentos
    {
        Task<List<GestionResidenciaApi.Models.Apartamentos>> GetApartamentosAsync();
        Task<GestionResidenciaApi.Models.Apartamentos> GetApartamentoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Apartamentos> CreateApartamentoAsync(GestionResidenciaApi.Models.Apartamentos apartamento);
        Task<GestionResidenciaApi.Models.Apartamentos> UpdateApartamentoAsync(int id, GestionResidenciaApi.Models.Apartamentos apartamento);
        Task<bool> DeleteApartamentoAsync(int id);
    }
}
