namespace LaCuevaDelInsecto.Services.NoteProcessBuilderSvc.Models
{
    public class NoteProcessBuilderTaskHelper
	{
		public int Position { get; set; }
        public Func<NoteProcessBuilder> TaskToAdd { get; set; }
    }
}

