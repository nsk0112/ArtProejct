using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ArtProject.DataLayer;
using ArtProject.Models;
using ArtProject.Services;
using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtProject.Pages
{
    public class CombinedModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<UserModel> UsersListing;
        public CombinedModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ExhibitionModel exhData { get; set; }
        public void OnGet(ArtService artService)
        {
            UsersListing = _db.TableUnitMaster;

            string receivedValue = TempData["MyValue"] as string;

            if (receivedValue != null || userLogged == null || User.Identity.Name != null)
            {
                isLogged = true;


                //userLogged = UsersListing.Where(user => user.Username.Equals(receivedValue)).ToList()[0];
                //Console.WriteLine(userLogged.Username);
                //TempData.Remove("MyValue");
                exhData = artService.GetExhibitionModel();
            }
        }

        [BindProperty]
        public List<UserModel> Users { get; set; }

        [BindProperty]
        public UserModel userLogged { get; set; }

        [BindProperty]
        public bool isLogged { get; set; }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public bool CanEdit { get; set; }

        public async Task<IActionResult> OnPostDeleteRequest()
        {
            UsersListing = _db.TableUnitMaster;
            Console.WriteLine(UserName);
            UserModel DeleteUser = UsersListing.First(pt => pt.Username == UserName);
            _db.TableUnitMaster.Remove(DeleteUser);
            _db.SaveChanges();

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostLogOutRequest()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }

        [BindProperty]
        public UserModel ChangeUser { get; set; }

        [BindProperty]
        public int ChangeId { get; set; }

        [BindProperty]
        public string CName { get; set; }

        [BindProperty]
        public string CEmail { get; set; }

        [BindProperty]
        public int CAge { get; set; }

        [BindProperty]
        public string CUsername { get; set; }

        [BindProperty]
        public string CPassword { get; set; }


        public IActionResult OnPostEditRequest()
        {
            UsersListing = _db.TableUnitMaster;

            //ChangeUser = UsersListing.FirstOrDefault(x => x.Id == Id);
            //Console.WriteLine(ChangeUser.Id);


            //if (ChangeUser != null)
            //{
            //    ChangeUser.Name = CName;
            //    ChangeUser.Username = CUsername;
            //    ChangeUser.Email = CEmail;
            //    ChangeUser.Password = CPassword;
            //    ChangeUser.Age = CAge;
            //}

            //_db.SaveChanges();

            Console.WriteLine(ChangeId);
            Console.WriteLine(UsersListing.ElementAt(2).Id);
            ChangeUser = UsersListing.SingleOrDefault(user => user.Id == ChangeId);
            //Console.WriteLine(ChangeUser.Id);

            if (ChangeUser != null)
            {
                ChangeUser.Name = CName;
                ChangeUser.Username = CUsername;
                ChangeUser.Email = CEmail;
                ChangeUser.Password = CPassword;
                ChangeUser.Age = CAge;
            }

            _db.SaveChanges();



            var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, ChangeUser.Username),
                    new Claim(ClaimTypes.Role, "User")
                    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToPage("Index");
        }

    }
}
