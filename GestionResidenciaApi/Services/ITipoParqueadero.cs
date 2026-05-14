using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface ITipoParqueadero
    {
        Task<List<GestionResidenciaApi.Models.TipoParqueadero>> GetTipoParqueaderoAsync();
        Task<GestionResidenciaApi.Models.TipoParqueadero> GetTipoParqueaderoByIdAsync(int id);
        Task<GestionResidenciaApi.Models.TipoParqueadero> CreateTipoParqueaderoAsync(GestionResidenciaApi.Models.TipoParqueadero tipoParqueadero);
        Task<GestionResidenciaApi.Models.TipoParqueadero?> UpdateTipoParqueaderoAsync(int id, TipoParqueaderoCreateDTO dto);
        Task<bool> DeleteTipoParqueaderoAsync(int id);
    }
}
