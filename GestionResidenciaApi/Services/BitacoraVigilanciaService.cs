using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class BitacoraVigilanciaService : IBitacoraVigilancia
    {
        private readonly ApplicationDbContext _context;
    public BitacoraVigilanciaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GestionResidenciaApi.Models.BitacoraVigilancia>> GetBitacoraVigilanciaAsync()
    {
        return await _context.BitacoraVigilancia.ToListAsync();
    }

    public async Task<GestionResidenciaApi.Models.BitacoraVigilancia> GetBitacoraVigilanciaByIdAsync(int id)
    {
        return await _context.BitacoraVigilancia.FindAsync(id);
    }

    public async Task<GestionResidenciaApi.Models.BitacoraVigilancia> CreateBitacoraVigilanciaAsync(GestionResidenciaApi.Models.BitacoraVigilancia bitacoraVigilancia)
    {
            _context.BitacoraVigilancia.Add(bitacoraVigilancia);
            await _context.SaveChangesAsync();
            return bitacoraVigilancia;
        }

        public async Task<BitacoraVigilancia?> UpdateBitacoraVigilanciaAsync(int id, BitacoraVigilanciaDTO dto)
        {
            var existing = await _context.BitacoraVigilancia.FindAsync(id);

            if (existing == null)
                return null;

            existing.VigilanteId = dto.VigilanteId;
            existing.TipoEventoId = dto.TipoEventoId;
            existing.IngresoId = dto.IngresoId;
            existing.UnidadId = dto.UnidadId;
            existing.FechaHora = dto.FechaHora;
            existing.Observacion = dto.Observacion;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteBitacoraVigilanciaAsync(int id)
        {
            var existente = await _context.BitacoraVigilancia.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.BitacoraVigilancia.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de bitácora de vigilancia porque tiene registros relacionados.");
            }
        }
    }

}
