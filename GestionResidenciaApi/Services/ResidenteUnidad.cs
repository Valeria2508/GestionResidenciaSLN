using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class ResidenteUnidad : IResidenteUnidad
    {
        private readonly ApplicationDbContext _context;

        public ResidenteUnidad(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.ResidenteUnidad>> GetResidenteUnidadAsync()
        {
            return await _context.ResidenteUnidad.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.ResidenteUnidad?> GetResidenteUnidadByIdAsync(int id)
        {
            return await _context.ResidenteUnidad.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.ResidenteUnidad> CreateResidenteUnidadAsync(GestionResidenciaApi.Models.ResidenteUnidad residenteUnidad)
        {
            await _context.ResidenteUnidad.AddAsync(residenteUnidad);
            await _context.SaveChangesAsync();
            return residenteUnidad;
        }

        public async Task<GestionResidenciaApi.Models.ResidenteUnidad?> UpdateResidenteUnidadAsync(int id, GestionResidenciaApi.Models.ResidenteUnidad residenteUnidad)
        {
            var existente = await _context.ResidenteUnidad.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(residenteUnidad);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteResidenteUnidadAsync(int id)
        {
            var existente = await _context.ResidenteUnidad.FindAsync(id);
            if (existente == null)
                return false;

            _context.ResidenteUnidad.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
