namespace Demo.Api.Customers;

public interface ICustomerService
{
    void Create(Customer? customer);

    Customer? GetById(Guid id);

    List<Customer> GetAll();

}
