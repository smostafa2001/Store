using Store.Core.Domain.Products;

namespace Store.Endpoints.ShopUI.Controllers;
public class HomeController : Controller
{
    private readonly int pageSize = 2;
    private readonly IProductRepository _productRepository;
    public HomeController(IProductRepository productRepository) => _productRepository = productRepository;
    public IActionResult Index(string category = "", int pageNumber = 1)
    {
        var viewModel = new ProductListViewModel
        {
            CurrentCategory = category,
            Data = _productRepository.GetAll(pageNumber, pageSize, category)
        };
        return View(viewModel);
    }
}
