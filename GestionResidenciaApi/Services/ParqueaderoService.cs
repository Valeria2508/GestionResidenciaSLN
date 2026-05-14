using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
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

        public async Task<Parqueadero?> UpdateParqueaderoAsync(int id, ParqueaderoDTO dto)
        {
            var existing = await _context.Parqueadero.FindAsync(id);

            if (existing == null)
                return null;

            existing.UnidadId = dto.UnidadId;
            existing.TipoParqueaderoId = dto.TipoParqueaderoId;
            existing.EstadoId = dto.EstadoId;
            existing.Numero = dto.Numero;
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteParqueaderoAsync(int id)
        {
            var existente = await _context.Parqueadero.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Parqueadero.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de parqueaderos porque tiene registros relacionados.");
            }
        }
    }
}
