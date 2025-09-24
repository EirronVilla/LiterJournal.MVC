using LiterJournal.MVC.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LiterJournal.MVC.Models
{
    public class UserBook
    {
        [Key]
        public int Id { get; set; }
        public int UserProfileId { get; set; }

        /// <summary>
        /// Navigation property for the user profile associated with this book.
        /// </summary>
        [ValidateNever]
        public UserProfile UserProfile { get; set; }

        public int BookId { get; set; }

        /// <summary>
        /// Navigation property for the book associated with this user book entry.
        /// </summary>
        [ValidateNever]
        public Book Book { get; set; }

        public DateTime AddedDate { get; set; }
        public BookStatus Status { get; set; }
        public int? Rating { get; set; } 
        public string Review { get; set; }

        /// <summary>
        /// Navigation property for related book activities.
        /// </summary>
        [ValidateNever]
        public List<BookActivity> BookActivities { get; set; }

    }
}
