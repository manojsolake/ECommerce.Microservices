namespace Products.API.Commands;

public static class RollbackStockCommandHandler
{
    public static string Execute(int productId)
    {
        return $"Stock rollback completed for ProductId: {productId}";
    }
}