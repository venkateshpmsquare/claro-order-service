using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetOrder), new { id }, id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null) return NotFound();
        return Ok(order);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result) return NotFound();
        return NoContent();
    }
}
