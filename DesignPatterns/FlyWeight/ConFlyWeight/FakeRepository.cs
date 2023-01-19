
using LaCuevaDelInsecto.ConFlyWeight.Models;

namespace LaCuevaDelInsecto.ConFlyWeight
{

    internal class FakeRepository
    {
        private readonly string[] colors = new string[] { 
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

        private readonly FlyWeightFactory flyWeightFactory = new ();

        public List<IntrinsecCarData> GetCars(int amount) 
        {
            List<IntrinsecCarData> cars = new();
            Random random = new();

            for (int i = 0; i < amount; i++)
            {
                cars.Add(
                    new IntrinsecCarData
                    {
                        Color = colors[random.Next(0, colors.Length - 1)],
                        ExtrinsecData = flyWeightFactory.GetExtrinsicCarData(
                                "Nissan",
                                "Sentra",
                                "Japón"
                            )
                    }
                );
            }

            return cars;
        }
    }
}
