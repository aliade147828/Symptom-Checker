using AutoMapper;
using DAL.Entities;
using SymptomChecker.Models;

namespace SymptomChecker.Mappers
{
    public class DoctorProfile:Profile
    {
        public DoctorProfile()
        {
            CreateMap<CreateViewModel, Doctor>().ReverseMap();
            CreateMap<Doctor, DoctorViewModel>().ReverseMap();

        }
    }
}
