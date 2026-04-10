using System.Collections.Generic;
using System.Threading.Tasks;
using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IEstadoCuota
    {
        Task<List<GestionResidenciaApi.Models.EstadoCuota>> GetEstadoCuotaAsync();
        Task<GestionResidenciaApi.Models.EstadoCuota?> GetEstadoCuotaByIdAsync(int id);
        Task<GestionResidenciaApi.Models.EstadoCuota> CreateEstadoCuotaAsync(GestionResidenciaApi.Models.EstadoCuota estadoCuota);
        Task<GestionResidenciaApi.Models.EstadoCuota?> UpdateEstadoCuotaAsync(int id, GestionResidenciaApi.Models.EstadoCuota estadoCuota);
        Task<bool> DeleteEstadoCuotaAsync(int id);
    }
}
