using ArtProject.DataLayer;
using ArtProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ArtProject.Pages
{
    public class LogInModel : PageModel
    {
        //[BindProperty]
        //public string Username { get; set; }
        //[BindProperty]
        //public string Password { get; set; }


        //public IActionResult OnPostLoginRequest()
        //{
        //    string path = @"UserData.json";

        //    var existingData = new List<UserModel>();

        //    if (System.IO.File.Exists(path))
        //    {
        //        var json = System.IO.File.ReadAllText(path);
        //        existingData = JsonSerializer.Deserialize<List<UserModel>>(json);
        //    }


        //    List<string> usernames = existingData.Select(person => person.Username).ToList();

        //    List<string> passwords = existingData.Select(person => person.Password).ToList();


        //    if (usernames.Contains(Username))
        //    {
        //        if (passwords.Contains(Password))
        //        {
        //            string valueToSend = Username;
        //            Console.WriteLine($"login successful");
        //            TempData["MyValue"] = valueToSend;
        //            return RedirectToPage("Profile");
        //        }
        //    }

        //    else
        //    {
        //        return RedirectToPage("Login");
        //    }

        //    return RedirectToPage("Index");
        //}


        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        private readonly ApplicationDbContext _db;

        public IEnumerable<UserModel> UsersListing;

        public LogInModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostLoginRequest()
        {
            UsersListing = _db.TableUnitMaster;

            var usernames = UsersListing.Select(pt => pt.Username).ToList();
            var passwords = UsersListing.Select(pt => pt.Password);


            if (usernames.Contains(Username))
            {
                if (passwords.Contains(Password))
                {
                    Console.WriteLine("pass dogru");
                    string valueToSend = Username;
                    Console.WriteLine($"login successful");
                    TempData["MyValue"] = valueToSend;
                    //return RedirectToPage("Profile");


                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, Username),
                    new Claim(ClaimTypes.Role, "User")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToPage("/Index");
                }
            }

            else
            {
                return RedirectToPage("Login");
            }

            return RedirectToPage("Index");
        }



        public void OnGet()
        {
            UsersListing = _db.TableUnitMaster;
        }

    }
}
