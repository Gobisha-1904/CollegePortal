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
    }
}
