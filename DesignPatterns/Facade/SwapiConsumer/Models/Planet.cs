using System;
namespace LaCuevaDelInsecto.StarWarsApiConsumer.Models
{
	public class Planet
	{
        public string Name { get; set; } = string.Empty;
        public string RotationPeriod { get; set; } = string.Empty;
        public string OrbitalPeriod { get; set; } = string.Empty;
        public string Diameter { get; set; } = string.Empty;
        public string Climate { get; set; } = string.Empty;
        public string Gravity { get; set; } = string.Empty;
        public string Terrain { get; set; } = string.Empty;
        public string SurfaceWater { get; set; } = string.Empty;
        public string Population { get; set; } = string.Empty;
        public List<string>? Residents { get; set; }
        public List<string>? Films { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Edited { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}

