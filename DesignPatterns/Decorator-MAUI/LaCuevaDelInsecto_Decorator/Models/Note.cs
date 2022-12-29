using System;
namespace LaCuevaDelInsecto.Models
{
    public class Note
    {
        public string FilePath { get; set; }
        public string Text { get; set; }
        public bool IsCompressed { get; set; }
        public bool IsEncrypted { get; set; }
    }
}

