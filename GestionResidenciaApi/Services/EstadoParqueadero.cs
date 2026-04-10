using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;
namespace GestionResidenciaApi.Services
{
    public class EstadoParqueadero:IEstadoParqueadero
    {
        private readonly ApplicationDbContext _context;
        
        public EstadoParqueadero(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GestionResidenciaApi.Models.EstadoParqueadero>> GetEstadosParqueaderoAsync()
        {
            return await _context.EstadoParqueadero.ToListAsync();
        }
        public async Task<GestionResidenciaApi.Models.EstadoParqueadero?> GetEstadoParqueaderoByIdAsync(int id)
        {
            return await _context.EstadoParqueadero.FindAsync(id);
        }
        public async Task<GestionResidenciaApi.Models.EstadoParqueadero> CreateEstadoParqueaderoAsync(GestionResidenciaApi.Models.EstadoParqueadero estadoParqueadero)
        {
            await _context.EstadoParqueadero.AddAsync(estadoParqueadero);
            await _context.SaveChangesAsync();
            return estadoParqueadero;
        }
        public async Task<GestionResidenciaApi.Models.EstadoParqueadero?> UpdateEstadoParqueaderoAsync(int id, GestionResidenciaApi.Models.EstadoParqueadero estadoParqueadero)
        {
            var existente = await _context.EstadoParqueadero.FindAsync(id);
            if (existente == null)
                return null;
            
            _context.Entry(existente).CurrentValues.SetValues(estadoParqueadero);
            await _context.SaveChangesAsync();
            return existente;
        }
        public async Task<bool> DeleteEstadoParqueaderoAsync(int id)
        {
            var existente = await _context.EstadoParqueadero.FindAsync(id);
            if (existente == null)
                return false;

            _context.EstadoParqueadero.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
