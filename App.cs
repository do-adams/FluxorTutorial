using System;
using Fluxor;
using FluxorTutorial.Store.CounterUseCase;

namespace FluxorTutorial
{
    class App
    {
        private readonly IStore Store;
        public readonly IDispatcher Dispatcher;
        private readonly IState<CounterState> CounterState;

        public App(IStore store, IDispatcher dispatcher, IState<CounterState> counterState)
        {
            Store = store;
            Dispatcher = dispatcher;
            CounterState = counterState;
            CounterState.StateChanged += CounterState_StateChanged;
        }

        private void CounterState_StateChanged(object sender, CounterState e)
        {
            Console.WriteLine("");
            Console.WriteLine("==========================> CounterState");
            Console.WriteLine("ClickCount is " + CounterState.Value.ClickCount);
            Console.WriteLine("<========================== CounterState");
            Console.WriteLine("");
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Initializing store");
            Store.InitializeAsync().Wait();
            string input = "";
            do
            {
                Console.WriteLine("1: Increment counter");
                Console.WriteLine("x: Exit");
                Console.Write("> ");
                input = Console.ReadLine();

                switch (input.ToLowerInvariant())
                {
                    case "1":
                        var action = new IncrementCounterAction();
                        Dispatcher.Dispatch(action);
                        break;

                    case "x":
                        Console.WriteLine("Program terminated");
                        return;
                }

            } while (true);
        }
    }
}
