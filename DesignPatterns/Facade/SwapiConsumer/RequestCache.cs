using System;
using System.Collections.Concurrent;
using System.Text.Json;
using LaCuevaDelInsecto.StarWarsApiConsumer.Models;

namespace LaCuevaDelInsecto.StarWarsApiConsumer
{
	public class RequestCache
	{
		private static readonly BlockingCollection<RequestResultElement> cachedElements = new();

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static bool TrySaveRequestCache<T>(uint id, T result)
		{
			if (result == null)
				throw new ArgumentNullException(paramName: nameof(result), "Result no puede ser nulo");

			if(!cachedElements.Any(
				elem =>
					typeof(T).Name == elem.Type.Name
					&& id == elem.Id )
				)
			{
				cachedElements.Add(
						new RequestResultElement
						{
							Id = id,
							Type = result.GetType(),
							Data = JsonSerializer.Serialize(result)
						}
					);

                return true;
            }

			return false;
		}

		public static T? GetCached<T>(uint id)
        {
			return cachedElements
				.Where(elem =>
					typeof(T).Name == elem.Type.Name && elem.Id == id
				)
				.Select(
					elem => JsonSerializer.Deserialize<T>(elem.Data)
				)
				.FirstOrDefault();
        }
    }
}