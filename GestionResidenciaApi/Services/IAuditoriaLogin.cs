using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Services
{
    public interface IAuditoriaLogin
    {
        Task<List<GestionResidenciaApi.Models.AuditoriaLogin>> GetAuditoriaLoginAsync();   
        Task<GestionResidenciaApi.Models.AuditoriaLogin> GetAuditoriaLoginByIdAsync(int id);
        Task<GestionResidenciaApi.Models.AuditoriaLogin> CreateAuditoriaLoginAsync(GestionResidenciaApi.Models.AuditoriaLogin auditoriaLogin);
        Task<GestionResidenciaApi.Models.AuditoriaLogin> UpdateAuditoriaLoginAsync(int id, GestionResidenciaApi.Models. AuditoriaLogin auditoriaLogin);
        Task<bool> DeleteAuditoriaLoginAsync(int id);
    }
 }
