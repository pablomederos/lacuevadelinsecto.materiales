using System;
using System.ComponentModel.DataAnnotations;
using LaCuevaDelInsecto.StarWarsApiConsumer.Models;

namespace LaCuevaDelInsecto.Facade.Api.Models
{
	public class CharacterDTO
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Height { get; set; }

        [Required]
        public required string Mass { get; set; }

        public static explicit operator Character(CharacterDTO dto)
        {
            return new Character
            {
                Name = dto.Name,
                Height = dto.Height,
                Mass = dto.Mass
            };
        }
    }
}

