namespace FluxorTutorial.Store.EditCustomerUseCase
{
    public class GetCustomerForEditAction
    {
        public int Id { get; }

        public GetCustomerForEditAction(int id)
        {
            Id = id;
        }
    }
}