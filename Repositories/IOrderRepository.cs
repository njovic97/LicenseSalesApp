public interface IOrderRepository
{
    Task<Order> PlaceOrderAsync(Order order);
    Task<List<Order>> GetUserOrdersAsync(int userId);
}
