using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CourseRepository : ICourseRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CourseRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Add(Course model)
        {
            _context.Entry(model).State = EntityState.Added;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<Course> GetCourseByNameAsync(string name)
        {
            return await _context.Courses.SingleAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Course model)
        {
            //_context.Entry(model).State = EntityState.Modified;
            var courseToUpdate = _mapper.Map<Course>(model, opt =>
            {
                opt.Items["repo"] = _context;
            });
            _context.Entry(courseToUpdate).State = EntityState.Modified;
        }
    }
}