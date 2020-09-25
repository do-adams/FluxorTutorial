using System.Collections.Generic;

using FluxorTutorial.Shared;

namespace FluxorTutorial.Store.WeatherUseCase
{
    public class FetchDataResultAction
    {
        public IEnumerable<WeatherForecast> Forecasts { get; }

        public FetchDataResultAction(IEnumerable<WeatherForecast> forecasts)
        {
            Forecasts = forecasts;
        }
    }
}