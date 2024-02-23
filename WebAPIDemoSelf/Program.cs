var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// product
app.MapGet("/products", () =>
{
    return "Getting all products!";
});

app.MapGet("/products/{id}", (int id) =>
{
    return $"Getting product with ID : {id}";
});

app.MapPost("/products", () =>
{
    return "Create product!";
});

app.MapPut("/products/{id}", (int id) =>
{
    return $"Updating product with ID : {id}";
});

app.MapDelete("/products/{id}", (int id) =>
{
    return $"Delete product with ID : {id}";
});

app.Run();