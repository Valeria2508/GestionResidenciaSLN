using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Reserva : IReserva
    {
        private readonly ApplicationDbContext _context;

        public Reserva(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Reserva>> GetReservaAsync()
        {
            return await _context.Reserva.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Reserva?> GetReservaByIdAsync(int id)
        {
            return await _context.Reserva.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Reserva> CreateReservaAsync(GestionResidenciaApi.Models.Reserva reserva)
        {
            await _context.Reserva.AddAsync(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<GestionResidenciaApi.Models.Reserva?> UpdateReservaAsync(int id, GestionResidenciaApi.Models.Reserva reserva)
        {
            var existente = await _context.Reserva.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(reserva);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteReservaAsync(int id)
        {
            var existente = await _context.Reserva.FindAsync(id);
            if (existente == null)
                return false;

            _context.Reserva.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
