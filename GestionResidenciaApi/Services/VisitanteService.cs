using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class VisitanteService : IVisitante
    {
        private readonly ApplicationDbContext _context;

        public VisitanteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Visitante>> GetVisitanteAsync()
        {
            return await _context.Visitante.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Visitante> GetVisitanteByIdAsync(int id)
        {
            return await _context.Visitante.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Visitante> CreateVisitanteAsync(GestionResidenciaApi.Models.Visitante visitante)
        {
            _context.Visitante.Add(visitante);
            await _context.SaveChangesAsync();
            return visitante;
        }

        public async Task<Visitante?> UpdateVisitanteAsync(int id, VisitanteDTO dto)
        {
            var existing = await _context.Visitante.FindAsync(id);

            if (existing == null)
                return null;

            existing.Nombre = dto.Nombre;
            existing.TipoDocumento = dto.TipoDocumento;
            existing.Documento = dto.Documento;
            existing.FechaRegistro = dto.FechaRegistro;
            existing.Telefono = dto.Telefono;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteVisitanteAsync(int id)
        {
            var existente = await _context.Visitante.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Visitante.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de visitantes porque tiene registros relacionados.");
            }
        }
    }
}
