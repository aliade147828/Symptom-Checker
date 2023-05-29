using AutoMapper;
using DAL.Entities;
using WebApplication5.ViewModels;

namespace WebApplication5.Mappers
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentViewModel>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.DName))
                .ReverseMap()
                .ForMember(dest => dest.DName, src => src.MapFrom(src => src.Name));
        }
    }
}
