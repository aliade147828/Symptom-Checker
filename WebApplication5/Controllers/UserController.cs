using AutoMapper;
using BLL.Repositories;
using DAL.Entities;
using WebApplication5.BLL.Interfaces;
using WebApplication5.BLL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SymptomChecker.Models;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using WebApplication5.Interfaces;
using System;
using WebApplication5.Data;
using WebApplication5.Models;
using WebApplication5.Utility;

namespace WebApplication5.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Doctor> userManger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<Doctor> userManger, IMapper mapper, IUnitOfWork unitOfWork, ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            this.userManger = userManger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            Context = context;
            this.roleManager = roleManager;
        }

        public ApplicationDbContext Context { get; }



        public IActionResult FindADoctor([FromForm] SearchModel search)
        {
         
            
            if (string.IsNullOrEmpty(search.Name) && string.IsNullOrEmpty(search.Location) && search.Department == null)
            {
                var doctor = unitOfWork.DoctorRepository.GetAll();
                return View(doctor);
            }
            else
            {
                var doctor = unitOfWork.DoctorRepository.SearchDoctors(search.Name, search.Location, search.Department);
                return View(doctor);
            }

        }
        public async Task<IActionResult> Profile(string id)
        {
            var doctor = await userManger.FindByIdAsync(id);
            return View(doctor);
        }
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
                return Content("not found");
            var doctor = await userManger.FindByIdAsync(id);
            if (doctor == null)
                return NotFound();

            var doctorVM = mapper.Map<Doctor, DoctorViewModel>(doctor);
            return View(doctorVM);


        }


    }

}
