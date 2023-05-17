using Store.Core.Domain.Orders;
using Store.Infrastructure.Data.SQLServer.Common;

namespace Store.Infrastructure.Data.SQLServer.Orders;

public class EFOrderRepository : IOrderRepository
{
    private readonly StoreDbContext _context;

    public EFOrderRepository(StoreDbContext context) => _context = context;

    public void Save(Order order)
    {
        _context.AttachRange(order.OrderDetails.Select(od => od.Product));
        _context.Orders.Add(order);
        _context.SaveChanges();
    }
}
