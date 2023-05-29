using AutoMapper;
using DAL.Entities;
using SymptomChecker.Models;
using System;
using WebApplication5.ViewModels;

namespace WebApplication5.Mappers
{
    public class AppoinmentProfile:Profile
    {
        public AppoinmentProfile()
        {
            CreateMap<AppoinmentViewModel, Appoinment>()
                .ForMember(dest => dest.AppointmentTime, src => src.MapFrom(src => DateTime.Parse(src.Date)))
                .ReverseMap();
               

        }
    }
}
