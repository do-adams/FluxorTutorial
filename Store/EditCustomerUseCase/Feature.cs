using Fluxor;

namespace FluxorTutorial.Store.EditCustomerUseCase
{
    public class Feature : Feature<EditCustomerState>
    {
        public override string GetName() => "EditCustomer";

        protected override EditCustomerState GetInitialState() =>
            new EditCustomerState(isLoading: false);
    }
}