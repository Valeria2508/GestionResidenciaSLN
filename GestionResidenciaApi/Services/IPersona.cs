using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IPersona
    {
        Task<List<GestionResidenciaApi.Models.Persona>> GetPersonaAsync();
        Task<GestionResidenciaApi.Models.Persona> GetPersonaByIdAsync(int id);
        Task<GestionResidenciaApi.Models.Persona> CreatePersonaAsync(GestionResidenciaApi.Models.Persona persona);
        Task<GestionResidenciaApi.Models.Persona> UpdatePersonaAsync(int id, GestionResidenciaApi.Models.Persona persona);
        Task<bool> DeletePersonaAsync(int id);
    }
}
