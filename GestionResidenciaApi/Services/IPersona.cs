using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Services
{
    public interface IPersona
    {
        Task<List<Persona>> GetPersonaAsync();
        Task<Persona?> GetPersonaByIdAsync(int id);
        Task<Persona> CreatePersonaAsync(Persona persona);
        Task<Persona?> UpdatePersonaAsync(int id, Persona persona);
        Task<bool> DeletePersonaAsync(int id);
    }
}
