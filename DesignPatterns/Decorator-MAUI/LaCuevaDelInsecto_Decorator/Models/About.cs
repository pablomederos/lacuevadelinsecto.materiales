using System;
namespace LaCuevaDelInsecto.Models
{
    internal class About
    {
        public string Title => AppInfo.Name;
        public string Version => $"v{AppInfo.VersionString}";
        public string MoreInfoUrl => "https://pablomederos.github.io/lacuevadelinsecto";
        public string Message => "Esta aplicación fue escrita para el canal de YouTube <br> <strong>La Cueva Del Insecto</strong>";
    }
}

