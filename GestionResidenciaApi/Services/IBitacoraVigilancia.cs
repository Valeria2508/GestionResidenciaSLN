using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IBitacoraVigilancia
    {
        Task<List<GestionResidenciaApi.Models.BitacoraVigilancia>> GetBitacoraVigilanciaAsync();
        Task<GestionResidenciaApi.Models.BitacoraVigilancia> GetBitacoraVigilanciaByIdAsync(int id);
        Task<GestionResidenciaApi.Models.BitacoraVigilancia> CreateBitacoraVigilanciaAsync(GestionResidenciaApi.Models.BitacoraVigilancia bitacora);
        Task<BitacoraVigilancia?> UpdateBitacoraVigilanciaAsync(int id, BitacoraVigilanciaDTO dto);
        Task<bool> DeleteBitacoraVigilanciaAsync(int id);
    }
}
