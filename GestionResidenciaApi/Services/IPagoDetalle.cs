using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IPagoDetalle
    {
        Task<List<GestionResidenciaApi.Models.PagoDetalle>> GetPagoDetallesAsync();
        Task<GestionResidenciaApi.Models.PagoDetalle> GetPagoDetalleByIdAsync(int id);
        Task<GestionResidenciaApi.Models.PagoDetalle> CreatePagoDetalleAsync(GestionResidenciaApi.Models.PagoDetalle pagoDetalle);
        Task<GestionResidenciaApi.Models.PagoDetalle> UpdatePagoDetalleAsync(int id, GestionResidenciaApi.Models.   PagoDetalle pagoDetalle);
        Task<bool> DeletePagoDetalleAsync(int id);
    }
}
