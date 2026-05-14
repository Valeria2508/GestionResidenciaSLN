using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class ZonaComunService: IZonaComun
    {
        private readonly ApplicationDbContext _context;

        public ZonaComunService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.ZonaComun>> GetZonaComunAsync()
        {
            return await _context.ZonaComun.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.ZonaComun> GetZonaComunByIdAsync(int id)
        {
            return await _context.ZonaComun.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.ZonaComun> CreateZonaComunAsync(GestionResidenciaApi.Models.ZonaComun zonaComun)
        {
            _context.ZonaComun.Add(zonaComun);
            await _context.SaveChangesAsync();
            return zonaComun;
        }

        public async Task<ZonaComun?> UpdateZonaComunAsync(int id, ZonaComunDTO dto)
        {
            var existing = await _context.ZonaComun.FindAsync(id);

            if (existing == null)
                return null;

            // Do not modify the primary key (ZonaComunId) on update
            existing.ConjuntoId = dto.ConjuntoId;
            existing.Nombre = dto.Nombre;
            existing.Capacidad = dto.Capacidad;
            existing.RequierePago = dto.RequierePago;
            existing.ValorHora = dto.ValorHora;
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteZonaComunAsync(int id)
        {
            var existente = await _context.ZonaComun.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.ZonaComun.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de zonas comunes porque tiene registros relacionados.");
            }
        }
    }
}
