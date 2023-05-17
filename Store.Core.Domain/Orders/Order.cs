namespace Store.Core.Domain.Orders;

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string City { get; set; } = "";
    public string Address { get; set; } = "";
    public List<OrderDetail> OrderDetails { get; set; } = new();
}