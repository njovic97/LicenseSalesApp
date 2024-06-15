public class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Order> PlaceOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<List<Order>> GetUserOrdersAsync(int userId)
    {
        return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
    }
}
