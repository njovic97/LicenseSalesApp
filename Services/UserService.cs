public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ServiceResponse<User>> RegisterAsync(UserDto userDto)
    {
        // Check if user already exists
        if (await _userRepository.UserExistsAsync(userDto.Username))
        {
            return new ServiceResponse<User> { Success = false, Message = "User already exists." };
        }

        var user = new User
        {
            Username = userDto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            Email = userDto.Email,
            Role = userDto.Role,
            VirtualBalance = 0
        };

        var createdUser = await _userRepository.RegisterUserAsync(user);
        return new ServiceResponse<User> { Success = true, Data = createdUser };
    }

    public async Task<ServiceResponse<User>> LoginAsync(UserDto userDto)
    {
        var user = await _userRepository.GetUserByUsernameAsync(userDto.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
        {
            return new ServiceResponse<User> { Success = false, Message = "Invalid credentials." };
        }

        return new ServiceResponse<User> { Success = true, Data = user };
    }

    public async Task<ServiceResponse<List<User>>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return new ServiceResponse<List<User>> { Success = true, Data = users };
    }

    public async Task<ServiceResponse<User>> UpdateUserAsync(int userId, UserDto userDto)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null)
        {
            return new ServiceResponse<User> { Success = false, Message = "User not found." };
        }

        user.Username = userDto.Username;
        user.Email = userDto.Email;
        user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        user.Role = userDto.Role;

        await _userRepository.UpdateUserAsync(user);
        return new ServiceResponse<User> { Success = true, Data = user };
    }

    public async Task<ServiceResponse<bool>> DeleteUserAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null)
        {
            return new ServiceResponse<bool> { Success = false, Message = "User not found." };
        }

        await _userRepository.DeleteUserAsync(user);
        return new ServiceResponse<bool> { Success = true, Data = true };
    }
}
