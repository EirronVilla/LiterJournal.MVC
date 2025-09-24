using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LiterJournal.MVC.Controllers
{
    [Authorize] // all derived controllers require authentication
    
    public class BaseController : Controller
    {
        protected string CurrentUserId =>
            User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new UnauthorizedAccessException();
    }
}
