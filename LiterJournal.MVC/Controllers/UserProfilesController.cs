using LiterJournal.MVC.Data;
using LiterJournal.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace LiterJournal.MVC.Controllers
{
    public class UserProfilesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserProfilesController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserProfiles.ToListAsync());
        }

        // GET: UserProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // GET: UserProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,DisplayName,Bio,ProfilePictureUrl")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string userId = null;
                    if (User.Identity?.IsAuthenticated ?? false)
                    {
                        userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    }

                    if (userId.IsNullOrEmpty())
                    {
                        return Unauthorized();
                    }

                    userProfile.UserId = userId;
                    _context.Add(userProfile);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                } 
                catch(DbUpdateException ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the profile. Please try again.");
                    return View(userProfile);

                }
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,FullName,DisplayName,Bio,ProfilePictureUrl")] UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileExists(userProfile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile != null)
            {
                _context.UserProfiles.Remove(userProfile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProfileExists(int id)
        {
            return _context.UserProfiles.Any(e => e.Id == id);
        }
    }
}
