using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;
namespace GestionResidenciaApi.Services
{
    public class AuditoriaLogin : IAuditoriaLogin
    {
        private readonly ApplicationDbContext _context;
        
        public AuditoriaLogin(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.AuditoriaLogin>> GetAuditoriaLoginAsync()
        {
            return await _context.AuditoriaLogin.ToListAsync();
        }
        public async Task<GestionResidenciaApi.Models.AuditoriaLogin?> GetAuditoriaLoginByIdAsync(int id)
        {
            return await _context.AuditoriaLogin.FindAsync(id);
        }
        public async Task<GestionResidenciaApi.Models.AuditoriaLogin> CreateAuditoriaLoginAsync(GestionResidenciaApi.Models.AuditoriaLogin auditoriaLogin)
        {
            await _context.AuditoriaLogin.AddAsync(auditoriaLogin);
            await _context.SaveChangesAsync();
            return auditoriaLogin;
        }
        public async Task<GestionResidenciaApi.Models.AuditoriaLogin?> UpdateAuditoriaLoginAsync(int id, GestionResidenciaApi.Models.AuditoriaLogin auditoriaLogin)
        {
            var existente = await _context.AuditoriaLogin.FindAsync(id);
            if (existente == null)
                return null;
            _context.Entry(existente).CurrentValues.SetValues(auditoriaLogin);
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
