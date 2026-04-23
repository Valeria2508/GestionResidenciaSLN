
using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class EstadoService : IEstado
    {
        private readonly ApplicationDbContext _context;

        public EstadoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Estado>> GetEstadosAsync()
        {
            return await _context.Estado.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Estado> GetEstadoByIdAsync(int id)
        {
            var existente = await _context.Estado.FindAsync(id);
            return existente;
        }

        public async Task<GestionResidenciaApi.Models.Estado> CreateEstadoAsync(GestionResidenciaApi.Models.Estado estado)
        {
            _context.Estado.Add(estado);
            await _context.SaveChangesAsync();
            return estado;
        }

        public async Task<GestionResidenciaApi.Models.Estado> UpdateEstadoAsync(int id, GestionResidenciaApi.Models.Estado estado)
        {
            var existente = await _context.Estado.FindAsync(id);
            if (existente == null)
                return null;

            existente.Nombre = estado.Nombre;
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteEstadoAsync(int id)
        {
            var existente = await _context.Estado.FindAsync(id);
            if (existente == null)
                return false;

            _context.Estado.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
