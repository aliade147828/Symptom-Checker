using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebApplication5.Interfaces;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DepartmentController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var departments = mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(unitOfWork.DepartmentRepository.GetAll());
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = mapper.Map<DepartmentViewModel, Department>(model);
                unitOfWork.DepartmentRepository.Add(department);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int? id, string viewName)
        {
            if (id == null)
                return NotFound();

            var department = unitOfWork.DepartmentRepository.Get(id);

            if (department == null)
                return NotFound();
            var departmentViewModel = mapper.Map<Department, DepartmentViewModel>(department);
            return View(viewName, departmentViewModel);
        }
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, DepartmentViewModel departmentViewModel)
        {
            if (id != departmentViewModel.DNO)
                BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var department = mapper.Map<DepartmentViewModel, Department>(departmentViewModel);
                    unitOfWork.DepartmentRepository.Update(department);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return View(departmentViewModel);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? id, DepartmentViewModel departmentViewModel)
        {
            if (id != departmentViewModel.DNO)
                BadRequest();

            try
            {
                var department = mapper.Map<DepartmentViewModel, Department>(departmentViewModel);
                unitOfWork.DepartmentRepository.Delete(department);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
