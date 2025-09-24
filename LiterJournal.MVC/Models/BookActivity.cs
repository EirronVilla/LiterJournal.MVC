using LiterJournal.MVC.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LiterJournal.MVC.Models
{
    public class BookActivity
    {
        [Key]
        public int Id { get; set; }
        public int UserBookId { get; set; }

        /// <summary>
        /// Navigation property for the user book associated with this activity.
        /// </summary>
        [ValidateNever]
        public UserBook UserBook { get; set; }
        public DateTime ActivityDate { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Experience { get; set; }
    }
}
