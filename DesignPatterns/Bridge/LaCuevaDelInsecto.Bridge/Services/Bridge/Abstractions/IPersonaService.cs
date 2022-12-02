using LaCuevaDelInsecto.Bridge.Models;

namespace LaCuevaDelInsecto.Bridge.Services.Bridge.Abstractions
{
    public interface IPersonaService
    {
        void Get(int idPersona);

        void Save(Persona persona);

        void Update(Persona persona);

        void Delete(int idPersona);
    }
}
