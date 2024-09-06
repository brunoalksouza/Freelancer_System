using System;
using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace DataEF.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<User> CreateAsync(User user)
    {
        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
        return user;
    }
    public async Task<User?> GetOneByEmailAsync(string email)
    {
        var user = await _appDbContext.Users
            .FirstOrDefaultAsync(u => u.Email == email);

        return user;
    }
    public async Task<User> UpdateAsync(User user){
        _appDbContext.Users.Update(user);
        await _appDbContext.SaveChangesAsync();
        return user;
    }
}
