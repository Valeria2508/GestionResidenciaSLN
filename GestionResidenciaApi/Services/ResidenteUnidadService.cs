using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class ResidenteUnidadService : IResidenteUnidad
    {
        private readonly ApplicationDbContext _context;

        public ResidenteUnidadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.ResidenteUnidad>> GetResidenteUnidadAsync()
        {
            return await _context.ResidenteUnidad.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.ResidenteUnidad> GetResidenteUnidadByIdAsync(int id)
        {
            return await _context.ResidenteUnidad.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.ResidenteUnidad> CreateResidenteUnidadAsync(GestionResidenciaApi.Models.ResidenteUnidad residenteUnidad)
        {
            _context.ResidenteUnidad.Add(residenteUnidad);
            await _context.SaveChangesAsync();
            return residenteUnidad;
        }

        public async Task<ResidenteUnidad?> UpdateResidenteUnidadAsync(int id, ResidenteUnidadDTO dto)
        {
            var existing = await _context.ResidenteUnidad.FindAsync(id);

            if (existing == null)
                return null;

            // Do not modify the identity primary key (ResidenteUnidadId) on update
            existing.UnidadId = dto.UnidadId;
            existing.UsuarioId = dto.UsuarioId;
            existing.EsPropietario = dto.EsPropietario;
            existing.FechaInicio = dto.FechaInicio;
            existing.FechaFin = dto.FechaFin;
            existing.Observacion = dto.Observacion;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteResidenteUnidadAsync(int id)
        {
            var existente = await _context.ResidenteUnidad.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.ResidenteUnidad.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de residenteUnidad porque tiene registros relacionados.");
            }
        }
    }
}
