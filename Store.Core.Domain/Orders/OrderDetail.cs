using Store.Core.Domain.Products;

namespace Store.Core.Domain.Orders;

public class OrderDetail
{
    public int Id { get; set; }
    public Product Product { get; set; } = new();
    public int Quantity { get; set; }
}
