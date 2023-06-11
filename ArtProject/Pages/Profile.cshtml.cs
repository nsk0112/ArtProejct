using ArtProject.DataLayer;
using ArtProject.Models;
using ArtProject.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ArtProject.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        //public PrivacyModel(ILogger<PrivacyModel> logger)
        //{
        //    _logger = logger;
        //}


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


        //public IActionResult OnPostDeleteRequest()
        //{
        //    string path = @"UserData.json";
        //    Console.WriteLine(UserName);

        //    var existingData = new List<UserModel>();

        //    if (System.IO.File.Exists(path))
        //    {
        //        var json = System.IO.File.ReadAllText(path);
        //        existingData = JsonSerializer.Deserialize<List<UserModel>>(json);
        //    }

        //    var deletedData = existingData.FindAll(user => user.Username !=  UserName).ToList();
        //    Console.WriteLine(deletedData.Count);

        //    var updatedJson = JsonSerializer.Serialize(deletedData);
            
        //    //System.IO.File.WriteAllText(jsonData, updatedJson);



        //    using (var tw = new StreamWriter(path, false))
        //    {
        //        tw.WriteLine(updatedJson.ToString());
        //        tw.Close();
        //    }


        //    return RedirectToPage("Index");
        //}

        private readonly ApplicationDbContext _db;

        public IEnumerable<UserModel> UsersListing;

        public PrivacyModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnPostDeleteRequest()
        {
            UsersListing = _db.TableUnitMaster;
            Console.WriteLine(UserName);
            UserModel DeleteUser = UsersListing.First(pt => pt.Username == UserName);
            _db.TableUnitMaster.Remove(DeleteUser);
            _db.SaveChanges();


            return RedirectToPage("Index");
        }


        [BindProperty]
        public ExhibitionModel exhData { get; set; }
        public void OnGet(ArtService artService)
        {
            ////isLogged = false;
            //string receivedValue = TempData["MyValue"] as string;

            //if (receivedValue != null && userLogged == null)
            //{
            //    isLogged = true;
            //    string jsonData = System.IO.File.ReadAllText("UserData.json");
            //    Users = JsonSerializer.Deserialize<List<UserModel>>(jsonData);

            //    userLogged = Users.Where(user => user.Username.Equals(receivedValue)).ToList()[0];
            //    Console.WriteLine(userLogged.Username);
            //    //TempData.Remove("MyValue");
            //}


            UsersListing = _db.TableUnitMaster;
            string receivedValue = TempData["MyValue"] as string;

            if (receivedValue != null && userLogged == null)
            {
                isLogged = true;
                

                userLogged = UsersListing.Where(user => user.Username.Equals(receivedValue)).ToList()[0];
                Console.WriteLine(userLogged.Username);
                //TempData.Remove("MyValue");
                exhData = artService.GetExhibitionModel();
            }

        }

        public async Task<IActionResult> OnPostLogOutRequest()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}