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
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _unitOfWork.UserRepository.GetUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return Ok(await _unitOfWork.UserRepository.GetUserByIdAsync(id));
        }

        [HttpGet("email/{searchEmail}")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserByEmailSearchAsync(string searchEmail)
        {
            return Ok(await _unitOfWork.UserRepository.GetUserByEmailSearchAsync(searchEmail));
        }

        [HttpGet("phone/{searchPhone}")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserByPhoneSearchAsync(string searchPhone)
        {
            return Ok(await _unitOfWork.UserRepository.GetUserByPhoneSearchAsync(searchPhone));
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddUser(AddNewUserViewModel model)
        {
            //var course = await _unitOfWork.CourseRepository.GetCourseByNameAsync(model.Name);

            _unitOfWork.UserRepository.Add(model);

            //if (await _unitOfWork.VehicleRepository.SaveAllAsync())
            if (await _unitOfWork.Complete())
            {
                return StatusCode(201);
            }
            return StatusCode(500, "Det gick inte att spara kursen");
        }
    }
}