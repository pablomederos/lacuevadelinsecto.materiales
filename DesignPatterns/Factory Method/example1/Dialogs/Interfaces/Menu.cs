
namespace FactoryMethod.Dialogs.Interfaces
{
    public abstract class Menu
    {
        // Menú personalizable según el rol de usuario
        public string[] options = new string[]{};

        public void buildMenu()
        {
            foreach (var item in this.options)
            {
                Console.WriteLine($"{item}\n");
            }
        }
    }
}