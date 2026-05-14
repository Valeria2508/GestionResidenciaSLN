using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class MensajeriaService : IMensajeria
    {
        private readonly ApplicationDbContext _context;

        public MensajeriaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Mensajeria>> GetMensajeriaAsync()
        {
            return await _context.Mensajeria.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Mensajeria> GetMensajeriaByIdAsync(int id)
        {
            return await _context.Mensajeria.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Mensajeria> CreateMensajeriaAsync(GestionResidenciaApi.Models.Mensajeria mensajeria)
        {
            _context.Mensajeria.Add(mensajeria);
            await _context.SaveChangesAsync();
            return mensajeria;
        }

        public async Task<Mensajeria?> UpdateMensajeriaAsync(int id, MensajeriaDTO dto)
        {
            var existing = await _context.Mensajeria.FindAsync(id);

            if (existing == null)
                return null;

            existing.UnidadId = dto.UnidadId;
            existing.UsuarioId = dto.UsuarioId;
            existing.Empresa = dto.Empresa;
            existing.Guia = dto.Guia;
            existing.Descripcion = dto.Descripcion;
            existing.FechaRecepcion = dto.FechaRecepcion;
            existing.FechaEntrega = dto.FechaEntrega;
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteMensajeriaAsync(int id)
        {
            var existente = await _context.Mensajeria.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Mensajeria.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de mensajeria porque tiene registros relacionados.");
            }
        }
    }
}
