using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LiterJournal.MVC.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [ValidateNever]
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        /// <summary>
        /// Navigation property for the books associated with this user profile.
        /// </summary>
        [ValidateNever]
        public List<UserBook> UserBooks { get; set; }
    }
}
