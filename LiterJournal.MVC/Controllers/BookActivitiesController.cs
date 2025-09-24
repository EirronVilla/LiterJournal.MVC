using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiterJournal.MVC.Data;
using LiterJournal.MVC.Models;

namespace LiterJournal.MVC.Controllers
{
    public class BookActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookActivities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookActivities.Include(b => b.UserBook);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookActivity = await _context.BookActivities
                .Include(b => b.UserBook)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookActivity == null)
            {
                return NotFound();
            }

            return View(bookActivity);
        }

        // GET: BookActivities/Create
        public IActionResult Create()
        {
            var userBooks = _context.UserBooks
                .Include(ub => ub.Book) // make sure Book is loaded
                .Select(ub => new
                {
                    ub.Id,
                    DisplayText = ub.Book.Title + " by " + ub.Book.Author
                })
                .ToList();

            ViewData["UserBookId"] = new SelectList(userBooks, "Id", "DisplayText");
            return View();
        }

        // POST: BookActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserBookId,ActivityDate,ActivityType,Title,Content,Experience")] BookActivity bookActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserBookId"] = new SelectList(_context.UserBooks, "Id", "Id", bookActivity.UserBookId);
            return View(bookActivity);
        }

        // GET: BookActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookActivity = await _context.BookActivities.FindAsync(id);
            if (bookActivity == null)
            {
                return NotFound();
            }
            ViewData["UserBookId"] = new SelectList(_context.UserBooks, "Id", "Id", bookActivity.UserBookId);
            return View(bookActivity);
        }

        // POST: BookActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserBookId,ActivityDate,ActivityType,Title,Content,Experience")] BookActivity bookActivity)
        {
            if (id != bookActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookActivityExists(bookActivity.Id))
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
            ViewData["UserBookId"] = new SelectList(_context.UserBooks, "Id", "Id", bookActivity.UserBookId);
            return View(bookActivity);
        }

        // GET: BookActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookActivity = await _context.BookActivities
                .Include(b => b.UserBook)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookActivity == null)
            {
                return NotFound();
            }

            return View(bookActivity);
        }

        // POST: BookActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookActivity = await _context.BookActivities.FindAsync(id);
            if (bookActivity != null)
            {
                _context.BookActivities.Remove(bookActivity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookActivityExists(int id)
        {
            return _context.BookActivities.Any(e => e.Id == id);
        }
    }
}
