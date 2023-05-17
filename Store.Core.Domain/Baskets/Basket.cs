using Store.Core.Domain.Products;

namespace Store.Core.Domain.Baskets;

public class Basket
{
    public List<BasketItem> Items { get; private set; } = new();
    public virtual void Add(Product product, int quantity)
    {
        var basketItem = Items.FirstOrDefault(bi => bi.Product.Id == product.Id);
        if (basketItem is not null) basketItem.Quantity += quantity;
        else Items.Add(new()
        {
            Product = product,
            Quantity = quantity
        });
    }
    public virtual void Remove(Product product) => Items.RemoveAll(i => i.Product.Id == product.Id);
    public int TotalPrice => Items.Sum(i => i.Product.Price * i.Quantity);
    public virtual void Clear() => Items.Clear();
}