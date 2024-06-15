public interface IUserRepository
{
    Task<bool> UserExistsAsync(string username);
    Task<User> RegisterUserAsync(User user);
    Task<User> GetUserByUsernameAsync(string username);
    Task<User> GetUserByIdAsync(int userId);
    Task<List<User>> GetAllUsersAsync();
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
}
