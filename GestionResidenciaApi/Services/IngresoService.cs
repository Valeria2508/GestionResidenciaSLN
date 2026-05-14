using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
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
            var existente = await _context.Ingreso.FindAsync(id);
            return existente;
        }

        public async Task<GestionResidenciaApi.Models.Ingreso> CreateIngresoAsync(GestionResidenciaApi.Models.Ingreso ingreso)
        {
            _context.Ingreso.Add(ingreso);
            await _context.SaveChangesAsync();
            return ingreso;
        }

        public async Task<Ingreso?> UpdateIngresoAsync(int id, IngresoDTO dto)
        {
            var existing = await _context.Ingreso.FindAsync(id);

            if (existing == null)
                return null;

            existing.NombrePersona = dto.NombrePersona;
            existing.Documento = dto.Documento;
            existing.Vehiculo = dto.Vehiculo;
            existing.FechaHoraIngreso = dto.FechaIngreso;
            existing.FechaHoraSalida = dto.FechaSalida;
            existing.Observacion = dto.Observacion;
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteIngresoAsync(int id)
        {
            var existente = await _context.Ingreso.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Ingreso.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de ingresos porque tiene registros relacionados.");
            }
        }
    }
}
