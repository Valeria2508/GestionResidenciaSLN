using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class TipoIngresoService : ITipoIngreso
    {
        private readonly ApplicationDbContext _context;

        public TipoIngresoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.TipoIngreso>> GetTipoIngresoAsync()
        {
            return await _context.TipoIngreso.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.TipoIngreso> GetTipoIngresoByIdAsync(int id)
        {
            return await _context.TipoIngreso.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.TipoIngreso> CreateTipoIngresoAsync(GestionResidenciaApi.Models.TipoIngreso tipoIngreso)
        {
            _context.TipoIngreso.Add(tipoIngreso);
            await _context.SaveChangesAsync();
            return tipoIngreso;
        }

        public async Task<TipoIngreso?> UpdateTipoIngresoAsync(int id, TipoIngresoDTO dto)
        {
            var existing = await _context.TipoIngreso.FindAsync(id);

            if (existing == null)
                return null;

            // Do not modify the primary key (TipoIngresoId) on update
            existing.Nombre = dto.Nombre;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteTipoIngresoAsync(int id)
        {
            var existente = await _context.TipoIngreso.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.TipoIngreso.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de tipo de ingreso porque tiene registros relacionados.");
            }
        }
    }
}
