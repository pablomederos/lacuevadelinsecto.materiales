namespace LaCuevaDelInsecto.SinFlyWeight.Models
{
    public class Car
    {
        public object Id { get; } = Guid.NewGuid();

        public required string Marca { get; init; }
        public required string Modelo { get; init; }
        public required string Origen { get; init; }


        public required string Color { get; set; }
    }
}

