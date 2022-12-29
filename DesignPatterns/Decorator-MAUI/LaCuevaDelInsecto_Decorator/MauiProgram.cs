using LaCuevaDelInsecto.Services;
using LaCuevaDelInsecto.Views;

namespace LaCuevaDelInsecto;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("open_sans_regular.ttf", "OpenSansRegular");
				fonts.AddFont("open_sans_semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}

