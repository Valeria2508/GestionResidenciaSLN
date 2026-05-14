
using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
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

        public async Task<GestionResidenciaApi.Models.Estado?> UpdateEstadoAsync(int id, EstadoDTO dto)
        {
            var existing = await _context.Estado.FindAsync(id);

            if (existing == null)
                return null;

            // Do not modify the primary key (EstadoId) on update
            existing.Nombre = dto.Nombre;
            existing.Descripcion = dto.Descripcion;
            existing.TipoEstado = dto.TipoEstado;
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteEstadoAsync(int id)
        {
            var existente = await _context.Estado.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Estado.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de estados porque tiene registros relacionados.");
            }
        }
    }
}
