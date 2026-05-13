using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;
namespace GestionResidenciaApi.Services
{
    public class AuditoriaLoginService : IAuditoriaLogin
    {
        private readonly ApplicationDbContext _context;
        
        public AuditoriaLoginService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.AuditoriaLogin>> GetAuditoriaLoginAsync()
        {
            return await _context.AuditoriaLogin.ToListAsync();
        }
        public async Task<GestionResidenciaApi.Models.AuditoriaLogin> GetAuditoriaLoginByIdAsync(int id)
        {
            return await _context.AuditoriaLogin.FindAsync(id);
        }
        public async Task<GestionResidenciaApi.Models.AuditoriaLogin> CreateAuditoriaLoginAsync(GestionResidenciaApi.Models.AuditoriaLogin auditoriaLogin)
        {
            _context.AuditoriaLogin.Add(auditoriaLogin);
            await _context.SaveChangesAsync();
            return auditoriaLogin;
        }
        public async Task<AuditoriaLogin?> UpdateAuditoriaLoginAsync(int id, AuditoriaLoginCreateDTO dto)
        {
            var existing = await _context.AuditoriaLogin.FindAsync(id);

            if (existing == null)
                return null;

            existing.UsuarioId = dto.UsuarioId;
            existing.Username = dto.Username;
            existing.FechaIntento = dto.FechaIntento;
            existing.Ip = dto.Ip;
            existing.Exitoso = dto.Exitoso;
            existing.Motivo = dto.Motivo;

            await _context.SaveChangesAsync();

            return existing;
        }
        public async Task<bool> DeleteAuditoriaLoginAsync(int id)
        {
            var existente = await _context.AuditoriaLogin.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.AuditoriaLogin.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de auditoría de login porque tiene registros relacionados.");
            }
        }
    }
}
