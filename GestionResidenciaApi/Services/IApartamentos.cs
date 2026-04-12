using System.Collections.Generic;
using System.Threading.Tasks;
using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IApartamentos
    {
        Task<List<Apartamentos>> GetApartamentosAsync();
        Task<Apartamentos?> GetApartamentoByIdAsync(int id);
        Task<Apartamentos> CreateApartamentoAsync(Apartamentos apartamento);
        Task<Apartamentos?> UpdateApartamentoAsync(int id, Apartamentos apartamento);
        Task<bool> DeleteApartamentoAsync(int id);
    }
}
