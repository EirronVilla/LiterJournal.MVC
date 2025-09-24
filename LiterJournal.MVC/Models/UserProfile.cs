using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LiterJournal.MVC.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
