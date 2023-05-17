using Store.Core.Domain.Products;
using Store.Framework.Paginations;
using Store.Infrastructure.Data.SQLServer.Common;

namespace Store.Infrastructure.Data.SQLServer.Products;

public class EFProductRepository : IProductRepository
{
    private readonly StoreDbContext _storeContext;
    public EFProductRepository(StoreDbContext storeContext) => _storeContext = storeContext;
    public PagedData<Product> GetAll(int pageNumber, int pageSize, string category) => new()
    {
        PageInfo = new PageInfo
        {
            PageSize = pageSize,
            PageNumber = pageNumber,
            TotalCount = _storeContext.Products.Where(c => string.IsNullOrWhiteSpace(category) || c.Category.Name == category).Count()
        },
        Data = _storeContext.Products.Where(c => string.IsNullOrWhiteSpace(category) || c.Category.Name == category).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
    };
    public Product GetById(int id) => _storeContext.Products.Where(p => p.Id == id).FirstOrDefault() ?? new();
}