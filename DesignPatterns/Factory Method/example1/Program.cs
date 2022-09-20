using FactoryMethod.Dialogs.Interfaces;
using FactoryMethod.Dialogs.Implementation;

string role = "USER";

Dialog dialog;

// De acuerdo con el rol se fabricará un objeto u otro
// compatible con la superclase
if (role.Equals("ADMIN"))
{
    dialog = new AdminDialog();
}
else if (role.Equals("USER"))
{
    dialog = new UserDialog();
}
else throw new Exception("Rol de usuario no admitido");

dialog.Render();

// De este modo además será más fácil añadir un diálogo para un rol extra
// simplemente heredando la clase abstracta Dialog
// y también creando un menú personalizado.
// Si añadimos un Auditor, incluso podemos personalizar el diálogo heredado
// de la clase Dialog, pero seguir creando el menú con la clase ya heredada
// UserMenu por ejemplo, o crear una a partir de la herencia.