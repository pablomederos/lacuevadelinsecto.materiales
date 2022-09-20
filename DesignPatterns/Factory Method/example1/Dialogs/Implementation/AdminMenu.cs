using FactoryMethod.Dialogs.Interfaces;

namespace FactoryMethod.Dialogs.Implementation
{
    public class AdminMenu : Menu // Herencia
    {
        public AdminMenu()
        {
            this.options = new string[] { "Crear", "Actualizar", "Eliminar" };
            // DoSomething();
            // Podriamos tener un comportamiento personalizado
            // para este elemento de menú
        }

        // private void DoSomething() {}
    }
}