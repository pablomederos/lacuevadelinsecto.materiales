using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaCuevaDelInsecto.SinFlyWeight.Models;

namespace LaCuevaDelInsecto.SinFlyWeight
{

    internal class FakeRepository
    {
        string[] colors = new string[] { 
            "Azul",
            "Rojo",
            "Verde",
            "Amarillo",
            "Violeta",
            "Marrón",
            "Beige",
            "Bordeaux",
            "Garante",
            "Cyan"
        };

        public List<Car> GetCars(int amount) 
        {
            List<Car> cars = new();
            Random random = new();

            for (int i = 0; i < amount; i++)
            {
                cars.Add(
                    new Car
                    {
                        Color = colors[random.Next(0, colors.Length - 1)],
                        Marca = "Nissan",
                        Modelo = "Sentra",
                        Origen = "Japón"
                    }
                );
            }

            return cars;
        }
    }
}
