using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public OrdersController(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder()
    {
        var customerApiUrl =
            _configuration["ServiceUrls:CustomerApi"];

        var productApiUrl =
            _configuration["ServiceUrls:ProductApi"];

        // Step 1 - Validate Customer

        var customerResponse =
            await _httpClient.GetAsync(
                $"{customerApiUrl}/api/customers/validate/1");

        if (!customerResponse.IsSuccessStatusCode)
        {
            return BadRequest("Customer validation failed");
        }

        // Step 2 - Check Product Stock

        var productResponse =
            await _httpClient.GetAsync(
                $"{productApiUrl}/api/products/stock/1");

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
}