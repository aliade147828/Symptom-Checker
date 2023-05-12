using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication5.Interfaces;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly UserManager<Doctor> userManger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public AppointmentController(UserManager<Doctor> userManger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.userManger = userManger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;

        }
        [Authorize]

        public IActionResult Index()
        {
            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointments = unitOfWork.AppointmentRepository.GetAllWithDocotr();
            return View(appointments);
        }

        public async Task<IActionResult> Appointment(string doctorId)
        {

            var doctor = await userManger.FindByIdAsync(doctorId);
            var appointmetVM = new AppointmentViewModel()
            {
                Doctor = doctor,
                DoctorId = doctor.Id,
                DoctorName = doctor.UserName
            };
            return View(appointmetVM);
        }
        [HttpPost]
        public async Task<IActionResult> Appointment(AppointmentViewModel appointmentVM)
        {
            var appointment = new Appointment
            {
                DoctorId = appointmentVM.DoctorId,
                Name = appointmentVM.Name,
                AppointmentTime = DateTime.Parse(appointmentVM.Date),
                PhoneNumber = appointmentVM.PhoneNumber,
                Email = appointmentVM.Email,
            };
            if (ModelState.IsValid)
            {
                unitOfWork.AppointmentRepository.Add(appointment);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
