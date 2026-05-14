using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class PagoDetalleService : IPagoDetalle
    {
        private readonly ApplicationDbContext _context;

        public PagoDetalleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.PagoDetalle>> GetPagoDetallesAsync()
        {
            return await _context.PagoDetalle
                .Include(p => p.Pago)
                .Include(p => p.Cuota)
                .ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.PagoDetalle> GetPagoDetalleByIdAsync(int id)
        {
            return await _context.PagoDetalle.FindAsync(id);
        }

        public async Task<PagoDetalle> CreatePagoDetalleAsync(PagoDetalle pagodetalle)
        {
            var cuotaExiste = await _context.CuotaAdministracion
                .AnyAsync(c => c.CuotaId == pagodetalle.CuotaId);

            if (!cuotaExiste)
                throw new Exception("La cuota especificada no existe.");

            var pagoExiste = await _context.Pago
                .AnyAsync(p => p.PagoId == pagodetalle.PagoId);

            if (!pagoExiste)
                throw new Exception("El pago especificado no existe.");

            _context.PagoDetalle.Add(pagodetalle);

            await _context.SaveChangesAsync();

            return pagodetalle;
        }

        public async Task<PagoDetalle?> UpdatePagoDetalleAsync(int id, PagoDetalleDTO dto)
        {
            var existing = await _context.PagoDetalle.FindAsync(id);

            if (existing == null)
                return null;

            existing.CuotaId = dto.CuotaId;
            existing.PagoId = dto.PagoId;
            existing.ValorAbonado = dto.ValorAbonado;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeletePagoDetalleAsync(int id)
        {
            var existente = await _context.PagoDetalle.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.PagoDetalle.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de PagoDetalle porque tiene registros relacionados.");
            }
        }
    }
}
