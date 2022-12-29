using System;
using LaCuevaDelInsecto.ConcreteDecorator.Models;

namespace LaCuevaDelInsecto.Services
{
	internal class NoteEncryptionProcess : INoteProcess
    {

        private INoteProcess _noteProcess { get; }

        public static string TempEcryptedFilesPath
        {
            get
            {
                string rootFileDirectory = FileSystem.AppDataDirectory;
                string tempZipFilesName = "EcryptedTemp";

                string tempZipFilesPath = Path.Combine(rootFileDirectory, tempZipFilesName);

                if (!Directory.Exists(tempZipFilesPath))
                    Directory.CreateDirectory(tempZipFilesPath);

                return tempZipFilesPath;
            }
        }

        public NoteEncryptionProcess (INoteProcess noteProcess): base(".pgp")
        {
            _noteProcess = noteProcess;
        }

        public override FileProcessNote LoadNote(string filePath = "")
        {
            if(File.Exists(filePath))
            {
                //if(!Path.GetExtension(filePath).Equals(CurrentExtension)) // Debería controlar esto 
                    //throw a new exception
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                string newFilePath = Path.Combine(TempEcryptedFilesPath, fileName);

                File.Copy(filePath, newFilePath, true);

                FileProcessNote note = _noteProcess.LoadNote(newFilePath);
                note.IsEncrypted = true;

                return note;
            }
            return null;
        }

        public override void SaveNote(FileProcessNote note, bool saveFinalResult = true)
        {
            _noteProcess.SaveNote(note, false);

            CleanTempFiles(TempEcryptedFilesPath);

            if (!string.IsNullOrWhiteSpace(note.FilePath))
            {

                string fileName = Path.GetFileName(note.FilePath);

                string newFilePath = Path.Combine(Path.GetDirectoryName(note.FilePath), $"{fileName}{CurrentExtension}");

                if (File.Exists(note.FilePath))
                    File.Move(note.FilePath, newFilePath, true);

                if (saveFinalResult)
                {
                    string encryptedName = Path.GetFileName(newFilePath);
                    File.Move(newFilePath, Path.Combine(SavedFilesPath, encryptedName), true);
                }
                else
                    note.FilePath = newFilePath;
            }
        }
    }
}

