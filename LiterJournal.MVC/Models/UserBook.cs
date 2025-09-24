using LiterJournal.MVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace LiterJournal.MVC.Models
{
    public class UserBook
    {
        [Key]
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime AddedDate { get; set; }
        public BookStatus Status { get; set; }
        public int? Rating { get; set; } 
        public string Review { get; set; } 

        /// <summary>
        /// Navigation property for related book activities.
        /// </summary>
        public List<BookActivity> BookActivities { get; set; }

    }
}
