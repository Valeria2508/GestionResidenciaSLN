using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionResidenciaApi.Services
{
    public interface IApartamentos
    {
        Task<List<GestionResidenciaApi.Models.Apartamentos>> GetApartamentosAsync();
        Task<GestionResidenciaApi.Models.Apartamentos> GetApartamentoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Apartamentos> CreateApartamentoAsync(GestionResidenciaApi.Models.Apartamentos apartamento);
        Task<Apartamentos?> UpdateApartamentoAsync(int id, ApartamentoCreateDTO dto);
        Task<bool> DeleteApartamentoAsync(int id);
    }
}
