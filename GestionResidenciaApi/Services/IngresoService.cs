using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class IngresoService:IIngreso
    {
        private readonly ApplicationDbContext _context;

        public IngresoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Ingreso>> GetIngresoAsync()
        {
            return await _context.Ingreso.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Ingreso> GetIngresoByIdAsync(int id)
        {
            return await _context.Ingreso.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Ingreso> CreateIngresoAsync(GestionResidenciaApi.Models.Ingreso ingreso)
        {
            _context.Ingreso.Add(ingreso);
            await _context.SaveChangesAsync();
            return ingreso;
        }

        public async Task<GestionResidenciaApi.Models.Ingreso> UpdateIngresoAsync(int id, GestionResidenciaApi.Models.Ingreso ingreso)
        {
            var existente = await _context.Ingreso.FindAsync(id);
            if (existente == null)
                return null;

            existente.FechaHoraSalida = ingreso.FechaHoraSalida;
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteIngresoAsync  (int id)
        {
            var existente = await _context.Ingreso.FindAsync(id);
            if (existente == null)
                return false;

            _context.Ingreso.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
