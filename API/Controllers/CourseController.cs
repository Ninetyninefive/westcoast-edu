using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*
        private readonly ICourseRepository _courseRepo;
        public CoursesController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }
        
        private readonly DataContext _context;
        public CoursesController(DataContext context)
        {
            _context = context;
        }
        */
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return Ok(await _unitOfWork.CourseRepository.GetCoursesAsync());
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddCourse(AddNewCourseViewModel model)
        {
            var course = await _unitOfWork.CourseRepository.GetCourseByNameAsync(model.Name);

            if (course.Name == model.Name) return BadRequest($"Kursen {model.Name} finns redan i systemet");

            _unitOfWork.CourseRepository.Add(model);

            //if (await _unitOfWork.VehicleRepository.SaveAllAsync())
            if (await _unitOfWork.Complete())
            {
                return StatusCode(201);
            }

            return StatusCode(500, "Gick inte att spara fordonet");
            /*
            var course = new Course
            {
                Name = model.Name,
                Description = model.Description
            };

            _courseRepo.Add(course);
            if (await _courseRepo.SaveAllAsync()) return StatusCode(201, course);
            return StatusCode(500, "Det gick inte.");
            */
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateCourse(int id, UpdateCourseViewModel model)
        {
            try
            {
                var course = await _courseRepo.GetCourseByIdAsync(id);
                if (course == null) { return NotFound($"Kunde inte hitta kursen i systemet med {id}!"); }

                course.Name = model.Name;
                course.Description = model.Description;

                _courseRepo.Update(course);

                if (await _courseRepo.SaveAllAsync()) return NoContent();
                return StatusCode(500, "Det gick inte att uppdatera kursen!");
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("retire/{id}")]
        public async Task<ActionResult> RetireCourse(int id, RetireCourseViewModel model)
        {
            try
            {
                var course = await _courseRepo.GetCourseByIdAsync(id);
                if (course == null) { return NotFound($"Kunde inte hitta kursen i systemet med {id}!"); }

                course.Retired = !course.Retired;

                _courseRepo.Update(course);

                if (await _courseRepo.SaveAllAsync()) return NoContent();
                return StatusCode(500, "Det gick inte att uppdatera kursen!");
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}