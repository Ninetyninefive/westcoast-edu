using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<UserViewModel> GetUserByIdAsync(int id);
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<IEnumerable<UserViewModel>> GetUserByEmailSearchAsync(string emailSearch);
        Task<IEnumerable<UserViewModel>> GetUserByPhoneSearchAsync(string phoneSearch);
        Task<bool> SaveAllAsync();
        void Add(AddNewUserViewModel model);
        void Update(UserViewModel model);
    }
}