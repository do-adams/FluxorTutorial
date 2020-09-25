using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluxorTutorial.Data;

namespace FluxorTutorial.Store.WeatherUseCase
{
    public class FetchDataActionEffect : Effect<FetchDataAction>
    {
        private readonly WeatherForecastService WeatherForecastService;

        public FetchDataActionEffect(WeatherForecastService weatherForecastService)
        {
            WeatherForecastService = weatherForecastService;
        }

        protected override async Task HandleAsync(FetchDataAction action, IDispatcher dispatcher)
        {
            await Task.Delay(3000);
            var forecasts = await WeatherForecastService.GetForecastAsync(DateTime.Now);
            dispatcher.Dispatch(new FetchDataResultAction(forecasts));
        }
    }
}
