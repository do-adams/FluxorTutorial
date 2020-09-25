using FluxorTutorial.ApiObjects;

namespace FluxorTutorial.Store.EditCustomerUseCase
{
    public class GetCustomerForEditResultAction
    {
        public CustomerEdit Customer { get; }

        public GetCustomerForEditResultAction(CustomerEdit customer)
        {
            Customer = customer;
        }
    }
}