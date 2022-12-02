using LaCuevaDelInsecto.Bridge.Models;

namespace LaCuevaDelInsecto.Bridge.DBServices.MalaPractica
{
    internal class MSSQLPersonaService
    {
        public void Get(int idPersona)
        {
            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Obteniendo persona con id: {idPersona}, en Sql Server");

            //..
        }

        public void Save(Persona persona)
        {
            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Gurdando {persona} en Sql Server");

            //..
        }

        public void Update(Persona persona)
        {
            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Actualizando {persona} en Sql Server");

            //..
        }

        public void Delete(int idPersona)
        {
            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Eliminando a la persona con id: {idPersona} en Sql Server");

            //...
        }
    }
}
