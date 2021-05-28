using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly DataContext _context;
        public CoursesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        [HttpPost()]
        public async Task<ActionResult> AddCourse(AddNewCourseViewModel model)
        {
            var course = new Course
            {
                Name = model.Name,
                Description = model.Description
            };

            _context.Courses.Add(course);
            var result = await _context.SaveChangesAsync();

            return StatusCode(201, course);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateCourse(int id, UpdateCourseViewModel model)
        {
            var course = await _context.Courses.FindAsync(id);

            course.Name = model.Name;
            course.Description = model.Description;

            _context.Courses.Update(course);

            var result = _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("retire/{id}")]
        public async Task<ActionResult> RetireCourse(int id, RetireCourseViewModel model)
        {
            var course = await _context.Courses.FindAsync(id);

            course.Retired = model.Retired;

            _context.Courses.Update(course);

            var result = _context.SaveChangesAsync();

            return NoContent();
        }
    }
}