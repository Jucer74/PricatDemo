using PricatMVC.Application.Interfaces;
using PricatMVC.Domain.Entities;

namespace PricatMVC.Application.Services;

public class UserService : IUserService<User>
{
    public Task<User> Login(User model)
    {
        throw new NotImplementedException();
    }

    public Task<User> Register(User model)
    {
        throw new NotImplementedException();
    }
}