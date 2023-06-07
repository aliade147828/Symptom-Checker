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
            CreateMap<AppoinmentViewModel, Appoinment>().ReverseMap();

        }
    }
}
