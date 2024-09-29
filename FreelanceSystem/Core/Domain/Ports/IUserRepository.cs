using Domain.Entities;

namespace Domain.Ports;

public interface IUserRepository
{
    public Task<User> CreateAsync(User user);
    public Task<User?> GetOneByEmailAsync(string email);
    public Task<User> UpdateAsync(User user);
    public Task<List<User>> GetAllProfessionalsAsync(int perPage, int page);
}