using System;
using System.Collections.ObjectModel;
using LaCuevaDelInsecto.Services.FileNotesLoaderSvc.Models;

namespace LaCuevaDelInsecto.Services.FileNotesLoaderSvc
{
	public class FileNotesLoader
	{
        public ObservableCollection<NoteFileInfo> Notes { get; set; } = new ObservableCollection<NoteFileInfo>();

        public void LoadNotes()
        {
            Notes.Clear();

            string appDirectory = Services.INoteProcess.SavedFilesPath;

            IEnumerable<NoteFileInfo> notes = Directory
                .EnumerateFiles(appDirectory, "*")
                ?.Select(file => new NoteFileInfo
                {
                    FileName = $"{Path.GetFileNameWithoutExtension(file).Split(NoteProcess.FILE_NAME_SEPARATOR)[0]}...",
                    FileExtension = Path.GetExtension(file).Replace('.', ' ').Trim().ToUpper(),
                    FilePath = file,
                    Date = File.GetCreationTime(file)
                })
                ?.OrderByDescending(file => file.Date) ?? Enumerable.Empty<NoteFileInfo>();

            foreach (NoteFileInfo note in notes)
                Notes.Add(note);
        }
    }
}

