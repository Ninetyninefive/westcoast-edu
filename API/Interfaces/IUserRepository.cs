using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUSerByEmailAsync(string name);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<bool> SaveAllAsync();
        void Add(User model);
        void Update(User model);
    }
}