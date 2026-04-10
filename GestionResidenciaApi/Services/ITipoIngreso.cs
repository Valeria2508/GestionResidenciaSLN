using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface ITipoIngreso
    {
        Task<List<GestionResidenciaApi.Models.TipoIngreso>> GetTipoIngresoAsync();
        Task<GestionResidenciaApi.Models.TipoIngreso> GetTipoIngresoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.TipoIngreso> CreateTipoIngresoAsync(GestionResidenciaApi.Models.TipoIngreso tipoIngreso);
        Task<GestionResidenciaApi.Models.TipoIngreso> UpdateTipoIngresoAsync(int id, GestionResidenciaApi.Models.TipoIngreso tipoIngreso);
        Task<bool> DeleteTipoIngresoAsync(int id);
    }
}
