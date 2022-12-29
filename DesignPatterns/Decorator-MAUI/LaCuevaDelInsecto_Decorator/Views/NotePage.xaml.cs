using LaCuevaDelInsecto.Models;
using LaCuevaDelInsecto.ConcreteDecorator.Models;
using LaCuevaDelInsecto.Services.NoteProcessBuilderSvc;

namespace LaCuevaDelInsecto.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public string ItemId
    {
        set { LoadNote(value); }
    }

    private readonly NoteProcessBuilder _noteProcessBuilder;

    public NotePage()
    {
        _noteProcessBuilder = new NoteProcessBuilder(); // No necesito romper este acomplamiento

        LoadNote();

        InitializeComponent();
    }

    void LoadNote(string filePath = "")
    {
        FileProcessNote noteContent = _noteProcessBuilder
                .GetBuildedNoteProcess(filePath).LoadNote(filePath);

        if (!string.IsNullOrWhiteSpace(filePath))
            DeleteButton.IsEnabled = true;

        Note note = new()
        {
            FilePath = noteContent?.FilePath ?? "",
            Text = noteContent?.Text ?? "",
            IsEncrypted = noteContent?.IsEncrypted ?? false,
            IsCompressed = noteContent?.IsCompressed ?? false,
        };

        BindingContext = note;
    }

    async void SaveButton_Clicked(object sender, EventArgs e)
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
            
            var fileSaverBuilder = _noteProcessBuilder;

            if (note.IsCompressed)
                fileSaverBuilder.AddCompression();
            if (note.IsEncrypted)
                fileSaverBuilder.AddEncryption();

            fileSaverBuilder.Build().SaveNote(mNote);
        }

        await Shell.Current.GoToAsync("..");
    }

    void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if(BindingContext is Note note)
        {
            if (string.IsNullOrWhiteSpace(note.FilePath))
                return;

            _noteProcessBuilder.Build().DeleteNote(note.FilePath);
        }

        Shell.Current.GoToAsync("..");
    }

    void IsCompressedCheckbox_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        ((Note) BindingContext).IsCompressed = e.Value;
    }
    void IsEncryptedCheckbox_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        ((Note)BindingContext).IsEncrypted = e.Value;
    }
}
