using System;
namespace LaCuevaDelInsecto.Services.FileNotesLoaderSvc.Models
{
	public class NoteFileInfo
	{
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime Date { get; set; }
        public string FileExtension { get; set; }
    }
}