using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class TipoEventoService : ITipoEvento
    {
        private readonly ApplicationDbContext _context;

        public TipoEventoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.TipoEvento>> GetTipoEventoAsync()
        {
            return await _context.TipoEvento.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.TipoEvento> GetTipoEventoByIdAsync(int id)
        {
            return await _context.TipoEvento.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.TipoEvento> CreateTipoEventoAsync(GestionResidenciaApi.Models.TipoEvento tipoEvento)
        {
            _context.TipoEvento.Add(tipoEvento);
            await _context.SaveChangesAsync();
            return tipoEvento;
        }

        public async Task<GestionResidenciaApi.Models.TipoEvento?> UpdateTipoEventoAsync(int id, TipoEventoDTO dto)
        {
            var existing = await _context.TipoEvento.FindAsync(id);

            if (existing == null)
                return null;

            // Do not modify the primary key (TipoEventoId) on update
            existing.Nombre = dto.Nombre;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteTipoEventoAsync(int id)
        {
            var existente = await _context.TipoEvento.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.TipoEvento.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de Tipo de eventos porque tiene registros relacionados.");
            }
        }
    }
}
