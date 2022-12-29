namespace LaCuevaDelInsecto.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    async void LearnMore_Clicked(System.Object sender, System.EventArgs e)
    {
		if (BindingContext is Models.About about)
			await Launcher.Default.OpenAsync(about.MoreInfoUrl);
    }
}
