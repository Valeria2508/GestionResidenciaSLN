using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IIngreso
    {
        Task<List<GestionResidenciaApi.Models.Ingreso>> GetIngresoAsync();
        Task<GestionResidenciaApi.Models.Ingreso> GetIngresoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Ingreso> CreateIngresoAsync(GestionResidenciaApi.Models.Ingreso ingreso);
        Task<GestionResidenciaApi.Models.Ingreso> UpdateIngresoAsync(int id, GestionResidenciaApi.Models.Ingreso ingreso);
        Task<bool> DeleteIngresoAsync(int id);
    }
}
