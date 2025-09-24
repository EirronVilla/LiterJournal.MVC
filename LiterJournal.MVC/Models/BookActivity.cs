using LiterJournal.MVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace LiterJournal.MVC.Models
{
    public class BookActivity
    {
        [Key]
        public int Id { get; set; }
        public int UserBookId { get; set; }
        public UserBook UserBook { get; set; }
        public DateTime ActivityDate { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Experience { get; set; }
    }
}
