using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
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

    public async Task<GestionResidenciaApi.Models.BitacoraVigilancia> UpdateBitacoraVigilanciaAsync(int id, GestionResidenciaApi.Models.BitacoraVigilancia bitacoraVigilancia)
    {
            var existente = await _context.BitacoraVigilancia.FindAsync(id);
            if (existente == null)
                return null;

            existente.Observacion = bitacoraVigilancia.Observacion;
            await _context.SaveChangesAsync();
            return existente;
        }

    public async Task<bool> DeleteBitacoraVigilanciaAsync(int id)
    {
            var existente = await _context.BitacoraVigilancia.FindAsync(id);
            if (existente == null)
                return false;

            _context.BitacoraVigilancia.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
