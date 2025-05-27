using Blog_asp.net.Data;
using Blog_asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blog_asp.net.Pages.Blog
{
    public class EditModel(ApplicationDbContext db) : PageModel
    {

        private readonly ApplicationDbContext _db = db;

        [BindProperty]
        public PostM PostM { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _db.PostMs.AddAsync(PostM);
            await _db.SaveChangesAsync();


            return RedirectToPage("/Blog/Blog");
        }
    }
}
