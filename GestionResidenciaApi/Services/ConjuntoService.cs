
using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;
using GestionResidenciaApi.DTOs;

namespace GestionResidenciaApi.Services
{
    public class ConjuntoService : IConjunto
    {
        private readonly ApplicationDbContext _context;

        public ConjuntoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Conjunto>> GetConjuntoAsync()
        {
            return await _context.Conjunto.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Conjunto> GetConjuntoByIdAsync(int id)
        {
            var existente = await _context.Conjunto.FindAsync(id);
            return existente;
        }

        public async Task<GestionResidenciaApi.Models.Conjunto> CreateConjuntoAsync(GestionResidenciaApi.Models.Conjunto conjunto)
        {
            _context.Conjunto.Add(conjunto);
            await _context.SaveChangesAsync();
            return conjunto;
        }

        public async Task<Conjunto?> UpdateConjuntoAsync(int id, ConjuntoCreateDTO dto)
        {
            var existing = await _context.Conjunto.FindAsync(id);

            if (existing == null)
                return null;

            existing.Nombre = dto.Nombre;
            existing.Direccion = dto.Direccion;
            existing.Ciudad = dto.Ciudad;
            existing.NIT = dto.NIT;
            existing.Telefono = dto.Telefono;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteConjuntoAsync(int id)
        {
            var existente = await _context.Conjunto.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Conjunto.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de conjuntos porque tiene registros relacionados.");
            }
        }
    }
}
