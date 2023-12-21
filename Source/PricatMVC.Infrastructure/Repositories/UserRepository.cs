using Microsoft.EntityFrameworkCore;
using PricatMVC.Domain.Entities;
using PricatMVC.Domain.Interfaces.Repositories;
using PricatMVC.Infrastructure.Common;
using PricatMVC.Infrastructure.Context;

namespace PricatMVC.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AppDbContext _appDbContext;
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail.ToLower() == email.ToLower());

        return user!;
    }

}