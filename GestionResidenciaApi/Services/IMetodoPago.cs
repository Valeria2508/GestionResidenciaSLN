using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IMetodoPago
    {
        Task<List<GestionResidenciaApi.Models.MetodoPago>> GetMetodoPagoAsync();
        Task<GestionResidenciaApi.Models.MetodoPago?> GetMetodoPagoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.MetodoPago> CreateMetodoPagoAsync(GestionResidenciaApi.Models.MetodoPago metodoPago);
        Task<GestionResidenciaApi.Models.MetodoPago?> UpdateMetodoPagoAsync(int id, GestionResidenciaApi.Models.MetodoPago metodoPago);
        Task<bool> DeleteMetodoPagoAsync(int id);
    }
}
