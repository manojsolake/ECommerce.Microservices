namespace Products.API.Queries;

public static class CheckStockQueryHandler
{
    public static object Execute(int productId)
    {
        return new
        {
            ProductId = productId,
            StockAvailable = true,
            AvailableQuantity = 10
        };
    }
}