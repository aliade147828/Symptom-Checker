using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SymptomChecker.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {

        private readonly UserManager<Doctor> userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper mapper;

        public AdminController(UserManager<Doctor> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.userManager = userManager;
            _roleManager = roleManager;
            this.mapper = mapper;


        }

        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.Select(user => new userViewModel
            {
                id = user.Id,
                userName = user.UserName,
                roles = userManager.GetRolesAsync(user).Result
            }).ToListAsync();
            return View(users);
        }


        public async Task<IActionResult> mangeRoles(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new userRoleViewModel
            {
                userId = user.Id,
                userName = user.UserName,
                Roles = roles.Select(role => new roleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    isSelected = userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> mangeRoles(userRoleViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.userId);

            if (user == null)
                return NotFound();

            var userRoles = await userManager.GetRolesAsync(user);

            foreach (var role in model.Roles)
            {
                if (userRoles.Any(r => r == role.RoleName) && !role.isSelected)
                    await userManager.RemoveFromRoleAsync(user, role.RoleName);

                if (!userRoles.Any(r => r == role.RoleName) && role.isSelected)
                    await userManager.AddToRoleAsync(user, role.RoleName);
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult CreateDoctor()
        {
            //ViewBag.departments=DepartmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateViewModel CreateVM)
        {
            if (ModelState.IsValid)
            {

                var doctor = mapper.Map<CreateViewModel, Doctor>(CreateVM);
                //await UnitOfWork.DoctorRepository.add(doctor);
                //return RedirectToAction("Index","Home");
                var result = await userManager.CreateAsync(doctor, CreateVM.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Admin");
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(CreateVM);
        }





        public async Task<IActionResult> deleteDoctor(string id)
        {

            if (id == null)
                return NotFound();
            var Doctor = await userManager.FindByIdAsync(id);
            if (Doctor == null)
                return NotFound();
            return View(Doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> deleteDoctor(string id, Doctor doctor)
        {
            if (id != doctor.Id)
                return BadRequest();
            try
            {
                var Result = await userManager.DeleteAsync(doctor);
                if (Result.Succeeded)
                    return RedirectToAction("Index", "Admin");
                foreach (var error in Result.Errors)
                    ModelState.AddModelError("", error.Description);
                return View(doctor);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<IActionResult> VisitDoctor(string? id)
        {
            if (id == null)
                return Content("not found");
            var doctor = await userManager.FindByIdAsync(id);
            if (doctor == null)
                return NotFound();

            var doctorVM = mapper.Map<Doctor, DoctorViewModel>(doctor);
            return View(doctorVM);


        }






    }
}
