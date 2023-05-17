using Store.Core.Domain.Baskets;

namespace Store.Endpoints.ShopUI.Models;

public class BasketViewModel
{
    public Basket Basket { get; set; }
    public string ReturnUrl { get; set; }
}
