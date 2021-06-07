using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Add(AddNewUserViewModel model)
        {
            var userToAdd = _mapper.Map<User>(model, opt =>
            {
                opt.Items["repo"] = _context;
            });
            _context.Entry(userToAdd).State = EntityState.Added;
        }

        public async Task<UserViewModel> GetUserByIdAsync(int id)
        {
            return await _context.Users
            .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IEnumerable<UserViewModel>> GetUserByEmailSearchAsync(string emailSearch)
        {
            return await _context.Users
            .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
            .Where(user => user.Email.Contains(emailSearch.Trim()))
            .ToListAsync();
        }

        public async Task<IEnumerable<UserViewModel>> GetUserByPhoneSearchAsync(string phoneSearch)
        {
            return await _context.Users
            .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
            .Where(user => user.PhoneNumber.Contains(phoneSearch.Trim()))
            .ToListAsync();
        }
        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            return await _context.Users
            .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(UserViewModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}