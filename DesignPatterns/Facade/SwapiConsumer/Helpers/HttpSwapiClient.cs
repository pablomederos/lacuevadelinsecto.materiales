namespace LaCuevaDelInsecto.StarWarsApiConsumer.Helpers;

internal class HttpSwapiClient
{
    private static HttpClient? httpClient;

    public static HttpClient HttpClient
    {
        get
        {
            if (httpClient == null)
            {
                var socketsHandler = new SocketsHttpHandler
                {
                    PooledConnectionLifetime = TimeSpan.FromMinutes(2)
                };

                httpClient = new HttpClient(socketsHandler)
                {
                    BaseAddress = new Uri("https://swapi.dev/api/")
                };
            }

            return httpClient;
        }
    }
}
