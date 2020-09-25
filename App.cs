using System;
using System.Linq;
using Newtonsoft.Json;
using Fluxor;

using FluxorTutorial.Store.CounterUseCase;
using FluxorTutorial.Store.WeatherUseCase;
using FluxorTutorial.Store.EditCustomerUseCase;
using FluxorTutorial.Shared;

namespace FluxorTutorial
{
    class App : IDisposable
    {
        private readonly IStore Store;
        public readonly IDispatcher Dispatcher;
        private readonly IActionSubscriber ActionSubscriber;
        private readonly IState<CounterState> CounterState;
        private readonly IState<WeatherState> WeatherState;

        public App(IStore store, IDispatcher dispatcher, IActionSubscriber actionSubscriber, IState<CounterState> counterState, IState<WeatherState> weatherState)
        {
            Store = store;
            Dispatcher = dispatcher;
            ActionSubscriber = actionSubscriber;
            CounterState = counterState;
            CounterState.StateChanged += CounterState_StateChanged;
            WeatherState = weatherState;
            WeatherState.StateChanged += WeatherState_StateChanged;
        }

        private void CounterState_StateChanged(object sender, CounterState e)
        {
            // Console.WriteLine("");
            // Console.WriteLine("==========================> CounterState");
            // Console.WriteLine("ClickCount is " + CounterState.Value.ClickCount);
            // Console.WriteLine("<========================== CounterState");
            // Console.WriteLine("");
        }

        private void WeatherState_StateChanged(object sender, WeatherState e)
        {
            // Console.WriteLine("");
            // Console.WriteLine("=========================> WeatherState");
            // Console.WriteLine("IsLoading: " + WeatherState.Value.IsLoading);
            // if (!WeatherState.Value.Forecasts.Any())
            // {
            //     Console.WriteLine("--- No weather forecasts");
            // }
            // else
            // {
            //     Console.WriteLine("Temp C\tTemp F\tSummary");
            //     foreach (WeatherForecast forecast in WeatherState.Value.Forecasts)
            //         Console.WriteLine($"{forecast.TemperatureC}\t{forecast.TemperatureF}\t{forecast.Summary}");
            // }
            // Console.WriteLine("<========================== WeatherState");
            // Console.WriteLine("");
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Initializing store");

            Store.InitializeAsync().Wait();
            SubscribeToResultAction();

            string input = "";

            do
            {
                Console.WriteLine("1: Increment counter");
                Console.WriteLine("2: Fetch data");
                Console.WriteLine("3: Get mutable object from API server");
                Console.WriteLine("x: Exit");
                Console.Write("> ");

                input = Console.ReadLine();

                switch (input.ToLowerInvariant())
                {
                    case "1":
                        var action = new IncrementCounterAction();
                        Dispatcher.Dispatch(action);
                        break;
                    case "2":
                        var fetchDataAction = new FetchDataAction();
                        Dispatcher.Dispatch(fetchDataAction);
                        break;
                    case "3":
                        var getCustomerAction = new GetCustomerForEditAction(42);
                        Dispatcher.Dispatch(getCustomerAction);
                        break;
                    case "x":
                        Console.WriteLine("Program terminated");
                        return;
                }

            } while (true);
        }

        private void SubscribeToResultAction()
        {
            Console.WriteLine($"Subscribing to action {nameof(GetCustomerForEditResultAction)}");
            ActionSubscriber.SubscribeToAction<GetCustomerForEditResultAction>(this, action =>
            {
                // Show the object from the server in the console
                string jsonToShowInConsole = JsonConvert.SerializeObject(action.Customer, Formatting.Indented);
                Console.WriteLine("Action notification: " + action.GetType().Name);
                Console.WriteLine(jsonToShowInConsole);
            });
        }


        void IDisposable.Dispose()
        {
            // IMPORTANT: Unsubscribe to avoid memory leaks!
            ActionSubscriber.UnsubscribeFromAllActions(this);
        }
    }
}
