namespace Store.Core.Domain.Categories;

public interface ICategoryRepository
{
    List<string> AllCategories { get; }
}
