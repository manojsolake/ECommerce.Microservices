using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public OrdersController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder()
    {
        // Step 1 - Validate Customer

        var customerResponse = await _httpClient.GetAsync(
            "https://localhost:7042/api/customers/validate/1");

        if (!customerResponse.IsSuccessStatusCode)
        {
            return BadRequest("Customer validation failed");
        }

        // Step 2 - Check Product Stock

        var productResponse = await _httpClient.GetAsync(
            "https://localhost:7223/api/products/stock/1");

        if (!productResponse.IsSuccessStatusCode)
        {
            return BadRequest("Product stock validation failed");
        }

        // Step 3 - Create Order

        var order = new
        {
            OrderId = 1001,
            CustomerId = 1,
            ProductId = 1,
            Quantity = 1,
            Status = "Pending"
        };

        return Ok(new
        {
            Message = "Order Created Successfully",
            Order = order
        });
    }

    [HttpGet("{orderId}")]
    public IActionResult GetOrder(int orderId)
    {
        return Ok(new
        {
            OrderId = orderId,
            CustomerId = 1,
            ProductId = 1,
            Quantity = 1,
            Status = "Pending"
        });
    }
}