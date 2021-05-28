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
    public class CourseRepository : ICourseRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CourseRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Add(AddNewCourseViewModel model)
        {
            _context.Entry(model).State = EntityState.Added;
        }

        public async Task<CourseViewModel> GetCourseByIdAsync(int id)
        {
            return await _context.Courses
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<CourseViewModel> GetCourseByNameAsync(string name)
        {
            return await _context.Courses
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<CourseViewModel>> GetCourseByNameSearchAsync(string namesearch)
        {
            return await _context.Courses
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .Where(course => course.Name.Contains(namesearch.Trim()))
            .ToListAsync();
        }

        public async Task<IEnumerable<CourseViewModel>> GetCoursesAsync()
        {
            return await _context.Courses
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(CourseViewModel model)
        {
            //_context.Entry(model).State = EntityState.Modified;
            var courseToUpdate = _mapper.Map<CourseViewModel>(model, opt =>
            {
                opt.Items["repo"] = _context;
            });
            _context.Entry(courseToUpdate).State = EntityState.Modified;
        }
    }
}