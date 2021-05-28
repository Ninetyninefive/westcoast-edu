using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetCourseByNameAsync(string name);
        Task<User> GetCourseByIdAsync(int id);
        Task<User> RetireCourseByIdAsync(int id);
        Task<IEnumerable<User>> GetCoursesAsync();
        Task<bool> SaveAllAsync();
        void Add(User model);
        void Update(User model);
    }
}