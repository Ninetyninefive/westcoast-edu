using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByNameAsync(string name);
        Task<Course> GetCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<bool> SaveAllAsync();
        void Add(AddNewCourseViewModel model);
        void Update(UpdateCourseViewModel model);
    }
}