using Products.API.Models;

namespace Products.API.Queries;

public static class GetProductByIdQueryHandler
{
    public static Product Execute(int productId)
    {
        return new Product
        {
            ProductId = productId,
            Name = "Laptop",
            Price = 50000,
            Stock = 10
        };
    }
}