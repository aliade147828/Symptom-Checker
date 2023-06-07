using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication5.Interfaces;
using WebApplication5.Utility;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class AppoinmentController : Controller
    {
        private readonly UserManager<Doctor> userManger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public AppoinmentController(UserManager<Doctor> userManger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.userManger = userManger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;

        }
        [Authorize]

        public IActionResult Index()
        {
            
            
           return View();
        }

        public IActionResult Details(int id)
        {
            var appoinmentVM = mapper.Map<Appoinment, AppoinmentViewModel>(unitOfWork.AppointmentRepository.Get(id));
            return View(appoinmentVM);
        }
        [HttpPost]
        public IActionResult Approved(AppoinmentViewModel appoinmentVM)
        {
            
           
                if (string.IsNullOrEmpty(appoinmentVM.Time))
                {
                    
                    return View("Details",appoinmentVM.id);
                }
                else
                {
                    var appoinment = unitOfWork.AppointmentRepository.Get(appoinmentVM.id);
                    appoinment.Time= appoinmentVM.Time;
                    appoinment.Status = SD.AppoinmentStatusApproved;
                    unitOfWork.AppointmentRepository.Update(appoinment);
                    TempData["success"] = "The appointment  has been approved";
                //SEND EMAIL
                return RedirectToAction("Index");
                }

            
         
        }
        [HttpPost]
        public IActionResult Cancelled(AppoinmentViewModel appoinmentVM)
        {

            var appoinment = unitOfWork.AppointmentRepository.Get(appoinmentVM.id);
            appoinment.Time = appoinmentVM.Time;
            appoinment.Status = SD.AppoinmentStatusCancelled;
            unitOfWork.AppointmentRepository.Update(appoinment);
            TempData["success"] = "The appointment  has been cancelled ";

            //SEND EMAIL
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Appoinment(string doctorId)
        {

            var doctor = await userManger.FindByIdAsync(doctorId);
            var appointmetVM = new AppoinmentViewModel()
            {
               
                DoctorId = doctor.Id,
                DoctorName = doctor.UserName
            };
            return View(appointmetVM);
        }
        [HttpPost]
        public async Task<IActionResult> Appoinment(AppoinmentViewModel appoinmentVM)
        {
            if (ModelState.IsValid)
            {
                var appoinment = mapper.Map<AppoinmentViewModel, Appoinment>(appoinmentVM);
                if (await ValidateNumberOfAppoinemnts(appoinment))
                {
                    TempData["error"] = "Please choose another day because there is no empty appointment for the doctor";
                    return View(appoinmentVM);
                    
                }
                
                appoinment.Status = SD.AppoinmentStatusPending;
                unitOfWork.AppointmentRepository.Add(appoinment);
                TempData["success"] = "The appointment has been booked";

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        private async Task<bool> ValidateNumberOfAppoinemnts(Appoinment appoinment)
        {
            var doctor = await userManger.FindByIdAsync(appoinment.DoctorId);
            var numberOfAppoinments = unitOfWork.AppointmentRepository.NumberOfApooinments(appoinment.DoctorId, appoinment.Date);
            if (numberOfAppoinments == doctor.NumberOfAppointment) return true;
            else
                return false;
        }
        #region APIs 
        [HttpGet]
        public IActionResult GetAll()
        {
            string userId = null;
            if (User.IsInRole(SD.Role_Doctor))
            {
                 userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  
            }
           
           var appointments = unitOfWork.AppointmentRepository.GetAllWithDocotr(userId);
            var   appointmentsViewModel = mapper.Map<IEnumerable<Appoinment>, IEnumerable<AppoinmentViewModel>>(appointments);
            return Json(new { data = appointmentsViewModel });
        }
        #endregion
    }
}
