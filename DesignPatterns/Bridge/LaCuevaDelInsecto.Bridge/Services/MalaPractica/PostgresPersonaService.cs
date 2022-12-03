using LaCuevaDelInsecto.Bridge.Models;

namespace LaCuevaDelInsecto.Bridge.DBServices.MalaPractica
{
    internal class PostgresPersonaService
    {
        public void Get(int idPersona)
        {

            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Obteniendo persona con id: {idPersona}, en postgres");

            //...
            // Retorno valor
        }

        public void Save(Persona persona)
        {

            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Gurdando {persona} en postgres");

            //...
        }

        public void Update(Persona persona)
        {

            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Actualizando {persona} en postgres");

            //...
        }

        public void Delete(int idPersona)
        {

            // Validaciones del modelo
            // lógica de negocio
            // ...

            // Lógica de base de datos
            Console.WriteLine($"Eliminando a la persona con id: {idPersona} en postgres");

            //...
        }
    }
}
