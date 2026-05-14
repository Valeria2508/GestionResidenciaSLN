using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class PagoService : IPago
    {
        private readonly ApplicationDbContext _context;

        public PagoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Pago>> GetPagoAsync()
        {
            return await _context.Pago.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Pago> GetPagoByIdAsync(int id)
        {
            return await _context.Pago.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Pago> CreatePagoAsync(GestionResidenciaApi.Models.Pago pago)
        {
            _context.Pago.Add(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<GestionResidenciaApi.Models.Pago?> UpdatePagoAsync(int id, PagoCreateDTO dto)
        {
            var existing = await _context.Pago.FindAsync(id);

            if (existing == null)
                return null;

            existing.UsuarioId = dto.UsuarioId;
            existing.MetodoPagoId = dto.MetodoPagoId;
            existing.FechaPago = dto.FechaPago;
            existing.ValorTotal = dto.ValorTotal;
            existing.Referencia = dto.Referencia;
            existing.PagoObservacionId = dto.PagoObservacionId;
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeletePagoAsync(int id)
        {
            var existente = await _context.Pago.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Pago.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de pagos porque tiene registros relacionados.");
            }
        }
    }
}
