using LaCuevaDelInsecto.Services;
using LaCuevaDelInsecto.Services.FileNotesLoaderSvc;
using LaCuevaDelInsecto.Services.FileNotesLoaderSvc.Models;

namespace LaCuevaDelInsecto.Views;

public partial class AllNotesPage : ContentPage
{

    public AllNotesPage()
	{
		InitializeComponent();

		BindingContext = new FileNotesLoader(); // No necesito romper este acomplamiento
    }

    protected override void OnAppearing()
    {
		((FileNotesLoader)BindingContext).LoadNotes();
    }

    async void Add_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    async void notesCollection_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection.Count != 0)
        {
            NoteFileInfo note = (NoteFileInfo)e.CurrentSelection[0];

            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.FilePath}");

            notesCollection.SelectedItem = null;
        }
    }
}
