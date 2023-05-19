using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using WebApplication5.Helper;
using WebApplication5.Interfaces;
using WebApplication5.Utility;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class RequestController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment environment;
        public RequestController(IUnitOfWork unitOfWork, IMapper mapper, IHostingEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var mapRequests = mapper.Map<IEnumerable<Request>, IEnumerable<RequestViewModel>>(unitOfWork.RequestRepository.GetAll());
            return View(mapRequests);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var request = unitOfWork.RequestRepository.Get(id);
            if (request == null) return NotFound();

            var mapRequest = mapper.Map<Request, RequestViewModel>(request);
            return View(mapRequest);
        }
        public IActionResult SendRequest()
        {
            return View();
        }
       [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendRequest(RequestViewModel model)
        {
            if (model == null) return NotFound();
            if (ModelState.IsValid)
            {
                model.FileName = DocumentSettings.UploadFile(model.CV, "CVs");
                model.Status = SD.RequestStatusPending;
                var request = mapper.Map<RequestViewModel, Request>(model);
                unitOfWork.RequestRepository.Add(request);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(this.environment.WebRootPath, "files/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}
