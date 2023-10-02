using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{

    private readonly Context db;
    public LoginController(Context _db)
    {
        db = _db;
    }

        //login


    public IActionResult Login()
    {
        return View();
    }
    //logout
    public IActionResult Logout()
    {
        HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }
    //access denied
    public IActionResult AccessDenied()
    {
        return View();
    }

    //check login
    [HttpPost]
    public IActionResult CheckLogin(string username, string password)
    {
        if (username == "admin" && password == "123")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            HttpContext.SignInAsync(claimsPrincipal);
            return RedirectToAction("Index", "Home");
        }
//go in db and check 


        if (db.users.Any(u => u.UserName == username && u.PassWord == password))
        {
            var user = db.users.Where(u => u.UserName == username && u.PassWord == password).FirstOrDefault();



            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name)


            };

            if (user.AdminStatus == true)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                ViewBag.Admin=true;
            }
            if (user.LcStatus == true)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Lc"));
                ViewBag.Lc=true;
            }
            if (user.NaghdiStatus == true)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Naghdi"));
                ViewBag.Naghdi=true;
            }
            if (user.SaderatStatus == true)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Saderat"));
                ViewBag.Saderat=true;
            }



            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authProperties = new AuthenticationProperties
            {
            };

            HttpContext.SignInAsync(claimsPrincipal);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Error = "نام کاربری یا رمز عبور اشتباه است";
            return RedirectToAction("Login");
        }

    }


}
