using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class TipoParqueaderoService : ITipoParqueadero
    {
        private readonly ApplicationDbContext _context;

        public TipoParqueaderoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.TipoParqueadero>> GetTipoParqueaderoAsync()
        {
            return await _context.TipoParqueadero.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.TipoParqueadero> GetTipoParqueaderoByIdAsync(int id)
        {
            return await _context.TipoParqueadero.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.TipoParqueadero> CreateTipoParqueaderoAsync(GestionResidenciaApi.Models.TipoParqueadero tipoParqueadero)
        {
            _context.TipoParqueadero.Add(tipoParqueadero);
            await _context.SaveChangesAsync();
            return tipoParqueadero;
        }

        public async Task<GestionResidenciaApi.Models.TipoParqueadero?> UpdateTipoParqueaderoAsync(int id, TipoParqueaderoCreateDTO dto)
        {
            var existing = await _context.TipoParqueadero.FindAsync(id);

            if (existing == null)
                return null;

            // Do not modify the primary key (TipoParqueaderoId) on update
            existing.Nombre = dto.Nombre;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteTipoParqueaderoAsync(int id)
        {
            var existente = await _context.TipoParqueadero.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.TipoParqueadero.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de tipo de parqueadero porque tiene registros relacionados.");
            }
        }
    }
}
