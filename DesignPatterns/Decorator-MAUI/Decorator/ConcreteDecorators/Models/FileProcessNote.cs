using System;
namespace LaCuevaDelInsecto.ConcreteDecorator.Models
{
	public class FileProcessNote
	{

		public string FilePath { get; set; }
		public bool IsEncrypted { get; set; } = false;
		public bool IsCompressed { get; set; } = false;
		public string Text { get; set; }
	}
}

