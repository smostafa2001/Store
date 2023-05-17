using Store.Core.Domain.Categories;
using Store.Infrastructure.Data.SQLServer.Common;

namespace Store.Infrastructure.Data.SQLServer.Categories;

public class EFCategoryRepository : ICategoryRepository
{
    private readonly StoreDbContext _storeContext;
    public EFCategoryRepository(StoreDbContext storeContext) => _storeContext = storeContext;
    public List<string> AllCategories => _storeContext.Categories.Select(c => c.Name).ToList();
}
