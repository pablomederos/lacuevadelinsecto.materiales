using FactoryMethod.Dialogs.Interfaces;

namespace FactoryMethod.Dialogs.Implementation
{
    public class AdminDialog: Dialog // Herencia
    {
        private ConsoleColor CustomUserBackgroundColor = ConsoleColor.Red; // Rojo
        // public... otras personalizaciones....

        public AdminDialog()
        {
            // Agrego mi comportamiento personalizado para el diálogo de Admin
            // com aplicar colores, etc..
            Console.ForegroundColor = CustomUserBackgroundColor;
        }
        
        // Obtengo solo las opciones de menú para un administrador
        public override Menu CreateOptionMenu() => new AdminMenu();
    }
}