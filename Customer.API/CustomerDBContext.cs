using Customer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.API
{
    public class CustomerDBContext: DbContext
    {
    }

    public DbSet<CustomerApi> CustomersTest {  get; set; }
}
