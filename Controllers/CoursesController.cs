using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSchool.Models;
using MusicSchool.Models.Data;
using MusicSchool.ViewModels.Courses;

namespace MusicSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppCtx _context;
        //private readonly UserManager<User> _userManager;

        public CoursesController(
            AppCtx context)
           //UserManager <User> user)
        {
            _context = context;
           // _userManager = user;
        } 

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            //IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var appCtx = _context.Courses
                .Include(c => c.User)
                .OrderBy(c => c.CourseName)
                .OrderBy(c => c.CountLesson);
            return View(await appCtx.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFormOfCourseViewModel model)
        {
            if (_context.Courses
                .Where(f => f.CourseName == model.CourseName && 
                    f.CountLesson == model.CountLesson && 
                    f.CourseDescr == model.CourseDescr)
                .FirstOrDefault() != null)
            {
                
                ModelState.AddModelError("", "Введённый курс уже существует");
            }

            if (ModelState.IsValid)
            {
                Course course = new()
                {
                    CountLesson = model.CountLesson,
                    CourseDescr = model.CourseDescr,
                    CourseName = model.CourseName                    
                };

                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            EditCourseViewModel model = new()
            {
                Id = course.Id,
                CourseName = course.CourseName,
                CourseDescr = course.CourseDescr,
                CountLesson = course.CountLesson
            };
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, EditCourseViewModel model)
        {
            Course course = await _context.Courses.FindAsync(id);

            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    course.CourseName = model.CourseName;
                    course.CourseDescr = model.CourseDescr;
                    course.CountLesson = model.CountLesson;
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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

            return View(model);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'AppCtx.Courses'  is null.");
            }
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(short id)
        {
          return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
