using Microsoft.AspNetCore.Mvc;
using PricatMVC.Application.Interfaces;
using PricatMVC.Domain.Entities;

namespace PricatMVC.App.Controllers;

public class UsersController : Controller
{
    #region Global-Variables

    private readonly IUserService<User> _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion Global-Variables

    public UsersController(IHttpContextAccessor httpContextAccessor, IUserService<User> userService)
    {
        _httpContextAccessor = httpContextAccessor;
        _userService = userService;
    }

    // GET: UsersController/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: UsersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(User user)
    {
        User userFound = await _userService.Login(user);

        if (!IsValidUser(user, userFound))
        {
            ModelState.AddModelError(string.Empty, "User or Password are invalid");
            return View(user);
        }

        // Store the Name in session
        HttpContext.Session.SetString("FullUserName", GetFullUserName(userFound));

        return RedirectToAction(nameof(Index), "Home");
    }

    // GET: UsersController/Register
    public ActionResult Register()
    {
        return View();
    }

    // POST: UsersController/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(User user)
    {
        User userFound = await _userService.Login(user);

        if (userFound is not null)
        {
            ModelState.AddModelError(string.Empty, "The User Exists");
            return View(user);
        }

        await _userService.Register(user);

        return RedirectToAction(nameof(Login));
    }

    #region Private-Methods

    private bool IsValidUser(User user, User userFound)
    {
        return (userFound is not null) && userFound.Password.Equals(user.Password);
    }

    private string GetFullUserName(User userFound)
    {
        if (userFound != null)
        {
            return string.Format("{0} {1}", userFound.FirstName, userFound.LastName);
        }

        return string.Empty;
    }

    #endregion Private-Methods
}