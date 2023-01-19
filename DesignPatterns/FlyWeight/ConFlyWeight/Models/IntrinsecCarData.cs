namespace LaCuevaDelInsecto.ConFlyWeight.Models
{
    internal class IntrinsecCarData
    {
        public object Id { get; } = Guid.NewGuid();

        public required string Color { get; set; }
        public required ExtrinsicCarData ExtrinsecData { get; init; }
    }
}

