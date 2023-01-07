using System;
using System.Net.Http.Json;
using System.Text.Json;
using LaCuevaDelInsecto.StarWarsApiConsumer.Models;
using LaCuevaDelInsecto.StarWarsApiConsumer.Helpers;

namespace LaCuevaDelInsecto.StarWarsApiConsumer;

public class SwapiClient
{
    // No deberían existir múltiples instancias de un HttpClient
    // que apunten a los mismos endpoints o servidor.
    private readonly HttpClient httpClient;

    public SwapiClient()
    {
        httpClient = HttpSwapiClient.HttpClient;
    }

    public Character GetPeople(uint id)
    {
        Character result = DoGet<Character>($"people/{id}");
        return result;
    }

    public Planet GetPlanet(uint id)
    {
        return DoGet<Planet>($"planets/{id}");
    }

    public Starship GetStarship(uint id)
    {
        return DoGet<Starship>($"starships/{id}");
    }

    internal void Save<T>(uint id, T character)
    {
        // throw new NotImplementedException();
        // Eventual guardado si tuvieramos permiso.
    }

    private T DoGet<T>(string urlPath)
    {
        try
        {
            T? response = httpClient.GetFromJsonAsync<T>(urlPath).Result;

            if (response != null)
                return response;

            throw new Exception("No se pudo obtener el resultado");
        }
        catch // No se recomienda usar tipos reservados
        {
            // Esto debería ser manejado, pero para este ejemplo no es necesario.
            // Se esperan al menos:
                //  AggregateException
                //  ArgumentNulException
                //  JsonException
                //  NotSupportedException
                //  InvalidOperationException
                //  HttpRequestException
                //  TaskCancelledException
                // Alguna otra que no haya sido contemplada en BCL o externas

            throw;
        }
    }
}

