using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class ParqueaderoService : IParqueadero
    {
        private readonly ApplicationDbContext _context;

        public ParqueaderoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Parqueadero>> GetParqueaderoAsync()
        {
            return await _context.Parqueadero.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Parqueadero> GetParqueaderoByIdAsync(int id)
        {
            return await _context.Parqueadero.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Parqueadero> CreateParqueaderoAsync(GestionResidenciaApi.Models.Parqueadero parqueadero)
        {
            _context.Parqueadero.Add(parqueadero);
            await _context.SaveChangesAsync();
            return parqueadero;
        }

        public async Task<GestionResidenciaApi.Models.Parqueadero> UpdateParqueaderoAsync(int id, GestionResidenciaApi.Models.Parqueadero parqueadero)
        {
            var existente = await _context.Parqueadero.FindAsync(id);
            if (existente == null)
                return null;

            existente.Numero = parqueadero.Numero;
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteParqueaderoAsync(int id)
        {
            var existente = await _context.Parqueadero.FindAsync(id);
            if (existente == null)
                return false;

            _context.Parqueadero.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
