using Blog_asp.net.Data;
using Blog_asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_asp.net.Pages.Blog
{
    public class DeleteModel(ApplicationDbContext db) : PageModel
    {
        private readonly ApplicationDbContext _db = db;


        [BindProperty]
        public PostM? PostM { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            PostM = await _db.PostMs.FindAsync(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if(PostM is not null)
            {
                _db.PostMs.Remove(PostM);
                _db.SaveChanges();
            }

            return RedirectToPage("/Blog/Blog");
        }
    }
}
