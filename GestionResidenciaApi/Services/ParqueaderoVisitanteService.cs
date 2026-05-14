using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class ParqueaderoVisitanteService : IParqueaderoVisitante
    {
        private readonly ApplicationDbContext _context;

        public ParqueaderoVisitanteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.ParqueaderoVisitante>> GetParqueaderoVisitanteAsync()
        {
            return await _context.ParqueaderoVisitante.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.ParqueaderoVisitante> GetParqueaderoVisitanteByIdAsync(int id)
        {
            return await _context.ParqueaderoVisitante.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.ParqueaderoVisitante> CreateParqueaderoVisitanteAsync(GestionResidenciaApi.Models.ParqueaderoVisitante parqueaderoVisitante)
        {
            _context.ParqueaderoVisitante.Add(parqueaderoVisitante);
            await _context.SaveChangesAsync();
            return parqueaderoVisitante;
        }

        public async Task<ParqueaderoVisitante?> UpdateParqueaderoVisitanteAsync(int id, ParqueaderoVisitanteDTO dto)
        {
            var existing = await _context.ParqueaderoVisitante.FindAsync(id);

            if (existing == null)
                return null;

            existing.ParqueaderoId = dto.ParqueaderoId;
            existing.IngresoId = dto.IngresoId;
            existing.Placa = dto.Placa;
            existing.FechaHoraIngreso = dto.FechaHoraIngreso;
            existing.FechaHoraSalida = dto.FechaHoraSalida;
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteParqueaderoVisitanteAsync(int id)
        {
            var existente = await _context.ParqueaderoVisitante.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.ParqueaderoVisitante.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de parqueadero visitante porque tiene registros relacionados.");
            }
        }
    }
}
