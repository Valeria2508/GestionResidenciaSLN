using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Ingreso:IIngreso
    {
        private readonly ApplicationDbContext _context;

        public Ingreso(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Ingreso>> GetIngresoAsync()
        {
            return await _context.Ingreso.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Ingreso?> GetIngresoByIdAsync(int id)
        {
            return await _context.Ingreso.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Ingreso> CreateIngresoAsync(GestionResidenciaApi.Models.Ingreso ingreso)
        {
            await _context.Ingreso.AddAsync(ingreso);
            await _context.SaveChangesAsync();
            return ingreso;
        }

        public async Task<GestionResidenciaApi.Models.Ingreso?> UpdateIngresoAsync(int id, GestionResidenciaApi.Models.Ingreso ingreso)
        {
            var existente = await _context.Ingreso.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(ingreso);
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
