using Microsoft.AspNetCore.Mvc;
using Products.API.Commands;
using Products.API.DTOs;
using Products.API.Queries;

namespace Products.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = GetAllProductsQueryHandler.Execute();

        return Ok(products);
    }

    [HttpGet("{productId}")]
    public IActionResult GetProduct(int productId)
    {
        var product = GetProductByIdQueryHandler.Execute(productId);

        return Ok(product);
    }

    [HttpGet("stock/{productId}")]
    public IActionResult CheckStock(int productId)
    {
        var stock = CheckStockQueryHandler.Execute(productId);

        return Ok(stock);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductRequestDto request)
    {
        var product = CreateProductCommandHandler.Execute(request);

        return Ok(product);
    }

    [HttpPost("rollback-stock/{productId}")]
    public IActionResult RollbackStock(int productId)
    {
        var result = RollbackStockCommandHandler.Execute(productId);

        return Ok(result);
    }
}