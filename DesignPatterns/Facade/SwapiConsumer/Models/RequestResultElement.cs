using System;
namespace LaCuevaDelInsecto.StarWarsApiConsumer.Models
{
	public class RequestResultElement
	{
		public required uint Id { get; init; }
		public required Type Type { get; init; }
		public required string Data { get; init; }
	}
}

