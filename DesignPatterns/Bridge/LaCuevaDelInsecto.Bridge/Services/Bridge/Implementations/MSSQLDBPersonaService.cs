using LaCuevaDelInsecto.Bridge.Models;
using LaCuevaDelInsecto.Bridge.Services.Bridge.Abstractions;

namespace LaCuevaDelInsecto.Services.Bridge.Implementations
{
    internal class MSSQLDBPersonaService: IDbPersonaService
    {
        public void Get(int idPersona)
        {
            // Únicamente lógica de base de datos

            Console.WriteLine($"Obteniendo persona con id: {idPersona}, en SqlServer");
            // Retorno valor
        }

        public void Save(Persona persona)
        {
            // Únicamente lógica de base de datos

            Console.WriteLine($"Gurdando {persona} en SqlServer");
        }

        public void Update(Persona persona)
        {
            // Únicamente lógica de base de datos

            Console.WriteLine($"Actualizando {persona} en SqlServer");
        }

        public void Delete(int idPersona)
        {
            // Únicamente lógica de base de datos

            Console.WriteLine($"Eliminando a la persona con id: {idPersona} en SqlServer");
        }
    }
}
