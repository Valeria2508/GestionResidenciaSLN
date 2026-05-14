using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IMensajeria
    {
        Task<List<GestionResidenciaApi.Models.Mensajeria>> GetMensajeriaAsync();
        Task<GestionResidenciaApi.Models.Mensajeria> GetMensajeriaByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Mensajeria> CreateMensajeriaAsync(GestionResidenciaApi.Models.Mensajeria mensajeria);
        Task<GestionResidenciaApi.Models.Mensajeria?> UpdateMensajeriaAsync(int id, MensajeriaDTO dto);
        Task<bool> DeleteMensajeriaAsync(int id);
    }
}
