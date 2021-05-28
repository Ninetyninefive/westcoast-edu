using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;
using System.Linq;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByNameAsync(string name);
        Task<Course> GetCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<IEnumerable<Course>> GetCourseByNameSearchAsync(string name);
        Task<bool> SaveAllAsync();
        void Add(Course model);
        void Update(Course model);
    }
}