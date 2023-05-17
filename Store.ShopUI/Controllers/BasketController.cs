using Store.Core.Domain.Baskets;
using Store.Core.Domain.Products;

namespace Store.Endpoints.ShopUI.Controllers;
public class BasketController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly Basket _basket;
    public BasketController(IProductRepository productRepository, Basket basket)
    {
        _productRepository = productRepository;
        _basket = basket;
    }

    public IActionResult Index(string returnUrl)
    {
        BasketViewModel basketViewModel = new()
        {
            Basket = _basket,
            ReturnUrl = returnUrl
        };
        return View(basketViewModel);
    }
    [HttpPost]
    public IActionResult AddToBasket(int productId, string returnUrl)
    {
        var product = _productRepository.GetById(productId);
        _basket.Add(product, 1);
        return RedirectToAction("Index", new { ReturnUrl = returnUrl });
    }
    public IActionResult RemoveFromBasket(int productId, string returnUrl)
    {
        var product = _productRepository.GetById(productId);
        _basket.Remove(product);
        return RedirectToAction("Index", new { ReturnUrl = returnUrl });
    }
}