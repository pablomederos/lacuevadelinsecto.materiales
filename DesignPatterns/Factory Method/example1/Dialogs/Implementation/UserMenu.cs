using FactoryMethod.Dialogs.Interfaces;

namespace FactoryMethod.Dialogs.Implementation
{
    public class UserMenu : Menu // Herencia
    {
        public UserMenu()
        {
            this.options = new string[] { "Crear", "Actualizar" };

            // DoSomething();
            // Podriamos tener un comportamiento personalizado
            // para este elemento de menú
        }

        // private void DoSomething() {}
    }
}