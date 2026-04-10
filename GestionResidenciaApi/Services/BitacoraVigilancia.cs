using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class BitacoraVigilancia
    {
        private readonly ApplicationDbContext _context;
    public BitacoraVigilancia(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GestionResidenciaApi.Models.BitacoraVigilancia>> GetBitacoraVigilanciaAsync()
    {
        return await _context.BitacoraVigilancia.ToListAsync();
    }

    public async Task<GestionResidenciaApi.Models.BitacoraVigilancia?> GetBitacoraVigilanciaByIdAsync(int id)
    {
        return await _context.BitacoraVigilancia.FindAsync(id);
    }

    public async Task<GestionResidenciaApi.Models.BitacoraVigilancia> CreateBitacoraVigilanciaAsync(GestionResidenciaApi.Models.BitacoraVigilancia bitacoraVigilancia)
    {
        await _context.BitacoraVigilancia.AddAsync(bitacoraVigilancia);
        await _context.SaveChangesAsync();
        return bitacoraVigilancia;
    }

    public async Task<GestionResidenciaApi.Models.BitacoraVigilancia?> UpdateBitacoraVigilanciaAsync(int id, GestionResidenciaApi.Models.BitacoraVigilancia bitacoraVigilancia)
    {
        var existente = await _context.BitacoraVigilancia.FindAsync(id);
        if (existente == null)
            return null;

        _context.Entry(existente).CurrentValues.SetValues(bitacoraVigilancia);
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
