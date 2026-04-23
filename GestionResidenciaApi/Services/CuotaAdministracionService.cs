using System.Collections.Generic;
using System.Threading.Tasks;
using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class CuotaAdministracionService:ICuotaAdministracion
    {
        private readonly ApplicationDbContext _context;
        public CuotaAdministracionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GestionResidenciaApi.Models.CuotaAdministracion>> GetCuotasAdministracionAsync()
        {
            return await _context.CuotaAdministracion.ToListAsync();
        }
        public async Task<GestionResidenciaApi.Models.CuotaAdministracion> GetCuotaAdministracionByIdAsync(int id)
        {
            return await _context.CuotaAdministracion.FindAsync(id);
        }
        public async Task<GestionResidenciaApi.Models.CuotaAdministracion> CreateCuotaAdministracionAsync(GestionResidenciaApi.Models.CuotaAdministracion cuotaAdministracion)
        {
            _context.CuotaAdministracion.Add(cuotaAdministracion);
            await _context.SaveChangesAsync();
            return cuotaAdministracion;
        }
        public async Task<GestionResidenciaApi.Models.CuotaAdministracion> UpdateCuotaAdministracionAsync(int id, GestionResidenciaApi.Models.CuotaAdministracion cuotaAdministracion)
        {
            var existente = await _context.CuotaAdministracion.FindAsync(id);
            if (existente == null)
                return null;

            existente.SaldoPendiente = cuotaAdministracion.SaldoPendiente;
            await _context.SaveChangesAsync();
            return existente;
        }
        public async Task<bool> DeleteCuotaAdministracionAsync(int id)
        {
            var existente = await _context.CuotaAdministracion.FindAsync(id);
            if (existente == null)
                return false;

            _context.CuotaAdministracion.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
