namespace Customer.API.Models
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly List<CustomerApi> _customers;
        public CustomerRepository()
        {
            _customers = new List<CustomerApi>
            {
                new CustomerApi { Id = 1, FirstName = "John", LastName ="Doe", PhoneNumber="3454"},
                new CustomerApi { Id = 1, FirstName = "Robert", LastName ="De Niro", PhoneNumber="3454"}
            };
        }

        public CustomerApi GetCustomerById(int custId)
        {
            return _customers.FirstOrDefault(x => x.Id == custId);
        }

        public IEnumerable<CustomerApi> GetAllCustomers()
        {
            return _customers;
        }

        public void AddCustomer(CustomerApi customer)
        {
            _customers.Add(customer);
        }

        public void UpdateCustomer(CustomerApi customer) 
        {
            var existingCustomer = GetCustomerById(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
            }
        }

        public void DeleteCustomer(int custId) 
        {
            var customer = GetCustomerById(custId);
            if(customer != null)
            {
                _customers.Remove(customer);
            }
        }
    }
}
