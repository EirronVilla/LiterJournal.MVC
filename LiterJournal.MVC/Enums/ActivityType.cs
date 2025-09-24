using System.ComponentModel.DataAnnotations;

namespace LiterJournal.MVC.Enums
{
    public enum ActivityType
    {
        [Display(Name = "Comment")]
        COMMENT,

        [Display(Name = "Quote")]
        QUOTE,

        [Display(Name = "Rating")]
        RATING,

        [Display(Name = "Review")]
        REVIEW,

        [Display(Name = "Session Started")]
        SESSION_STARTED,

        [Display(Name = "Session Finished")]
        SESSION_FINISHED,

        [Display(Name = "Book Added")]
        BOOK_ADDED,

        [Display(Name = "Achievement Unlocked")]
        ACHIEVEMENT_UNLOCKED,

        [Display(Name = "Goal Set")]
        GOAL_SET,

        [Display(Name = "Goal Completed")]
        GOAL_COMPLETED,
    }
}
