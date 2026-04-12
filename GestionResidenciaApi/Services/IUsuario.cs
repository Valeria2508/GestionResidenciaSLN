using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IUsuario
    {
        Task<List<Usuario>> GetUsuarioAsync();
        Task<Usuario?> GetUsuarioByIdAsync(int id);
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<Usuario?> UpdateUsuarioAsync(int id, Usuario usuario);
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
