using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluxorTutorial.Data;

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
