using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class ReservaService : IReserva
    {
        private readonly ApplicationDbContext _context;

        public ReservaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Reserva>> GetReservaAsync()
        {
            return await _context.Reserva.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Reserva> GetReservaByIdAsync(int id)
        {
            return await _context.Reserva.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Reserva> CreateReservaAsync(GestionResidenciaApi.Models.Reserva reserva)
        {
            _context.Reserva.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<GestionResidenciaApi.Models.Reserva> UpdateReservaAsync(int id, GestionResidenciaApi.Models.Reserva reserva)
        {
            var existente = await _context.Reserva.FindAsync(id);
            if (existente == null)
                return null;

            existente.Fecha = reserva.Fecha;
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
