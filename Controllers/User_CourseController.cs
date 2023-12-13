using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSchool.Models;
using MusicSchool.Models.Data;
using MusicSchool.ViewModels.UsersCourses;

namespace MusicSchool.Controllers
{
    public class User_CourseController : Controller
    {
        private readonly AppCtx _context;

        public User_CourseController(AppCtx context)
        {
            _context = context;
        }

        // GET: User_Course
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.Users_Courses.Include(u => u.Course).Include(u => u.User);
            return View(await appCtx.ToListAsync());
        }

        // GET: User_Course/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null || _context.Users_Courses == null)
            {
                return NotFound();
            }

            var user_Course = await _context.Users_Courses
                .Include(u => u.Course)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_Course == null)
            {
                return NotFound();
            }

            return View(user_Course);
        }

        // GET: User_Course/Create
        public IActionResult Create()
        {
            ViewData["CourseName"] = new SelectList(_context.Courses, "Id", "CourseName");
            ViewData["Email"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: User_Course/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                User_Course user_course = new User_Course
                {
                    IdCourse = model.IdCourse,
                    IdUser = model.IdUser,
                    Review=model.Review
                };
                _context.Add(user_course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseName"] = new SelectList(_context.Courses, "Id", "CourseName", model.IdCourse);
            ViewData["Email"] = new SelectList(_context.Users, "Id", "Email", model.IdUser);
            return View(model);
        }

        // GET: User_Course/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null || _context.Users_Courses == null)
            {
                return NotFound();
            }

            var user_Course = await _context.Users_Courses.FindAsync(id);
            if (user_Course == null)
            {
                return NotFound();
            }
            ViewData["CourseName"] = new SelectList(_context.Courses, "Id", "CourseName", user_Course.IdCourse);
            ViewData["Email"] = new SelectList(_context.Users, "Id", "Email", user_Course.IdUser);
            return View(user_Course);
        }

        // POST: User_Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, EditUserCourseViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_CourseExists(model.Id))
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
            ViewData["CourseName"] = new SelectList(_context.Courses, "Id", "CourseName", model.CourseName);
            ViewData["Email"] = new SelectList(_context.Users, "Id", "Email", model.Email);
            return View(model);
        }

        // GET: User_Course/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null || _context.Users_Courses == null)
            {
                return NotFound();
            }

            var user_Course = await _context.Users_Courses
                .Include(u => u.Course)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_Course == null)
            {
                return NotFound();
            }

            return View(user_Course);
        }

        // POST: User_Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            if (_context.Users_Courses == null)
            {
                return Problem("Entity set 'AppCtx.User_Course'  is null.");
            }
            var user_Course = await _context.Users_Courses.FindAsync(id);
            if (user_Course != null)
            {
                _context.Users_Courses.Remove(user_Course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_CourseExists(short id)
        {
          return (_context.Users_Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
