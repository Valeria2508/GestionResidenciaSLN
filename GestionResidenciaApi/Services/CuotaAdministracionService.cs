using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionResidenciaApi.Services
{
    public class CuotaAdministracionService:ICuotaAdministracion
    {
        private readonly ApplicationDbContext _context;
        public CuotaAdministracionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GestionResidenciaApi.Models.CuotaAdministracion>> GetCuotaAdministracionAsync()
        {
            return await _context.CuotaAdministracion.ToListAsync();
        }
        public async Task<GestionResidenciaApi.Models.CuotaAdministracion> GetCuotaAdministracionByIdAsync(int id)
        {
            var existente = await _context.CuotaAdministracion.FindAsync(id);
            return existente;
        }
        public async Task<GestionResidenciaApi.Models.CuotaAdministracion> CreateCuotaAdministracionAsync(GestionResidenciaApi.Models.CuotaAdministracion cuotaAdministracion)
        {
            _context.CuotaAdministracion.Add(cuotaAdministracion);
            await _context.SaveChangesAsync();
            return cuotaAdministracion;
        }
        public async Task<CuotaAdministracion?> UpdateCuotaAdministracionAsync(int id, CuotaCreateDTO dto)
        {
            var existing = await _context.CuotaAdministracion.FindAsync(id);

            if (existing == null)
                return null;

            existing.UnidadId = dto.UnidadId;
            existing.EstadoId = dto.EstadoId;
            existing.Periodo = dto.Periodo;
            existing.Valor = dto.Valor;
            existing.FechaLimite = dto.FechaLimite;
            existing.SaldoPendiente = dto.SaldoPendiente;
            existing.Observacion = dto.Observacion;
            await _context.SaveChangesAsync();

            return existing;
        }
        public async Task<bool> DeleteCuotaAdministracionAsync(int id)
        {
            var existente = await _context.CuotaAdministracion.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.CuotaAdministracion.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de conjuntos porque tiene registros relacionados.");
            }
        }
    }
}
