using System;
using Microsoft.Extensions.DependencyInjection;
using Fluxor;

using FluxorTutorial.Services;
using FluxorTutorial.Store.Middlewares.Logging;

namespace FluxorTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<App>();
            services.AddFluxor(o => o
                .ScanAssemblies(typeof(Program).Assembly)
                .AddMiddleware<LoggingMiddleware>());
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<App>();
            app.Run();
        }
    }
}
