using AngleSharp.Html.Parser;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using ArtProject.DataLayer;
using ArtProject.Models;
using ArtProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtProject.Pages
{

    public class TicketModel : PageModel
    {

        [BindProperty]
        public SingleExhModel Exhibition { get; set; }

        [BindProperty]
        public int ExhId { get; set; }

        public string Username { get; set; }

        public int Id { get; set; }

        private readonly ApplicationDbContext _db;

        public IEnumerable<UserExhModel> UsersExhListing;

        public TicketModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostBuyRequest()
        {
            await Console.Out.WriteLineAsync(ExhId.ToString());
            Username = User.Identity.Name;
            UserExhModel deneme = new(Username, ExhId.ToString(), Id);

            await _db.UserExhTable.AddAsync(deneme);
            await _db.SaveChangesAsync();

            return RedirectToPage("Profile");
        }

        public void OnGet(int id, ArtService artService)
        {
            UsersExhListing = _db.UserExhTable;

            ExhId = id;

            Exhibition = artService.GetSingleExhibition(id);
            Username = User.Identity.Name;
            //Console.WriteLine(Username);

           
            var doc = new HtmlParser();
            if (!string.IsNullOrEmpty(Exhibition.data.short_description))
                Exhibition.data.short_description = Regex.Replace(Exhibition.data.short_description, @"<[^>]*>", String.Empty);
            
        }
    }
}
