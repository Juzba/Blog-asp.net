using Blog_asp.net.Data;
using Blog_asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog_asp.net.Pages
{
    public class BlogModel(ApplicationDbContext db) : PageModel
    {
        private readonly ApplicationDbContext _db = db;

        //[BindProperty]
        public IList<PostM> PostList { get; set; } = default!;
        public async Task OnGet()
        {
            PostList = await _db.PostMs.ToListAsync();
        }
    }
}
