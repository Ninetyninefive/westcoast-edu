using API.Data;
using Microsoft.AspNetCore.Mvc;

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


    }
}