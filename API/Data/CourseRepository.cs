using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
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

        public void Add(AddNewCourseViewModel model)
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

        public void Update(UpdateCourseViewModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}