using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CourseRepository : ICourseRepository
    {

        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
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
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Course> RetireCourseByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Course model)
        {
            throw new System.NotImplementedException();
        }
    }
}