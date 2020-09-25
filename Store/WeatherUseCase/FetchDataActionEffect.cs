using System;
using System.Threading.Tasks;
using Fluxor;

using FluxorTutorial.Services;

namespace FluxorTutorial.Store.WeatherUseCase
{
    public class FetchDataActionEffect : Effect<FetchDataAction>
    {
        private readonly IWeatherForecastService WeatherForecastService;

        public FetchDataActionEffect(IWeatherForecastService weatherForecastService)
        {
            WeatherForecastService = weatherForecastService;
        }

        protected override async Task HandleAsync(FetchDataAction action, IDispatcher dispatcher)
        {
            var forecasts = await WeatherForecastService.GetForecastAsync(DateTime.Now);
            dispatcher.Dispatch(new FetchDataResultAction(forecasts));
        }
    }
}