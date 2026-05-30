using Products.API.Models;

namespace Products.API.Queries;

public static class GetAllProductsQueryHandler
{
    public static List<Product> Execute()
    {
        return new List<Product>
        {
            new Product
            {
                ProductId = 1,
                Name = "Laptop",
                Price = 50000,
                Stock = 10
            },
            new Product
            {
                ProductId = 2,
                Name = "Mobile",
                Price = 25000,
                Stock = 5
            }
        };
    }
}