using GlobalizationSSR.Net5.Shared;
using System;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using System.Linq;

namespace GlobalizationSSR.Net5.Server.DataFolder
{
    public class WeatherForecastService : IWeatherForrecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IMemoryCache _memoryCache;

        public WeatherForecastService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            await Task.Delay(0);

            return _memoryCache.GetOrCreate("WeatherData", e =>
            {
                e.SetOptions(new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(2)
                });

                var rng = new Random();
                return Enumerable.Range(1, 10).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
            .ToArray();

            });
        }
    }
}

