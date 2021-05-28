using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        Task<CourseViewModel> GetCourseByNameAsync(string name);
        Task<CourseViewModel> GetCourseByIdAsync(int id);
        Task<IEnumerable<CourseViewModel>> GetCoursesAsync();
        Task<IEnumerable<CourseViewModel>> GetCourseByNameSearchAsync(string name);
        Task<bool> SaveAllAsync();
        void Add(AddNewCourseViewModel model);
        void Update(CourseViewModel model);
    }
}