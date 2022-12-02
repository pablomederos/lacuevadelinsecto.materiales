using LaCuevaDelInsecto.Bridge.Models;
using LaCuevaDelInsecto.Bridge.Services.Bridge.Abstractions;

namespace LaCuevaDelInsecto.Bridge.Services.Bridge.Implementations
{
    internal class PersonaService: IPersonaService
    {
        private readonly IDbPersonaService _dbPersonaService;

        // Inyectado mediante patrón bridge
        // Sin la ayuda de .Net
        public PersonaService(IDbPersonaService dbPersonaService)
        {
            _dbPersonaService = dbPersonaService;
        }

        // Ahora el código cliente depende de abstacciones y no de
        // implementaciones

        public void Get(int idPersona)
        {

            // Validaciones del modelo
            // lógica de negocio
            // ...

            _dbPersonaService.Get(idPersona);
        }

        public void Save(Persona persona)
        {

            // Validaciones del modelo
            // lógica de negocio
            // ...

            _dbPersonaService.Save(persona);
        }

        public void Update(Persona persona)
        {

            // Validaciones del modelo
            // lógica de negocio
            // ...

            _dbPersonaService.Update(persona);
        }

        public void Delete(int idPersona)
        {

            // Validaciones del modelo
            // lógica de negocio
            // ...

            _dbPersonaService.Delete(idPersona);
        }
    }
}
