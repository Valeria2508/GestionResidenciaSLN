using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Services
{
    public interface IReserva
    {
        Task<List<GestionResidenciaApi.Models.Reserva>> GetReservaAsync();
        Task<GestionResidenciaApi.Models.Reserva> GetReservaByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Reserva> CreateReservaAsync(GestionResidenciaApi.Models.Reserva reserva);
        Task<GestionResidenciaApi.Models.Reserva> UpdateReservaAsync(int id, GestionResidenciaApi.Models.Reserva reserva);
        Task<bool> DeleteReservaAsync(int id);
    }
}
