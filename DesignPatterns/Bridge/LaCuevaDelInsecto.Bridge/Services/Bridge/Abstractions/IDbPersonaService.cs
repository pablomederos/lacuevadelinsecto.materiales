using LaCuevaDelInsecto.Bridge.Models;

namespace LaCuevaDelInsecto.Bridge.Services.Bridge.Abstractions
{
    internal interface IDbPersonaService
    {
        void Get(int idPersona);

        void Save(Persona persona);

        void Update(Persona persona);

        void Delete(int idPersona);
    }
}
