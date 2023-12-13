using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSchool.Models;
using MusicSchool.Models.Data;
using MusicSchool.ViewModels.Schedules;

namespace MusicSchool.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly AppCtx _context;

        public SchedulesController(AppCtx context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.Schedule.Include(s => s.Course).Include(s => s.User);
            return View(await appCtx.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Course)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["CourseName"] = new SelectList(_context.Courses, "Id", "CourseName");
            ViewData["Email"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Schedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSchedulesViewModel model)
        {
            if (ModelState.IsValid)
            {
                Schedule schedule = new Schedule
                {
                    IdCourse = model.IdCourse,
                    IdUser = model.IdUser,
                    ClassStartTime = model.ClassStartTime,
                    ClassEndTime = model.ClassEndTime
                };
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseName"] = new SelectList(_context.Courses, "Id", "CourseName", model.IdCourse);
            ViewData["Email"] = new SelectList(_context.Users, "Id", "Email", model.IdUser);
            return View(model);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["CourseName"] = new SelectList(_context.Courses, "Id", "CourseName", schedule.IdCourse);
            ViewData["Email"] = new SelectList(_context.Users, "Id", "Email", schedule.IdUser);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, EditSchedulesViewModel model)
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
                    if (!ScheduleExists(model.Id))
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

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Course)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            if (_context.Schedule == null)
            {
                return Problem("Entity set 'AppCtx.Schedule'  is null.");
            }
            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedule.Remove(schedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(short id)
        {
          return (_context.Schedule?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
