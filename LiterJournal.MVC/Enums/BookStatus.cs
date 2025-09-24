using System.ComponentModel.DataAnnotations;

namespace LiterJournal.MVC.Enums
{
    public enum BookStatus
    {
        [Display(Name = "Want to Read")]
        WANT_TO_READ,

        [Display(Name = "Reading")]
        READING,

        [Display(Name = "Read")]
        READ,

        [Display(Name = "Abandoned")]
        ABANDONED
    }
}
