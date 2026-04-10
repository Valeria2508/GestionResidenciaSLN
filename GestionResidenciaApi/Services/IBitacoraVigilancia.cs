using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IBitacoraVigilancia
    {
        Task<List<GestionResidenciaApi.Models.BitacoraVigilancia>> GetBitacoraVigilanciaAsync();
        Task<GestionResidenciaApi.Models.BitacoraVigilancia> GetBitacoraVigilanciaByIdAsync(int id);
        Task<GestionResidenciaApi.Models.BitacoraVigilancia> CreateBitacoraVigilanciaAsync(GestionResidenciaApi.Models.BitacoraVigilancia bitacora);
        Task<GestionResidenciaApi.Models.BitacoraVigilancia> UpdateBitacoraVigilanciaAsync(int id, GestionResidenciaApi.Models.BitacoraVigilancia bitacora);
        Task<bool> DeleteBitacoraVigilanciaAsync(int id);
    }
}
