using Store.Core.Domain.Products;

namespace Store.Core.Domain.Baskets;

public class BasketItem
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}
