using GlobalizationSSR.Net5.Client.DataFolder;
using GlobalizationSSR.Net5.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Components;

namespace GlobalizationSSR.Net5.Client
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddLocalization();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IWeatherForrecastService, WeatherForecastService>();

            var host = builder.Build();

            // AQUI PEGO O NAVIGATION MANAGER PARA ME AJUDAR A RECUPERAR A URL ABSOLUTA ATUAL
            NavigationManager navigationManager = host.Services.GetRequiredService<NavigationManager>();
            System.Console.WriteLine(navigationManager.Uri);

            // AQUI, ATRAVES DO navigationManager.Uri VOCÊ TEM A URL ABSOLUTA
            // FALTA APLICAR UM SCRIPT PARA CAPTURAR O VALOR DA QUERYSTRING culture, SE HOUVER
            // COLOQUEI FIXO APENAS PARA TESTE
            string langFromQuery = "es";
           

            // AQUI DE FATO SETO A CULTURE DO WEBASSEBLY
            CultureInfo.CurrentCulture = new CultureInfo(langFromQuery);
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(langFromQuery);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(langFromQuery);

            await host.RunAsync();            
        }
    }
}
