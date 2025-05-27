using Blog_asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_asp.net.Pages.Blog
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public PostM PostM { get; set; } = default!;
        public void OnGet()
        {
        }
    }
}
