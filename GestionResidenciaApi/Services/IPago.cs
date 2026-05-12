using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IPago
    {
        Task<List<GestionResidenciaApi.Models.Pago>> GetPagoAsync();
        Task<GestionResidenciaApi.Models.Pago> GetPagoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Pago> CreatePagoAsync(GestionResidenciaApi.Models.Pago pago);
        Task<GestionResidenciaApi.Models.Pago> UpdatePagoAsync(int id, GestionResidenciaApi.Models.Pago pago);
        Task<bool> DeletePagoAsync(int id);
    }
}
