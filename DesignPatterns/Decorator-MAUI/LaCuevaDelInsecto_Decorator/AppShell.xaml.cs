using LaCuevaDelInsecto.Views;

namespace LaCuevaDelInsecto;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));
	}
}

