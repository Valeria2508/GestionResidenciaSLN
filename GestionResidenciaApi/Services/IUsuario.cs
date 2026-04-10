using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IUsuario
    {
        Task<List<GestionResidenciaApi.Models.Usuario>> GetUsuarioAsync();
        Task<GestionResidenciaApi.Models.Usuario> GetUsuarioByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Usuario> CreateUsuarioAsync(GestionResidenciaApi.Models.Usuario usuario);
        Task<GestionResidenciaApi.Models.Usuario> UpdateUsuarioAsync(int id, GestionResidenciaApi.Models.Usuario usuario);
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
