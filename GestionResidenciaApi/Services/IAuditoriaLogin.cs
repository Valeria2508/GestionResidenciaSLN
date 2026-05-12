using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Services
{
    public interface IAuditoriaLogin
    {
        Task<List<GestionResidenciaApi.Models.AuditoriaLogin>> GetAuditoriaLoginAsync();   
        Task<GestionResidenciaApi.Models.AuditoriaLogin> GetAuditoriaLoginByIdAsync(int id);
        Task<GestionResidenciaApi.Models.AuditoriaLogin> CreateAuditoriaLoginAsync(GestionResidenciaApi.Models.AuditoriaLogin auditoriaLogin);
        Task<AuditoriaLogin?> UpdateAuditoriaLoginAsync(int id, AuditoriaLoginCreateDTO dto);
        Task<bool> DeleteAuditoriaLoginAsync(int id);
    }
 }
