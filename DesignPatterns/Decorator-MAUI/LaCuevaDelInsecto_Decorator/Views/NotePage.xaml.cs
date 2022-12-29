using LaCuevaDelInsecto.Models;
using LaCuevaDelInsecto.ConcreteDecorator.Models;
using LaCuevaDelInsecto.Services.FileSaverBuilderSvc;
using LaCuevaDelInsecto.Services.FileSaverBuilderSvc.Models;

namespace LaCuevaDelInsecto.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public string ItemId
    {
        set { LoadNote(value); }
    }

    private readonly FileSaverBuilder _fileSaverBuilder;

    public NotePage()
    {
        _fileSaverBuilder = new FileSaverBuilder(); // No necesito romper este acomplamiento

        LoadNote();

        InitializeComponent();
    }

    void LoadNote(string filePath = "")
    {
        FileProcessNote noteContent = _fileSaverBuilder
                .BuildedFileSaver(filePath).LoadNote(filePath);

        if (!string.IsNullOrWhiteSpace(filePath))
            DeleteButton.IsEnabled = true;

        Models.Note note = new Models.Note
        {
            FilePath = noteContent?.FilePath ?? "",
            Text = noteContent?.Text ?? "",
            IsEncrypted = noteContent?.IsEncrypted ?? false,
            IsCompressed = noteContent?.IsCompressed ?? false,
        };

        BindingContext = note;
    }

    async void SaveButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (BindingContext is Note note)
        {
            if (string.IsNullOrWhiteSpace(TextEditor.Text))
                return;

            var mNote = new FileProcessNote
            {
                Text = TextEditor.Text,
                FilePath = note.FilePath,
                IsEncrypted = note.IsEncrypted,
                IsCompressed = note.IsCompressed
            };

            string filePath = note.FilePath;
            var fileSaverBuilder = _fileSaverBuilder;

            if (note.IsCompressed)
                fileSaverBuilder.AddCompression();
            if (note.IsEncrypted)
                fileSaverBuilder.AddEncryption();

            fileSaverBuilder.Build().SaveNote(mNote);
        }

        await Shell.Current.GoToAsync("..");
    }

    void DeleteButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if(BindingContext is Note note)
        {
            if (string.IsNullOrWhiteSpace(note.FilePath))
                return;

            _fileSaverBuilder.Build().DeleteNote(note.FilePath);
        }

        Shell.Current.GoToAsync("..");
    }

    void isCompressedCheckbox_OnCheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        ((Note) BindingContext).IsCompressed = e.Value;
    }
    void isEncryptedCheckbox_OnCheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        ((Note)BindingContext).IsEncrypted = e.Value;
    }
}
