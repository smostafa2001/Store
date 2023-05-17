namespace Store.Core.Domain.Orders;

public interface IOrderRepository
{
    void Save(Order order);
}
