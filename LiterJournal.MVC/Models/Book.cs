using System.ComponentModel.DataAnnotations;

namespace LiterJournal.MVC.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string ISBN { get; set; }

        public string CoverUrl { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
