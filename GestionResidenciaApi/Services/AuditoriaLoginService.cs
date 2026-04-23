using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
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
        public async Task<GestionResidenciaApi.Models.AuditoriaLogin> UpdateAuditoriaLoginAsync(int id, GestionResidenciaApi.Models.AuditoriaLogin auditoriaLogin)
        {
            var existente = await _context.AuditoriaLogin.FindAsync(id);
            if (existente == null)
                return null;

            existente.Motivo = auditoriaLogin.Motivo;
            await _context.SaveChangesAsync();
            return existente;
        }
        public async Task<bool> DeleteAuditoriaLoginAsync(int id)
        {
            var existente = await _context.AuditoriaLogin.FindAsync(id);
            if (existente == null)
                return false;

            _context.AuditoriaLogin.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
