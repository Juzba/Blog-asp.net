using Blog_asp.net.Data;
using Blog_asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog_asp.net.Pages.Blog
{
    public class BlogModel(ApplicationDbContext db) : PageModel
    {
        private readonly ApplicationDbContext _db = db;

        [BindProperty]
        public IList<PostM> PostList { get; set; } = default!;

        [BindProperty]
        public string? Sort { get; set; }


        public async Task OnGet()
        {
            if (string.IsNullOrEmpty(Sort))
            {
                // Naèteni z Cookies
                Sort = Request.Cookies["Sort"] ?? "default";
            }


            var dbData = _db.PostMs.OrderByDescending(p=>p.IsOnTop);

            switch (Sort)
            {
                case ("1"):dbData = dbData.ThenBy(p => p.Id);
                    break;
                case ("2"):dbData = dbData.ThenBy(p => p.Title);
                    break;
                case ("3"):dbData = dbData.ThenBy(p => p.Date);
                    break;
                case ("4"):dbData = dbData.ThenBy(p => p.Text);
                    break;
                default:
                    break;
            }

            PostList = await dbData.ToListAsync();

            Console.WriteLine("Sort je:" + Sort);
        }


        public IActionResult OnPost()
        {
            // Uložení do Cookies
            Response.Cookies.Append("Sort", Sort ?? "default", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });

            return RedirectToPage(null);
        }

    }
}
