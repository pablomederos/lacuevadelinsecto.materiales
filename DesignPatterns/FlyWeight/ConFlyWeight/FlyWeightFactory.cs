
using LaCuevaDelInsecto.ConFlyWeight.Models;

namespace LaCuevaDelInsecto.ConFlyWeight
{
    internal class FlyWeightFactory
    {
        public readonly Dictionary<string, ExtrinsicCarData> CarDataCache;

        public FlyWeightFactory()
        {
            CarDataCache = new Dictionary<string, ExtrinsicCarData>();
        }

        public ExtrinsicCarData GetExtrinsicCarData(string marca, string modelo, string origen)
        {
            string key = $"{marca},{modelo},{origen}";

            if (!CarDataCache.TryGetValue(key, out ExtrinsicCarData? carData))
            {

                carData = new ExtrinsicCarData
                {
                    Marca = marca,
                    Modelo = modelo,
                    Origen = origen
                };

                CarDataCache[key] = carData;
            }

            return carData;
        }
    }
}
