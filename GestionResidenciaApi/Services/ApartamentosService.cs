using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class ApartamentosService:IApartamentos
    {
        private readonly ApplicationDbContext _context;

        public ApartamentosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Apartamentos>> GetApartamentosAsync()
        {
            return await _context.Apartamentos.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Apartamentos> GetApartamentoByIdAsync(int id)
        {
            return await _context.Apartamentos.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Apartamentos> CreateApartamentoAsync(GestionResidenciaApi.Models.Apartamentos apartamento)
        {
            _context.Apartamentos.Add(apartamento);
            await _context.SaveChangesAsync();
            return apartamento;
        }

        public async Task<Apartamentos?> UpdateApartamentoAsync(int id, ApartamentoCreateDTO dto)
        {
            var existing = await _context.Apartamentos.FindAsync(id);

            if (existing == null)
                return null;

            existing.TorreId = dto.TorreId;
            existing.Numero = dto.Numero;
            existing.Tipo = dto.Tipo;
            existing.Area = dto.Area;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteApartamentoAsync(int id)
        {
            var existente = await _context.Apartamentos.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Apartamentos.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el apartamento porque tiene registros relacionados.");
            }
        }
    }
}
