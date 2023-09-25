using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


namespace Dammon.Controllers;

public class LoginController : Controller
{
    private readonly Context _db;

    public LoginController(Context db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }



    public IActionResult Check(string UserName, string Password)
    {

        var ExistUser = _db.users.Where(x => x.UserName == UserName && x.UserPassword == Password).FirstOrDefault();

        if (ExistUser != null)
        {
            //use cliaim add  id and name and Role to the claim
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, ExistUser.Name+""+ExistUser.Family),
            new Claim(ClaimTypes.Role,ExistUser.UserRole),
            new Claim(ClaimTypes.NameIdentifier, ExistUser.IdUser.ToString())
        };

            //create identity
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //create principal
            var principal = new ClaimsPrincipal(identity);

            //sign in

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("index", "home");
        }
        else
        {
            TempData["error"] = "نام کاربری یا رمز عبور اشتباه است ";
            return RedirectToAction("index");
        }

        //TODO: Implement Realistic Implementation
        
    }




}
