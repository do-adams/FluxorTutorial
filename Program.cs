using System;
using Microsoft.Extensions.DependencyInjection;
using Fluxor;

using FluxorTutorial.Services;

namespace FluxorTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<App>();
            services.AddFluxor(o => o
                .ScanAssemblies(typeof(Program).Assembly));
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<App>();
            app.Run();
        }
    }
}
