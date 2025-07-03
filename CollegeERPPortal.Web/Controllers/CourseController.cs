using CollegeERPPortal.Application.DTOs;
using CollegeERPPortal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
public class CourseController : Controller
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetAllAsync();
        return View(courses);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CourseDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        await _courseService.AddAsync(dto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var course = await _courseService.GetByIdAsync(id);
        if (course == null) return NotFound();

        return View(course);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CourseDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        await _courseService.UpdateAsync(dto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var course = await _courseService.GetByIdAsync(id);
        if (course == null) return NotFound();

        return View(course);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _courseService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
