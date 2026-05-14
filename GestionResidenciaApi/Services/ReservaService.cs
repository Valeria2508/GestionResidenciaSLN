using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
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

        public async Task<Reserva?> UpdateReservaAsync(int id, ReservaDTO dto)
        {
            var existing = await _context.Reserva.FindAsync(id);

            if (existing == null)
                return null;

            existing.ZonaComunId = dto.ZonaComunId;
            existing.UsuarioId = dto.UsuarioId;
            existing.EstadoId = dto.EstadoId;
            existing.Fecha = dto.Fecha;
            existing.HoraInicio = dto.HoraInicio;
            existing.HoraFin = dto.HoraFin;
            existing.Observacion = dto.Observaciones;
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteReservaAsync(int id)
        {
            var existente = await _context.Reserva.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Reserva.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de reservas porque tiene registros relacionados.");
            }
        }
    }
}
