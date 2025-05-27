using Blog_asp.net.Data;
using Blog_asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog_asp.net.Pages.Blog
{
    public class DetailsModel(ApplicationDbContext db) : PageModel
    {

        private readonly ApplicationDbContext _db = db;

        [BindProperty]
        public PostM? PostM { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            //PostM = await _db.PostMs.FirstOrDefaultAsync(p => p.Id == id);
            PostM = await _db.PostMs.FindAsync(id);



            return Page();
        }
    }
}
