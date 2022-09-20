using FactoryMethod.Dialogs.Interfaces;

namespace FactoryMethod.Dialogs.Implementation
{
    public class UserDialog: Dialog // Herencia
    {
        private ConsoleColor CustomUserTextColor = ConsoleColor.Green; // Verde
        // public... otras personalizaciones....

        public UserDialog()
        {
            // Agrego mi comportamiento personalizado para el diálogo de User
            // com aplicar colores, etc..
            Console.ForegroundColor = this.CustomUserTextColor;
        }
        
        // Obtengo solo las opciones de menú para un administrador
        public override Menu CreateOptionMenu() => new UserMenu();
    }
}