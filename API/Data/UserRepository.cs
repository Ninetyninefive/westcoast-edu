using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            _context.Entry(model).State = EntityState.Added;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
            .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<User> GetUSerByEmailAsync(string search)
        {
            return await _context.Users.SingleAsync(c => c.Email.ToLower() == search.ToLower());
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(User model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}