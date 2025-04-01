namespace Claro.OrderService.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending"; // Default Status
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
