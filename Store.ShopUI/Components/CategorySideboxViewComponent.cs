using Store.Core.Domain.Categories;

namespace Store.Endpoints.ShopUI.Components;

public class CategorySideboxViewComponent : ViewComponent
{
    private readonly ICategoryRepository _categoryRepository;

    public CategorySideboxViewComponent(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public IViewComponentResult Invoke()
    {
        var currentCategory = RouteData?.Values["category"];
        ViewBag.Category = currentCategory;
        return View(_categoryRepository.AllCategories);
    }
}
