using System.Collections.Concurrent;

namespace Demo.Api.Customers;

public class CustomerService : ICustomerService
{
    private readonly ConcurrentDictionary<Guid, Customer> _customers = new();

    public void Create(Customer? customer)
    {
        if (customer is null)
        {
            return;
        }

        _customers[customer.Id] = customer;
    }

    public Customer? GetById(Guid id)
    {
        return _customers.GetValueOrDefault(id);
    }

    public List<Customer> GetAll()
    {
        return _customers.Values.ToList();
    }

}
