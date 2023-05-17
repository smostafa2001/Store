using Store.Core.Domain.Baskets;
using Store.Core.Domain.Orders;

namespace Store.Endpoints.ShopUI.Controllers;
public class OrderController : Controller
{
    private readonly IOrderRepository _repository;
    private readonly Basket _basket;

    public OrderController(IOrderRepository repository, Basket basket)
    {
        _repository = repository;
        _basket = basket;
    }
    public IActionResult Checkout() => View();
    [HttpPost]
    public IActionResult Checkout(CheckoutViewModel model)
    {
        if (!_basket.Items.Any()) ModelState.AddModelError("", "There is no item in the basket...");
        if (ModelState.IsValid)
        {
            var order = new Order
            {
                Name = model.Name,
                Address = model.Address,
                City = model.City
            };

            foreach (var item in _basket.Items)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    Product = item.Product,
                    Quantity = item.Quantity
                });
            }

            _repository.Save(order);
            _basket.Clear();
            return RedirectToAction("Complete");
        }

        return View(model);
    }

    public IActionResult Complete() => View();
}
