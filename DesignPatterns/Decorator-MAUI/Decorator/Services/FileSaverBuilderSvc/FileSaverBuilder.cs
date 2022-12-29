using System;
using LaCuevaDelInsecto.ConcreteDecorator.Models;
using LaCuevaDelInsecto.Services.FileSaverBuilderSvc.Models;

namespace LaCuevaDelInsecto.Services.FileSaverBuilderSvc
{
    public class FileSaverBuilder
    {
		private readonly List<Type> FileSaverLayers = new ();

		public FileSaverBuilder()
		{}

		public FileSaverBuilder AddCompression()
		{
			FileSaverLayers.Add(typeof(NoteCompressorProcess));
			return this;
		}

        public FileSaverBuilder AddEncryption()
        {
            FileSaverLayers.Add(typeof(NoteEncryptionProcess ));
            return this;
        }

        public INoteProcess Build()
		{
			INoteProcess fileSaver = new NoteProcess();

			foreach(Type saver in FileSaverLayers)
			{
				fileSaver = (INoteProcess) Activator.CreateInstance(saver, fileSaver);
			}


            FileSaverLayers.Clear();
			return fileSaver;
		}

        public INoteProcess BuildedFileSaver(string filePath)
        {
			if (!string.IsNullOrWhiteSpace(filePath))
			{

				List<FileSaverBuilderTaskHelper> taskList = new();

                int compressedPosition = filePath.IndexOf(".gz");
                if (compressedPosition >= 0)
                    taskList.Add(new FileSaverBuilderTaskHelper
                    {
                        Position = compressedPosition,
                        TaskToAdd = AddCompression
                    });

                int encryptPosition = filePath.IndexOf(".pgp");
                if (encryptPosition >= 0)
                    taskList.Add(new FileSaverBuilderTaskHelper
                    {
                        Position = encryptPosition,
                        TaskToAdd = AddEncryption
                    });

                taskList = taskList.OrderBy(elem => elem.Position).ToList();

				foreach (var elem in taskList)
					elem.TaskToAdd();
			}

            return Build();
        }
    }
}

