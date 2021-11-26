using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalizationSSR.Net5.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace GlobalizationSSR.Net5.Client.DataFolder
{
    public class WeatherForecastService : IWeatherForrecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }

    }
}
