using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class MetodoPagoService : IMetodoPago
    {
        private readonly ApplicationDbContext _context;

        public MetodoPagoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.MetodoPago>> GetMetodoPagoAsync()
        {
            return await _context.MetodoPago.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.MetodoPago> GetMetodoPagoByIdAsync(int id)
        {
            return await _context.MetodoPago.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.MetodoPago> CreateMetodoPagoAsync(GestionResidenciaApi.Models.MetodoPago metodoPago   )
        {
            _context.MetodoPago.Add(metodoPago);
            await _context.SaveChangesAsync();
            return metodoPago;
        }

        public async Task<MetodoPago?> UpdateMetodoPagoAsync(int id, MetodoPagoDTO dto)
        {
            var existing = await _context.MetodoPago.FindAsync(id);

            if (existing == null)
                return null;

            existing.Nombre = dto.Nombre;
            existing.Descripcion = dto.Descripcion;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteMetodoPagoAsync(int id)
        {
            var existente = await _context.MetodoPago.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.MetodoPago.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de métodos de pago porque tiene registros relacionados.");
            }
        }
    }
}
