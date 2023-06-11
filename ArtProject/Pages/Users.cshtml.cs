using ArtProject.DataLayer;
using ArtProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtProject.Pages
{
    public class UsersModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<UserModel> UsersListing;

        public UsersModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            UsersListing = _db.TableUnitMaster;
        }
    }
}
