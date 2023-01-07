using System;

namespace LaCuevaDelInsecto.StarWarsApiConsumer.Models
{
    public class Character
    {
        public string Name { get; set; } = string.Empty;

        public string Height { get; set; } = string.Empty;

        public string Mass { get; set; } = string.Empty;

        public string HairColor { get; set; } = string.Empty;

        public string SkinColor { get; set; } = string.Empty;

        public string EyeColor { get; set; } = string.Empty;

        public string BirthYear { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Homeworld { get; set; } = string.Empty;

        public List<string>? Films { get; set; }

        public List<string>? Species { get; set; }

        public List<string>? Vehicles { get; set; }

        public List<string>? Starships { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Edited { get; set; }

        public string Url { get; set; } = string.Empty;
    }


}

