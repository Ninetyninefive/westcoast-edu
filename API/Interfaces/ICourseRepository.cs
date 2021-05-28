using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByNameAsync(string name);
        Task<Course> GetCourseByIdAsync(int id);
        Task<Course> RetireCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<bool> SaveAllAsync();
        void Add(Course model);

        void Update(Course model);
    }
}