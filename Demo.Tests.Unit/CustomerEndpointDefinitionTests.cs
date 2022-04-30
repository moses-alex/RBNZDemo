using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Api.Customers;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Demo.Tests.Unit;

public class CustomerEndpointDefinitionTests
{
    private readonly ICustomerService _customerService =
        Substitute.For<ICustomerService>();


    [Fact]
    public void GetAllCustomers_ReturnEmptyList_WhenNoCustomersExist()
    {
        //Arrange
        _customerService.GetAll().Returns(new List<Customer>());

        //Act
        var result = CustomerEndpoints.GetAllCustomers(_customerService);

        //Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void GetAllCustomers_ReturnsCustomer_WhenCustomerExists()
    {
        //Arrange
        var id = Guid.NewGuid();
        var customer = new Customer { Id = id, FullName = "Mark Strong" };
        _customerService.GetAll().Returns(new List<Customer> { customer });

        //Act
        var result = CustomerEndpoints.GetAllCustomers(_customerService);

        //Assert
        result.Should().ContainSingle(x => x.Id == id && x.FullName == "Mark Strong");
    }
}
