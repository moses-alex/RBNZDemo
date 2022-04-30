using Demo.Api.Customers;

var builder = WebApplication.CreateBuilder();

builder.Services.AddCustomerServices();

var app = builder.Build();

app.MapCustomerEndpoints();

app.Run();
