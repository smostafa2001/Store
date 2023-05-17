using Store.Core.Domain.Products;
using Store.Framework.Paginations;

namespace Store.Endpoints.ShopUI.Models;

public class ProductListViewModel
{
    public PagedData<Product> Data { get; set; }
    public string CurrentCategory { get; set; }
}
