using LaCuevaDelInsecto.Services.NoteProcessBuilderSvc.Models;

namespace LaCuevaDelInsecto.Services.NoteProcessBuilderSvc
{
    public class NoteProcessBuilder
    {
		private readonly List<Type> FileSaverLayers = new ();

		public NoteProcessBuilder()
		{}

		public NoteProcessBuilder AddCompression()
		{
			FileSaverLayers.Add(typeof(NoteCompressorProcess));
			return this;
		}

        public NoteProcessBuilder AddEncryption()
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

        public INoteProcess GetBuildedNoteProcess(string filePath)
        {
			if (!string.IsNullOrWhiteSpace(filePath))
			{

				List<NoteProcessBuilderTaskHelper> taskList = new();

                int compressedPosition = filePath.IndexOf(".gz");
                if (compressedPosition >= 0)
                    taskList.Add(new NoteProcessBuilderTaskHelper
                    {
                        Position = compressedPosition,
                        TaskToAdd = AddCompression
                    });

                int encryptPosition = filePath.IndexOf(".pgp");
                if (encryptPosition >= 0)
                    taskList.Add(new NoteProcessBuilderTaskHelper
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

