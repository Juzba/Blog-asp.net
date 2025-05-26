using System.ComponentModel.DataAnnotations;

//#nullable disable

namespace Blog_asp.net.Models
{
    public class PostM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Zadej název")]
        public string? Title { get; set; }

        public DateTime Date { get; } = DateTime.Now;

        [Required(ErrorMessage = "Zadej Text")]
        public string? Text { get; set; }
    }
}
