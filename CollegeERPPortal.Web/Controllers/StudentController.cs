using CollegeERPPortal.Application.DTOs;
using CollegeERPPortal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CollegeERPPortal.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync();
            return View(students);
        }

        // ✅ Add this: GET method to show form
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Shows Create.cshtml
        }

        // ✅ Existing POST method to handle form submission
        [HttpPost]
        public async Task<IActionResult> Create(StudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _studentService.AddAsync(dto);
            return RedirectToAction("Index"); // ✅ redirects to Index
        }
              public async Task<IActionResult> Edit(int id)
        {
            var faculty = await _studentService.GetByIdAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _studentService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }
        [HttpGet]
 // GET: Faculty/Delete/5
public async Task<IActionResult> Delete(int id)
{
    var faculty = await _studentService.GetByIdAsync(id);
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
    await _studentService.DeleteAsync(id); // ✅ Only ID is needed
    return RedirectToAction("Index");
}



    }
}
