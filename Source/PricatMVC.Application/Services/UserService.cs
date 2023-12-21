using PricatMVC.Application.Interfaces;
using PricatMVC.Domain.Entities;
using PricatMVC.Domain.Exceptions;
using PricatMVC.Domain.Interfaces.Repositories;

namespace PricatMVC.Application.Services;

public class UserService : IUserService<User>
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Login(User model)
    {
        return await _userRepository.FindByEmailAsync(model.UserEmail);
    }

    public async Task<User> Register(User model)
    {
        return await _userRepository.AddAsync(model);
    }
}