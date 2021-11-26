using GlobalizationSSR.Net5.Client.DataFolder;
using GlobalizationSSR.Net5.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GlobalizationSSR.Net5.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IWeatherForrecastService, WeatherForecastService>();
            builder.AddLocalization();
            await builder.Build().RunAsync();

            var host = builder.Build();
            await host.SetDefaultCulture();
        }
    }
}
