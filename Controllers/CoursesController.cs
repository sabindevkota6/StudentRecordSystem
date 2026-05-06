using Microsoft.AspNetCore.Mvc;
using StudentRecordSystem.Models;
using Microsoft.AspNetCore.Http;
using StudentRecordSystem.Data;

namespace StudentRecordSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController(AppDbContext dbContext) : ControllerBase
    {
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            return Ok("Successfully added course.");
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var allCourses = dbContext.Courses.ToList();
            return Ok(allCourses);
        }

        [HttpGet("modules")]
        public IActionResult GetAllCoursesWithModules()
        {
            var allCourses = dbContext.Courses.Select(
                c => new { c.Id, c.Name, c.DurationYears, c.Modules }
                ).ToList();
            return Ok(allCourses);
        }
    }
}
