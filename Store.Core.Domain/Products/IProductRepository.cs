using Store.Framework.Paginations;

namespace Store.Core.Domain.Products;

public interface IProductRepository
{
    PagedData<Product> GetAll(int pageNumber, int pageSize, string category);
    Product GetById(int id);
}