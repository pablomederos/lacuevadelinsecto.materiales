namespace FactoryMethod.Dialogs.Interfaces
{
    public abstract class Dialog
    {
        // Método que se usará como Factory o Fábrica de nuestro menú
        public abstract Menu CreateOptionMenu();

        public void Render()
        {
            Menu menu = this.CreateOptionMenu();

            menu.buildMenu();
        }
    }
}