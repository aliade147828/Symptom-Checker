using AutoMapper;
using DAL.Entities;
using WebApplication5.ViewModels;

namespace WebApplication5.Mappers
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<RequestViewModel, Request>().ReverseMap();
        }
    }
}
