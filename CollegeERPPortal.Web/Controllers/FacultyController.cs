using CollegeERPPortal.Application.DTOs;
using CollegeERPPortal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CollegeERPPortal.Web.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        public async Task<IActionResult> Index()
        {
            var faculties = await _facultyService.GetAllAsync();
            return View(faculties);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(FacultyDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _facultyService.AddAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var faculty = await _facultyService.GetByIdAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FacultyDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _facultyService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }
        [HttpGet]
 // GET: Faculty/Delete/5
public async Task<IActionResult> Delete(int id)
{
    var faculty = await _facultyService.GetByIdAsync(id);
    if (faculty == null)
    {
        return NotFound();
    }
    return View(faculty);
}

// POST: Faculty/Delete
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    await _facultyService.DeleteAsync(id); // ✅ Only ID is needed
    return RedirectToAction("Index");
}




    }
}
