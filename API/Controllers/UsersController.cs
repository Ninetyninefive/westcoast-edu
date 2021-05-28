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
        /*
        private readonly IUserRepository _userRepo;
        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
*/
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return Ok(await _unitOfWork.UserRepository.GetUserByIdAsync(id));
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _unitOfWork.UserRepository.GetUsersAsync());
        }

        [HttpPost()]
        public async Task<ActionResult> AddUser(AddNewUserViewModel model)
        {
            var user = await _unitOfWork.UserRepository.GetUSerByEmailAsync(model.Email);

            if (user.Email == model.Email) return BadRequest($"{model.Email} är upptagen och finns redan i systemet");

            _unitOfWork.UserRepository.Add(model);

            //if (await _unitOfWork.VehicleRepository.SaveAllAsync())
            if (await _unitOfWork.Complete())
            {
                return StatusCode(201);
            }

            return StatusCode(500, "Gick inte att spara Användaren");

            /*
            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };

            _userRepo.Add(user);

            if (await _userRepo.SaveAllAsync()) return StatusCode(201, user);
            return StatusCode(500, "Det gick inte.");
        */
        }
    }
}