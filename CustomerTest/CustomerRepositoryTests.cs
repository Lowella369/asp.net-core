using Customer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTest
{
    public class CustomerRepositoryTests
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerRepositoryTests()
        {
            _customerRepository = new CustomerRepository();
        }

        [Fact]
        public void GetCustomerById_ReturnsCorrectCustomer()
        {
            var customerId = 1;

            var result = _customerRepository.GetCustomerById(customerId);

            Assert.NotNull(result);
            Assert.Equal(customerId, result.Id);
        }

        [Fact]
        public void GetCustomerById_ReturnsNullWhenCustomerNotFound()
        {
            var customerId = 99;

            var result = _customerRepository.GetCustomerById(customerId);

            Assert.Null(result);
        }

        [Fact]
        public void GetAllCustomers_ReturnsAllCustomers()
        {
            var result = _customerRepository.GetAllCustomers();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void AddCustomer_AddCustomerCorrectly()
        {
            var newCustomer = new CustomerApi { Id = 3, FirstName = "Julia", LastName = "Roberts", PhoneNumber = "3234" };

            _customerRepository.AddCustomer(newCustomer);
            var result = _customerRepository.GetCustomerById(3);

            Assert.NotNull(newCustomer);
            Assert.Equal(newCustomer.Id, result.Id);
            Assert.Equal(newCustomer.FirstName, result.FirstName); 
            Assert.Equal(newCustomer.LastName, result.LastName);
            Assert.Equal(newCustomer.PhoneNumber, result.PhoneNumber);

        }

        [Fact]
        public void UpdateCustomer_UpdateCustomersCorrectly()
        {
            var updatedCustomer = new CustomerApi { Id = 1, FirstName = "Updated Customer", LastName = "Updated Lastname", PhoneNumber = "214-093-9870" };

            _customerRepository.UpdateCustomer(updatedCustomer);
            var result = _customerRepository.GetCustomerById(1);

            Assert.NotNull(result);
            Assert.Equal(updatedCustomer.FirstName, result.FirstName);
            Assert.Equal(updatedCustomer.LastName, result.LastName);
            Assert.Equal(updatedCustomer.PhoneNumber, result.PhoneNumber);
        }

        [Fact]
        public void DeleteCustomer_DeleteCustomersCorrectly()
        {
            var customerId = 1;

            _customerRepository.DeleteCustomer(customerId);
            var result = _customerRepository.GetCustomerById(customerId);

            Assert.Null(result);
        }
    }
}
