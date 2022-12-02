using LaCuevaDelInsecto.Bridge.Models;

namespace LaCuevaDelInsecto.Bridge.DBServices.MalaPractica
{
    internal class MySqlPersonaService
    {
        public void Get(int idPersona)
        {
            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Obteniendo persona con id: {idPersona}, en MySql");

            // ...

            // Retorno valor
        }

        public void Save(Persona persona)
        {
            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Gurdando {persona} en MySql");

            // ...
        }

        public void Update(Persona persona)
        {
            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Actualizando {persona} en MySql");

            // ...
        }

        public void Delete(int idPersona)
        {
            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Eliminando a la persona con id: {idPersona} en MySql");

            // ...
        }
    }
}
