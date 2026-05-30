using Products.API.DTOs;

namespace Products.API.Commands;

public static class CreateProductCommandHandler
{
    public static ProductResponseDto Execute(ProductRequestDto request)
    {
        return new ProductResponseDto
        {
            ProductId = 1001,
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };
    }
}