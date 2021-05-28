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

            CreateMap<Course, UpdateCourseViewModel>();
            CreateMap<UpdateCourseViewModel, Course>();

            CreateMap<CourseViewModel, UpdateCourseViewModel>();
            CreateMap<UpdateCourseViewModel, CourseViewModel>();

            CreateMap<Course, RetireCourseViewModel>();
            CreateMap<RetireCourseViewModel, Course>();

            CreateMap<CourseViewModel, RetireCourseViewModel>();
            CreateMap<RetireCourseViewModel, CourseViewModel>();

            /*
        CreateMap<Vehicle, VehicleViewModel>()
            .ForMember(dest => dest.RegNumber, opt => opt.MapFrom(src => src.RegistrationNumber))
            .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make.Name))
            .ForMember(dest => dest.VehicleModel, opt => opt.MapFrom(src => src.VehicleModel.Name));

        CreateMap<AddVehicleViewModel, Vehicle>();

        CreateMap<VehicleViewModel, Vehicle>()
            .ForMember(dest => dest.Make, opt => opt.MapFrom<VehicleMakeResolver>())
            .ForMember(dest => dest.VehicleModel, opt => opt.MapFrom<VehicleModelResolver>());

        CreateMap<AddVehicleViewModel, Vehicle>()
            .ForMember(dest => dest.Make, opt => opt.MapFrom<AddVehicleMakeResolver>())
            .ForMember(dest => dest.VehicleModel, opt => opt.MapFrom<AddVehicleModelResolver>());
        */
        }
    }
}