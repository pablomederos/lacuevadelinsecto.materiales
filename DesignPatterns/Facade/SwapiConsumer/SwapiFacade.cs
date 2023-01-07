using System;
using LaCuevaDelInsecto.StarWarsApiConsumer.Models;

namespace LaCuevaDelInsecto.StarWarsApiConsumer
{
	public class SwapiFacade
	{
        private readonly SwapiClient _swapiClient;

        public SwapiFacade()
        {
            _swapiClient = new SwapiClient();
        }

        public T Get<T>(uint id)
        {
            try
            {
                if (
                    RequestCache.GetCached<T>(id) is var result
                    && result != null
                )
                    {
                        return result;
                    }

                Func<uint, object> operation = GetOperation<T>();

                result = (T)operation(id);

                RequestCache.TrySaveRequestCache<T>(id, result);

                return result;
            }
            catch
            {
                // Loggear esta excepción
                throw;
            }
        }

        public uint Save<T>(T element)
        {
            try
            {

                uint id = (uint)new Guid().ToString().GetHashCode();

                _swapiClient.Save<T>(id, element); // Falso guardado

                _ = RequestCache.TrySaveRequestCache<T>(
                    id,
                    element
                );

                return id;
            }
            catch
            {
                // Loggear esta excepción
                throw;
            }
        }

        private Func<uint, object> GetOperation<T>()
        {
            return typeof(T).Name switch
            {
                nameof(Character) => _swapiClient.GetPeople,
                nameof(Planet) => _swapiClient.GetPlanet,
                nameof(Starship) => _swapiClient.GetStarship,
                _ => throw new InvalidOperationException()
            };
        }
    }
}

