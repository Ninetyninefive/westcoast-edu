using API.Entities;
using API.ViewModels;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Course, CourseViewModel>();
            CreateMap<CourseViewModel, Course>();

            CreateMap<AddNewCourseViewModel, Course>();
            CreateMap<AddNewCourseViewModel, CourseViewModel>();

            CreateMap<UpdateCourseViewModel, Course>();
            CreateMap<UpdateCourseViewModel, CourseViewModel>();

            CreateMap<RetireCourseViewModel, Course>();
            CreateMap<RetireCourseViewModel, CourseViewModel>();

            CreateMap<AddNewUserViewModel, User>();
            CreateMap<AddNewUserViewModel, UserViewModel>();

            //CreateMap<UpdateCourseViewModel, Course>();
            //CreateMap<UpdateCourseViewModel, CourseViewModel>();
            //CreateMap<CourseViewModel, UpdateCourseViewModel>();
            //CreateMap<Course, UpdateCourseViewModel>();



            //CreateMap<Course, RetireCourseViewModel>();
            //CreateMap<RetireCourseViewModel, Course>();

            //CreateMap<CourseViewModel, RetireCourseViewModel>();
            //CreateMap<RetireCourseViewModel, CourseViewModel>();
        }
    }
}