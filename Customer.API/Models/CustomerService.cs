namespace Customer.API.Models
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {

        }

        public CustomerApi GetCustomerById(int custId)
        {
            return _customerRepository.GetCustomerById(custId);
        }

        public IEnumerable<CustomerApi> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public void AddCustomer(CustomerApi customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(CustomerApi customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }
        public void DeleteCustomer(int custId)
        {
            _customerRepository.DeleteCustomer(custId);
        }
    }
}
