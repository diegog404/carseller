using carseller.Models;
using carseller.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using carseller.Data;


public class AccountController : Controller
{
    private readonly carsellerContext _context;


    public AccountController(carsellerContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = _context.User.FirstOrDefault(u =>
                u.Email == model.Email &&
                u.PasswordHash == model.Password);

        if (user == null)
        {
            ModelState.AddModelError("", "Email ou senha inválidos");
            return View(model);
        }

        // Claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("UserId", user.Id.ToString())
        };

        // Identity
        var claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        // Principal
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        // Login
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claimsPrincipal, new AuthenticationProperties { IsPersistent = false });

        return RedirectToAction("Index", "Home");
}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login");
    }
}