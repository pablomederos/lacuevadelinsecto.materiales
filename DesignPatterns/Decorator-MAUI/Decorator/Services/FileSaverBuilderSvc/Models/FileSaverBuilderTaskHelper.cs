namespace LaCuevaDelInsecto.Services.FileSaverBuilderSvc.Models
{
    public class FileSaverBuilderTaskHelper
	{
		public int Position { get; set; }
        public Func<FileSaverBuilder> TaskToAdd { get; set; }
    }
}

