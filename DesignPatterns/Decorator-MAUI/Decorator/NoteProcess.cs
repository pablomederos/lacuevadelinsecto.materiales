
using System.Text.RegularExpressions;
using LaCuevaDelInsecto.ConcreteDecorator.Models;

namespace LaCuevaDelInsecto.Services
{
    // Clase wrappeable
    internal class NoteProcess : INoteProcess
    {
        public static string FILE_NAME_SEPARATOR = "_-_";

        public static string TempTxtFilesPath
        {
            get
            {
                string rootFileDirectory = FileSystem.AppDataDirectory;
                string tempZipFilesName = "TxtTemp";

                string tempZipFilesPath = Path.Combine(rootFileDirectory, tempZipFilesName);

                if (!Directory.Exists(tempZipFilesPath))
                    Directory.CreateDirectory(tempZipFilesPath);

                return tempZipFilesPath;
            }
        }

        public NoteProcess() : base(".txt")
        { }

        public override FileProcessNote LoadNote(string filePath = "")
        {
            if (File.Exists(filePath))
                return new FileProcessNote
                {
                    Text = File.ReadAllText(filePath),
                    FilePath = filePath
                };

            return new FileProcessNote();
        }

        public override void SaveNote(FileProcessNote note, bool saveFinalResult = true)
        {
            CleanTempFiles(TempTxtFilesPath);

            string fileName = Path.GetFileNameWithoutExtension(note.FilePath ?? "")?.Split(FILE_NAME_SEPARATOR)?.Length switch
            {
                2 => $"{NoteProcess.CreateReducedName(note.Text)}{FILE_NAME_SEPARATOR}{Path.GetFileNameWithoutExtension(note.FilePath).Split(FILE_NAME_SEPARATOR)[1]}",
                _ => $"{NoteProcess.CreateReducedName(note.Text)}{FILE_NAME_SEPARATOR}{Path.GetRandomFileName()}"
            };

            string tempFilePath = Path.Combine(TempTxtFilesPath, $"{fileName}{CurrentExtension}");

            if (!string.IsNullOrWhiteSpace(note.FilePath))
                Directory
                    .EnumerateFiles(SavedFilesPath, "*")
                    .Where(file => file.Contains(
                        Path.GetFileNameWithoutExtension(note.FilePath ?? "")
                    ))
                    .ToList()
                    .ForEach(file => File.Delete(file));

            File.WriteAllText(tempFilePath, note.Text);

            if (File.Exists(note.FilePath) && !tempFilePath.Equals(note.FilePath))
                File.Delete(note.FilePath);

            if (saveFinalResult)
            {
                string newFilePath = Path.Combine(SavedFilesPath, $"{fileName}{CurrentExtension}");

                File.Move(tempFilePath, newFilePath, true);
            }
            else
                note.FilePath = tempFilePath;
        }

        private static string CreateReducedName(string text)
        {
            string summary = text.Trim();
            int summaryLength = 25;

            Regex rgx = new Regex("[^a-zA-Z0-9\\s-]");
            summary = rgx.Replace(summary, "").Trim();

            if (summary.Length > summaryLength)
                summary = summary.Substring(0, summaryLength);
            else if (summary.Length == 0)
                summary = "Empty String";

            return summary;
        }
    }
}

