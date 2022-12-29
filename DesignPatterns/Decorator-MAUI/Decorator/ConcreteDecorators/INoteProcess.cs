using System;
using LaCuevaDelInsecto.ConcreteDecorator.Models;

namespace LaCuevaDelInsecto.Services
{
    public abstract class INoteProcess
	{
        protected string CurrentExtension { get; }

        public INoteProcess(string currentExtension)
        {
            CurrentExtension = currentExtension;
        }

        public static string SavedFilesPath
		{
			get {
                string rootFileDirectory = FileSystem.AppDataDirectory;
                string notesFolderName = "Notes";

                string notesFolderPath = Path.Combine(rootFileDirectory, notesFolderName);

                if (!Directory.Exists(notesFolderPath))
                    Directory.CreateDirectory(notesFolderPath);

				return notesFolderPath;
            }
		}

		public abstract void SaveNote(FileProcessNote note, bool saveFinalResult = true);

		public abstract FileProcessNote LoadNote(string filePath = "");


        public void DeleteNote(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);

                string fileName = Path.GetFileNameWithoutExtension(filePath);

                _ = Directory
                    .EnumerateFiles(SavedFilesPath, "*")
                    .Where(file => file.Contains(fileName))
                    ?.All(file =>
                    {
                        File.Delete(file);
                        return true;
                    });
            }
        }

        protected static void CleanTempFiles(string tempFilesPath)
        {
            Directory
                .EnumerateFiles(tempFilesPath, "*")
                .ToList()
                .ForEach(file =>
                {
                    File.Delete(file);
                });
        }
    }
}

