using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    [HttpGet("{customerId}")]
    public IActionResult GetCustomer(int customerId)
    {
        return Ok(new
        {
            CustomerId = customerId,
            Name = "Manoj",
            Email = "manoj@test.com"
        });
    }

    [HttpGet("validate/{customerId}")]
    public IActionResult ValidateCustomer(int customerId)
    {
        return Ok(new
        {
            CustomerId = customerId,
            IsValid = true,
            Status = "Active"
        });
    }
}