using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Mensajeria : IMensajeria
    {
        private readonly ApplicationDbContext _context;

        public Mensajeria(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Mensajeria>> GetMensajeriaAsync()
        {
            return await _context.Mensajeria.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Mensajeria?> GetMensajeriaByIdAsync(int id)
        {
            return await _context.Mensajeria.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Mensajeria> CreateMensajeriaAsync(GestionResidenciaApi.Models.Mensajeria mensajeria)
        {
            await _context.Mensajeria.AddAsync(mensajeria);
            await _context.SaveChangesAsync();
            return mensajeria;
        }

        public async Task<GestionResidenciaApi.Models.Mensajeria?> UpdateMensajeriaAsync(int id, GestionResidenciaApi.Models.Mensajeria mensajeria)
        {
            var existente = await _context.Mensajeria.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(mensajeria);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteMensajeriaAsync(int id)
        {
            var existente = await _context.Mensajeria.FindAsync(id);
            if (existente == null)
                return false;

            _context.Mensajeria.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
