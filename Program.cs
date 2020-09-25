using System;
using Microsoft.Extensions.DependencyInjection;
using Fluxor;

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

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<App>();
            app.Run();
        }
    }
}
