using Store.Core.Domain.Baskets;

namespace Store.Endpoints.ShopUI.Components;

public class BasketSummaryViewComponent : ViewComponent
{
    private readonly Basket _basket;

    public BasketSummaryViewComponent(Basket basket) => _basket = basket;

    public IViewComponentResult Invoke() => View(_basket);
}
