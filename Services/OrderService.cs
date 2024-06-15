public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICodeRepository _codeRepository;

    public OrderService(IOrderRepository orderRepository, IUserRepository userRepository, ICodeRepository codeRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _codeRepository = codeRepository;
    }

    public async Task<ServiceResponse<Order>> PlaceOrderAsync(OrderDto orderDto)
    {
        var user = await _userRepository.GetUserByIdAsync(orderDto.UserId);
        if (user == null || user.VirtualBalance < (await _codeRepository.GetCodeByIdAsync(orderDto.CodeId)).Price)
        {
            return new ServiceResponse<Order> { Success = false, Message = "Insufficient funds or user not found." };
        }

        var code = await _codeRepository.GetCodeByIdAsync(orderDto.CodeId);
        if (code == null || DateTime.Now < code.ValidFrom || DateTime.Now > code.ValidTo)
        {
            return new ServiceResponse<Order> { Success = false, Message = "Code not valid." };
        }

        var order = new Order
        {
            UserId = orderDto.UserId,
            CodeId = orderDto.CodeId,
            OrderDate = DateTime.Now,
            OrderStatus = "Completed"
        };

        var placedOrder = await _orderRepository.PlaceOrderAsync(order);
        user.VirtualBalance -= code.Price;
        await _userRepository.UpdateUserAsync(user);

        return new ServiceResponse<Order> { Success = true, Data = placedOrder };
    }

    public async Task<ServiceResponse<List<Order>>> GetUserOrdersAsync(int userId)
    {
        var orders = await _orderRepository.GetUserOrdersAsync(userId);
        return new ServiceResponse<List<Order>> { Success = true, Data = orders };
    }
}
