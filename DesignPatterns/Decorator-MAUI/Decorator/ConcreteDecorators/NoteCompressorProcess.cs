using System.IO;
using System.IO.Compression;
using LaCuevaDelInsecto.ConcreteDecorator.Models;

namespace LaCuevaDelInsecto.Services
{
    internal class NoteCompressorProcess : INoteProcess
    {

        public static string TempZipFilesPath
        {
            get
            {
                string rootFileDirectory = FileSystem.AppDataDirectory;
                string tempZipFilesName = "ZipTemp";

                string tempZipFilesPath = Path.Combine(rootFileDirectory, tempZipFilesName);

                if (!Directory.Exists(tempZipFilesPath))
                    Directory.CreateDirectory(tempZipFilesPath);

                return tempZipFilesPath;
            }
        }

        private INoteProcess _fileSaver { get; }

        public NoteCompressorProcess(INoteProcess fileSaver): base(".gz")
        {
            _fileSaver = fileSaver;
        }

        public override FileProcessNote LoadNote(string filePath = "")
        {
            if (File.Exists(filePath))
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                string uncompressedFilePath = Path.Combine(TempZipFilesPath, fileName);

                try
                {
                    if (File.Exists(uncompressedFilePath))
                        File.Delete(uncompressedFilePath);

                    using (FileStream compressedFileStream = File.Open(filePath, FileMode.Open))
                    {
                        using FileStream outputFileStream = File.Create(uncompressedFilePath);
                        using var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
                        decompressor.CopyTo(outputFileStream);
                    }

                    FileProcessNote note =  _fileSaver.LoadNote(uncompressedFilePath);
                    note.IsCompressed = true;

                    return note;
                }
                catch(Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    // Debería Loguear esto
                }
            }
            return new FileProcessNote();
        }

        public override void SaveNote(FileProcessNote note, bool saveFinalResult = true)
        {
            _fileSaver.SaveNote(note, false);
            CleanTempFiles(TempZipFilesPath);

            if (File.Exists(note.FilePath))
            {

                string fileName = Path.GetFileName(note.FilePath);

                string compressedFilePath = "";
                if (saveFinalResult)
                    compressedFilePath = Path.Combine(SavedFilesPath, $"{fileName}{CurrentExtension}");
                else
                    compressedFilePath = Path.Combine(TempZipFilesPath, $"{fileName}{CurrentExtension}");

                using (FileStream originalFileStream = File.Open(note.FilePath, FileMode.Open))
                {
                    using FileStream compressedFileStream = File.Create(compressedFilePath);
                    using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
                    originalFileStream.CopyTo(compressor);
                }

                if (!saveFinalResult)
                {
                    File.Delete(note.FilePath);
                    note.FilePath = compressedFilePath;
                }

            }
        }
    }
}

