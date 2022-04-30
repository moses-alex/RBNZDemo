namespace Demo.Api.Customers;

public class Customer
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string FullName { get; init; } = default!;
}
