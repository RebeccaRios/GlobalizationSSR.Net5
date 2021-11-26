using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalizationSSR.Net5.Shared
{
    public interface IWeatherForrecastService
    {
        Task<WeatherForecast[]> GetForecastAsync();
    }
}
