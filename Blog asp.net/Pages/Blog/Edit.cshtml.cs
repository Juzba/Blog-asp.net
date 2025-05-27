using Blog_asp.net.Data;
using Blog_asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_asp.net.Pages.Blog
{
    public class EditModel(ApplicationDbContext db) : PageModel
    {

        private readonly ApplicationDbContext _db = db;

        [BindProperty]
        public PostM? PostM { get; set; }
        public int EditId { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            EditId = id;

            if (id > 0)
            {
                PostM = await _db.PostMs.FindAsync(id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (PostM == null || !ModelState.IsValid)
            {
                return Page();
            }

            await _db.PostMs.AddAsync(PostM);
            await _db.SaveChangesAsync();



            return RedirectToPage("/Blog/Blog");
        }
    }
}
