using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using API.Data;
using API.Entities;
using AutoMapper;
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

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetCourses()
        {
            return Ok(await _unitOfWork.CourseRepository.GetCoursesAsync());
        }

        [HttpGet("{searchString}")]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetCoursesByNameSearchAsync(string searchString)
        {
            return Ok(await _unitOfWork.CourseRepository.GetCourseByNameSearchAsync(searchString));
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddCourse(AddNewCourseViewModel model)
        {
            //var course = await _unitOfWork.CourseRepository.GetCourseByNameAsync(model.Name);

            _unitOfWork.CourseRepository.Add(model);

            //if (await _unitOfWork.VehicleRepository.SaveAllAsync())
            if (await _unitOfWork.Complete())
            {
                return StatusCode(201);
            }
            return StatusCode(500, "Det gick inte att spara kursen");
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateCourse(int id, UpdateCourseViewModel model)
        {

            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(id);

            course.Name = model.Name;
            course.Description = model.Description;

            _unitOfWork.CourseRepository.Update(course);
            if (await _unitOfWork.Complete()) return NoContent();

            return StatusCode(500, "Det gick inte att uppdatera fordonet");

        }

        [HttpPatch("retire/{id}")]
        public async Task<ActionResult> RetireCourse(int id, RetireCourseViewModel model)
        {
            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(id);
            if (course == null) { return NotFound($"Kunde inte hitta kursen i systemet med {id}!"); }

            course.Retired = !course.Retired;

            _unitOfWork.CourseRepository.Update(course);

            if (await _unitOfWork.CourseRepository.SaveAllAsync()) return NoContent();
            return StatusCode(500, "Det gick inte att uppdatera kursen!");
        }
    }
}