namespace Customer.API.Models
{
    public interface ICustomerService
    {
        CustomerApi GetCustomerById(int custId);
        IEnumerable<CustomerApi> GetAllCustomers();
        void AddCustomer(CustomerApi customer);
        void UpdateCustomer(CustomerApi customer);
        void DeleteCustomer(int custId);
    }
}
