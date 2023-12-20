using Microsoft.AspNetCore.Mvc;
using PricatMVC.App.Models;

namespace PricatMVC.App.Controllers;

public class UsersController : Controller
{
    #region Global-Variables

    private static List<User> userList = LoadUsers();
    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion Global-Variables

    public UsersController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    // GET: UsersController/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: UsersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(User user)
    {
        try
        {
            if (!IsValidUser(user))
            {
                ModelState.AddModelError(string.Empty, "Usuario o Contraseña incorrectos");
                return View(user);
            }

            // Store the Name in session
            HttpContext.Session.SetString("FullUserName", GetFullUserName(user));

            return RedirectToAction(nameof(Index), "Home");
        }
        catch
        {
            return View();
        }
    }

    // GET: UsersController/Register
    public ActionResult Register()
    {
        return View();
    }

    // POST: UsersController/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(User user)
    {
        try
        {
            User userFound = FindUserByUserEmail(user.UserEmail, userList);
            if (userFound != null)
            {
                ModelState.AddModelError(string.Empty, "Usuario Ya Existe");
                return View(user);
            }

            userList.Add(user);

            return RedirectToAction(nameof(Login));
        }
        catch
        {
            return View();
        }
    }

    #region Private-Methods

    private static List<User> LoadUsers()
    {
        List<User> users = new List<User>();

        users.Add(new User() { Id = 1, UserEmail = "Admin@email.com", FirstName = "Admin", LastName = "User", Password = "P4ssw0rd*01" });

        return users;
    }

    private bool IsValidUser(User user)
    {
        User userFound = FindUserByUserEmail(user.UserEmail, userList);

        if (userFound != null)
        {
            return userFound.Password.Equals(user.Password);
        }

        return false;
    }

    private User FindUserByUserEmail(string userEmail, List<User> users)
    {
        User user = null!;

        if (!string.IsNullOrEmpty(userEmail))
        {
            user = users.FirstOrDefault(x => userEmail.Equals(x.UserEmail, StringComparison.OrdinalIgnoreCase)) ?? null!;
        }

        return user;
    }

    private string GetFullUserName(User user)
    {
        User userFound = FindUserByUserEmail(user.UserEmail, userList);

        if (userFound != null)
        {
            return string.Format("{0} {1}", userFound.FirstName, userFound.LastName);
        }

        return string.Empty;
    }

    #endregion Private-Methods
}